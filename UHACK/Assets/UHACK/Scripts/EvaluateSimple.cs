using System.Collections;
using UnityEngine;
using Grpc.Core;
using System.Threading;
using Evaluator;

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

    IEnumerable Evaluate(LayerType[] simpleLayers)
    {
        EvaluateRequest req = new EvaluateRequest { };
        bool flat = false;
        foreach (LayerType l in simpleLayers)
        {
            switch (l)
            {
                case LayerType.Conv:
                    if (flat) {
                        throw new System.ArgumentException("tried to add multidimensional layer after flatten");
                    }
                    req.Layers.Add(new Evaluator.Layer { Convolution = new Evaluator.ConvolutionLayer { Filters = 1 } });
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
}