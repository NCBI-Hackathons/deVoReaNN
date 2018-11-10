using System;
using UnityEngine;
using UnityEngine.UI;
using Grpc.Core;
using Evaluator;
using System.Collections;
using System.Threading.Tasks;
using System.Threading;

public class TestingEvaluator : MonoBehaviour
{

    // Use this for initialization
    IEnumerator Start()
    {
        yield return null;
        Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);
        Debug.Log("Created channel.");
        try
        {
            var client = new Evaluator.Evaluator.EvaluatorClient(channel);
            Debug.Log("Created client.");
            ConvolutionLayer conv = new ConvolutionLayer { Filters = 1 };
            Debug.Log("Created concolution layer.");
            FlattenLayer flatten = new FlattenLayer { };
            Debug.Log("Created flatten layer.");
            EvaluateRequest req = new EvaluateRequest { Layers = { new Evaluator.Layer { Convolution = conv }, new Evaluator.Layer { Flatten = flatten } } };
            Debug.Log("Created evaluate request.");
            using (var call = client.Evaluate(req))
            {
                Debug.Log("Invoked evaluate.");
                while (call.ResponseStream.MoveNext(CancellationToken.None).Result)
                {
                    Debug.Log("Received response.");
                    var progress = call.ResponseStream.Current;
                    Debug.Log(progress.Accuracy);
                }
            }
            channel.ShutdownAsync().Wait();
        }
        catch (Exception e)
        {
            Debug.LogError("grpc error: " + e.Message);
            throw;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
