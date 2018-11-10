FROM tensorflow/tensorflow:latest-gpu-py3

ADD *.py /

RUN pip install numpy keras googleapis-common-protos grpcio-tools

CMD ["python", "/server.py"]
