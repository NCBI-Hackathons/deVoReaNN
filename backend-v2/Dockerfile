FROM tensorflow/tensorflow:latest-gpu-py3

RUN pip install numpy keras googleapis-common-protos grpcio-tools

ADD *.py /

CMD ["python", "/server.py"]
