FROM python:3

ADD *.py /

RUN pip install numpy keras tensorflow googleapis-common-protos grpcio-tools

CMD ["python", "./server.py"]
