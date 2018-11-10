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
    [SerializeField]
    Button button;

    // Use this for initialization
    void Start()
    {
        Channel channel = new Channel("localhost:50051", ChannelCredentials.Insecure);
        try
        {
            var client = new Evaluator.Evaluator.EvaluatorClient(channel);
            ConvolutionLayer conv = new ConvolutionLayer { Filters = 1 };
            FlattenLayer flatten = new FlattenLayer { };
            EvaluateRequest req = new EvaluateRequest { Layers = { new Evaluator.Layer { Convolution = conv }, new Evaluator.Layer { Flatten = flatten } } };
            using (var call = client.Evaluate(req))
            {
                var responseReaderTask = Task.Run(async () =>
                {
                    while (await call.ResponseStream.MoveNext(CancellationToken.None)) {
                        var progress = call.ResponseStream.Current;
                        Debug.Log(progress.Accuracy);
                    }
                });
            }
            //channel.ShutdownAsync().Wait();
        }
        catch(Exception e)
        {
            Debug.LogError(e);
            throw;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
