# dl-vr-backend
U-HackMed DL/VR team 3.

## Development

To generate the protocol buffers code, run this command:

> python -m grpc_tools.protoc --python_out=. --grpc_python_out=. --proto_path=. *.proto