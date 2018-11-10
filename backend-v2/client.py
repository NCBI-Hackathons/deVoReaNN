import evaluator_pb2
import evaluator_pb2_grpc
import grpc

channel = grpc.insecure_channel('localhost:50051')
stub = evaluator_pb2_grpc.EvaluatorStub(channel)

conv = evaluator_pb2.ConvolutionLayer(filters = 1);


stub.Evaluate()