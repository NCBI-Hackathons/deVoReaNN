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

    Channel channel;
    Evaluator.Evaluator.EvaluatorClient client;

    // Use this for initialization
    IEnumerator Start()
    {
        yield return null;
        channel = new Channel("172.18.224.168:50051", ChannelCredentials.Insecure);
        Debug.Log("Created channel.");
        try
        {
            client = new Evaluator.Evaluator.EvaluatorClient(channel);
            Debug.Log("Created client.");
            EvaluateRequest req = new EvaluateRequest {
                Layers = {
                    new Evaluator.Layer { Convolution = new ConvolutionLayer { Filters = 1 } }, 
                    new Evaluator.Layer { Flatten = new FlattenLayer { }}
                }
            };
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
