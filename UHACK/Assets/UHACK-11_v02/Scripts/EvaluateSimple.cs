using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grpc.Core;
using System.Threading.Tasks;
using System.Threading;
using Evaluator;
using Google.Protobuf.Collections;

public class EvaluateSimple : MonoBehaviour
{

    Channel channel;
    Evaluator.Evaluator.EvaluatorClient client;
    float accuracy;

    LayerManger manager;

    // Use this for initialization
    void Start()
    {
        channel = new Channel("172.18.224.168:50051", ChannelCredentials.Insecure);
        Debug.Log("Created channel.");
        client = new Evaluator.Evaluator.EvaluatorClient(channel);
        Debug.Log("Created client.");

        manager = FindObjectOfType<LayerManger>();
    }

    public IEnumerator Evaluate(LayerType[] simpleLayers)
    {
        EvaluateRequest req = new EvaluateRequest { };
        bool flat = false;
        for (int i = 0; i < simpleLayers.Length; i++)
        {
            LayerType l = simpleLayers[i];
            switch (l)
            {
                case LayerType.Conv:
                    if (flat) {
                        throw new System.ArgumentException("tried to add multidimensional layer after flatten");
                    }
                    req.Layers.Add(new Evaluator.Layer { Convolution = new Evaluator.ConvolutionLayer { Filters = 32 } });
                    break;
                case LayerType.Full:
                case LayerType.Dense:
                    if (!flat) {
                        req.Layers.Add(new Evaluator.Layer{Flatten = new Evaluator.FlattenLayer{}});
                        flat = true;
                    }
                    req.Layers.Add(new Evaluator.Layer { Dense = new Evaluator.DenseLayer { Neurons = 128 } });
                    break;
                case LayerType.Pool:
                    if (flat) {
                        throw new System.ArgumentException("tried to add multidimensional layer after flatten");
                    }
                    req.Layers.Add(new Evaluator.Layer { Maxpooling = new Evaluator.MaxpoolingLayer { } });
                    break;
                case LayerType.Dropout:
                    req.Layers.Add(new Evaluator.Layer { Dropout = new Evaluator.DropoutLayer { Dimension = 0.5f } });
                    break;
                default:
                    throw new System.ArgumentException("unknown layer type: " + l);
            }
        }
        if (!flat) {
            req.Layers.Add(new Evaluator.Layer { Flatten = new Evaluator.FlattenLayer { } });
        }
        using (var call = client.EvaluateAsync(req)) {
            while (!call.ResponseAsync.IsCompleted) {
                yield return new WaitForSeconds(0.5f);
            }
            accuracy = call.ResponseAsync.Result.Accuracy;
            if(manager) manager.SetAcurracyText(accuracy);
        }
    }
}