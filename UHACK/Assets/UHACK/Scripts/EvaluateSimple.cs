using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Grpc.Core;
using System.Collections;
using System.Threading.Tasks;
using System.Threading;
using Evaluator;
using Google.Protobuf.Collections;

public class EvaluateSimple : MonoBehaviour
{

    Channel channel;
    Evaluator.Evaluator.EvaluatorClient client;

    // Use this for initialization
    void Start()
    {
        channel = new Channel("172.18.224.168:50051", ChannelCredentials.Insecure);
        Debug.Log("Created channel.");
        client = new Evaluator.Evaluator.EvaluatorClient(channel);
        Debug.Log("Created client.");
    }

    IEnumerable DoEvaluate(LayerType[] simpleLayers)
    {
        EvaluateRequest req = new EvaluateRequest { };
        foreach (LayerType l in simpleLayers)
        {
            switch (l)
            {
                case LayerType.Conv:
                    req.Layers.Add(new Evaluator.Layer { Convolution = new Evaluator.ConvolutionLayer { Filters = 1 } });
                    break;
                case LayerType.Full:
                case LayerType.Dense:
                    req.Layers.Add(new Evaluator.Layer { Dense = new Evaluator.DenseLayer { Neurons = 128 } });
                    break;
                case LayerType.Pool:
                    req.Layers.Add(new Evaluator.Layer { Maxpooling = new Evaluator.MaxpoolingLayer { } });
                    break;
                case LayerType.Dropout:
                    req.Layers.Add(new Evaluator.Layer { Dropout = new Evaluator.DropoutLayer { Dimension = 0.5f } });
                    break;
                default:
                    Debug.Log("Unknown layer type: " + l);
                    break;
            }
        }
        using (var call = client.Evaluate(req))
        {
            Debug.Log("Invoked evaluate.");
            while (call.ResponseStream.MoveNext(CancellationToken.None).Result)
            {
                Debug.Log("Received response.");
                var progress = call.ResponseStream.Current;
                yield return progress;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}