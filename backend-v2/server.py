import grpc
import evaluator_pb2_grpc
import evaluator
from concurrent import futures
_ONE_DAY_IN_SECONDS = 60 * 60 * 24
import time

def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    evaluator_pb2_grpc.add_EvaluatorServicer_to_server(evaluator.Evaluator(), server)
    server.add_insecure_port('[::]:50051')
    server.start()
    try:
        while True:
            time.sleep(_ONE_DAY_IN_SECONDS)
    except KeyboardInterrupt:
        server.stop(0)


if __name__ == '__main__':
    serve()