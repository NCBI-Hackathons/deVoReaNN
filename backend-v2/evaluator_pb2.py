# Generated by the protocol buffer compiler.  DO NOT EDIT!
# source: evaluator.proto

import sys
_b=sys.version_info[0]<3 and (lambda x:x) or (lambda x:x.encode('latin1'))
from google.protobuf import descriptor as _descriptor
from google.protobuf import message as _message
from google.protobuf import reflection as _reflection
from google.protobuf import symbol_database as _symbol_database
# @@protoc_insertion_point(imports)

_sym_db = _symbol_database.Default()




DESCRIPTOR = _descriptor.FileDescriptor(
  name='evaluator.proto',
  package='evaluator',
  syntax='proto3',
  serialized_options=None,
  serialized_pb=_b('\n\x0f\x65valuator.proto\x12\tevaluator\"3\n\x0f\x45valuateRequest\x12 \n\x06layers\x18\x01 \x03(\x0b\x32\x10.evaluator.Layer\"\xfb\x01\n\x05Layer\x12\x32\n\x0b\x63onvolution\x18\x01 \x01(\x0b\x32\x1b.evaluator.ConvolutionLayerH\x00\x12*\n\x07\x64ropout\x18\x02 \x01(\x0b\x32\x17.evaluator.DropoutLayerH\x00\x12*\n\x07\x66latten\x18\x03 \x01(\x0b\x32\x17.evaluator.FlattenLayerH\x00\x12&\n\x05\x64\x65nse\x18\x04 \x01(\x0b\x32\x15.evaluator.DenseLayerH\x00\x12\x30\n\nmaxpooling\x18\x05 \x01(\x0b\x32\x1a.evaluator.MaxpoolingLayerH\x00\x42\x0c\n\ndefinition\"#\n\x10\x43onvolutionLayer\x12\x0f\n\x07\x66ilters\x18\x01 \x01(\x03\"!\n\x0c\x44ropoutLayer\x12\x11\n\tdimension\x18\x01 \x01(\x02\"\x0e\n\x0c\x46lattenLayer\"\x1d\n\nDenseLayer\x12\x0f\n\x07neurons\x18\x01 \x01(\x05\"\x11\n\x0fMaxpoolingLayer\"2\n\x0eProgressUpdate\x12\x10\n\x08\x61\x63\x63uracy\x18\x01 \x01(\x02\x12\x0e\n\x06\x65pochs\x18\x02 \x01(\x05\x32R\n\tEvaluator\x12\x45\n\x08\x45valuate\x12\x1a.evaluator.EvaluateRequest\x1a\x19.evaluator.ProgressUpdate\"\x00\x30\x01\x62\x06proto3')
)




_EVALUATEREQUEST = _descriptor.Descriptor(
  name='EvaluateRequest',
  full_name='evaluator.EvaluateRequest',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='layers', full_name='evaluator.EvaluateRequest.layers', index=0,
      number=1, type=11, cpp_type=10, label=3,
      has_default_value=False, default_value=[],
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=30,
  serialized_end=81,
)


_LAYER = _descriptor.Descriptor(
  name='Layer',
  full_name='evaluator.Layer',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='convolution', full_name='evaluator.Layer.convolution', index=0,
      number=1, type=11, cpp_type=10, label=1,
      has_default_value=False, default_value=None,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='dropout', full_name='evaluator.Layer.dropout', index=1,
      number=2, type=11, cpp_type=10, label=1,
      has_default_value=False, default_value=None,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='flatten', full_name='evaluator.Layer.flatten', index=2,
      number=3, type=11, cpp_type=10, label=1,
      has_default_value=False, default_value=None,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='dense', full_name='evaluator.Layer.dense', index=3,
      number=4, type=11, cpp_type=10, label=1,
      has_default_value=False, default_value=None,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='maxpooling', full_name='evaluator.Layer.maxpooling', index=4,
      number=5, type=11, cpp_type=10, label=1,
      has_default_value=False, default_value=None,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
    _descriptor.OneofDescriptor(
      name='definition', full_name='evaluator.Layer.definition',
      index=0, containing_type=None, fields=[]),
  ],
  serialized_start=84,
  serialized_end=335,
)


_CONVOLUTIONLAYER = _descriptor.Descriptor(
  name='ConvolutionLayer',
  full_name='evaluator.ConvolutionLayer',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='filters', full_name='evaluator.ConvolutionLayer.filters', index=0,
      number=1, type=3, cpp_type=2, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=337,
  serialized_end=372,
)


_DROPOUTLAYER = _descriptor.Descriptor(
  name='DropoutLayer',
  full_name='evaluator.DropoutLayer',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='dimension', full_name='evaluator.DropoutLayer.dimension', index=0,
      number=1, type=2, cpp_type=6, label=1,
      has_default_value=False, default_value=float(0),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=374,
  serialized_end=407,
)


_FLATTENLAYER = _descriptor.Descriptor(
  name='FlattenLayer',
  full_name='evaluator.FlattenLayer',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=409,
  serialized_end=423,
)


_DENSELAYER = _descriptor.Descriptor(
  name='DenseLayer',
  full_name='evaluator.DenseLayer',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='neurons', full_name='evaluator.DenseLayer.neurons', index=0,
      number=1, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=425,
  serialized_end=454,
)


_MAXPOOLINGLAYER = _descriptor.Descriptor(
  name='MaxpoolingLayer',
  full_name='evaluator.MaxpoolingLayer',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=456,
  serialized_end=473,
)


_PROGRESSUPDATE = _descriptor.Descriptor(
  name='ProgressUpdate',
  full_name='evaluator.ProgressUpdate',
  filename=None,
  file=DESCRIPTOR,
  containing_type=None,
  fields=[
    _descriptor.FieldDescriptor(
      name='accuracy', full_name='evaluator.ProgressUpdate.accuracy', index=0,
      number=1, type=2, cpp_type=6, label=1,
      has_default_value=False, default_value=float(0),
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
    _descriptor.FieldDescriptor(
      name='epochs', full_name='evaluator.ProgressUpdate.epochs', index=1,
      number=2, type=5, cpp_type=1, label=1,
      has_default_value=False, default_value=0,
      message_type=None, enum_type=None, containing_type=None,
      is_extension=False, extension_scope=None,
      serialized_options=None, file=DESCRIPTOR),
  ],
  extensions=[
  ],
  nested_types=[],
  enum_types=[
  ],
  serialized_options=None,
  is_extendable=False,
  syntax='proto3',
  extension_ranges=[],
  oneofs=[
  ],
  serialized_start=475,
  serialized_end=525,
)

_EVALUATEREQUEST.fields_by_name['layers'].message_type = _LAYER
_LAYER.fields_by_name['convolution'].message_type = _CONVOLUTIONLAYER
_LAYER.fields_by_name['dropout'].message_type = _DROPOUTLAYER
_LAYER.fields_by_name['flatten'].message_type = _FLATTENLAYER
_LAYER.fields_by_name['dense'].message_type = _DENSELAYER
_LAYER.fields_by_name['maxpooling'].message_type = _MAXPOOLINGLAYER
_LAYER.oneofs_by_name['definition'].fields.append(
  _LAYER.fields_by_name['convolution'])
_LAYER.fields_by_name['convolution'].containing_oneof = _LAYER.oneofs_by_name['definition']
_LAYER.oneofs_by_name['definition'].fields.append(
  _LAYER.fields_by_name['dropout'])
_LAYER.fields_by_name['dropout'].containing_oneof = _LAYER.oneofs_by_name['definition']
_LAYER.oneofs_by_name['definition'].fields.append(
  _LAYER.fields_by_name['flatten'])
_LAYER.fields_by_name['flatten'].containing_oneof = _LAYER.oneofs_by_name['definition']
_LAYER.oneofs_by_name['definition'].fields.append(
  _LAYER.fields_by_name['dense'])
_LAYER.fields_by_name['dense'].containing_oneof = _LAYER.oneofs_by_name['definition']
_LAYER.oneofs_by_name['definition'].fields.append(
  _LAYER.fields_by_name['maxpooling'])
_LAYER.fields_by_name['maxpooling'].containing_oneof = _LAYER.oneofs_by_name['definition']
DESCRIPTOR.message_types_by_name['EvaluateRequest'] = _EVALUATEREQUEST
DESCRIPTOR.message_types_by_name['Layer'] = _LAYER
DESCRIPTOR.message_types_by_name['ConvolutionLayer'] = _CONVOLUTIONLAYER
DESCRIPTOR.message_types_by_name['DropoutLayer'] = _DROPOUTLAYER
DESCRIPTOR.message_types_by_name['FlattenLayer'] = _FLATTENLAYER
DESCRIPTOR.message_types_by_name['DenseLayer'] = _DENSELAYER
DESCRIPTOR.message_types_by_name['MaxpoolingLayer'] = _MAXPOOLINGLAYER
DESCRIPTOR.message_types_by_name['ProgressUpdate'] = _PROGRESSUPDATE
_sym_db.RegisterFileDescriptor(DESCRIPTOR)

EvaluateRequest = _reflection.GeneratedProtocolMessageType('EvaluateRequest', (_message.Message,), dict(
  DESCRIPTOR = _EVALUATEREQUEST,
  __module__ = 'evaluator_pb2'
  # @@protoc_insertion_point(class_scope:evaluator.EvaluateRequest)
  ))
_sym_db.RegisterMessage(EvaluateRequest)

Layer = _reflection.GeneratedProtocolMessageType('Layer', (_message.Message,), dict(
  DESCRIPTOR = _LAYER,
  __module__ = 'evaluator_pb2'
  # @@protoc_insertion_point(class_scope:evaluator.Layer)
  ))
_sym_db.RegisterMessage(Layer)

ConvolutionLayer = _reflection.GeneratedProtocolMessageType('ConvolutionLayer', (_message.Message,), dict(
  DESCRIPTOR = _CONVOLUTIONLAYER,
  __module__ = 'evaluator_pb2'
  # @@protoc_insertion_point(class_scope:evaluator.ConvolutionLayer)
  ))
_sym_db.RegisterMessage(ConvolutionLayer)

DropoutLayer = _reflection.GeneratedProtocolMessageType('DropoutLayer', (_message.Message,), dict(
  DESCRIPTOR = _DROPOUTLAYER,
  __module__ = 'evaluator_pb2'
  # @@protoc_insertion_point(class_scope:evaluator.DropoutLayer)
  ))
_sym_db.RegisterMessage(DropoutLayer)

FlattenLayer = _reflection.GeneratedProtocolMessageType('FlattenLayer', (_message.Message,), dict(
  DESCRIPTOR = _FLATTENLAYER,
  __module__ = 'evaluator_pb2'
  # @@protoc_insertion_point(class_scope:evaluator.FlattenLayer)
  ))
_sym_db.RegisterMessage(FlattenLayer)

DenseLayer = _reflection.GeneratedProtocolMessageType('DenseLayer', (_message.Message,), dict(
  DESCRIPTOR = _DENSELAYER,
  __module__ = 'evaluator_pb2'
  # @@protoc_insertion_point(class_scope:evaluator.DenseLayer)
  ))
_sym_db.RegisterMessage(DenseLayer)

MaxpoolingLayer = _reflection.GeneratedProtocolMessageType('MaxpoolingLayer', (_message.Message,), dict(
  DESCRIPTOR = _MAXPOOLINGLAYER,
  __module__ = 'evaluator_pb2'
  # @@protoc_insertion_point(class_scope:evaluator.MaxpoolingLayer)
  ))
_sym_db.RegisterMessage(MaxpoolingLayer)

ProgressUpdate = _reflection.GeneratedProtocolMessageType('ProgressUpdate', (_message.Message,), dict(
  DESCRIPTOR = _PROGRESSUPDATE,
  __module__ = 'evaluator_pb2'
  # @@protoc_insertion_point(class_scope:evaluator.ProgressUpdate)
  ))
_sym_db.RegisterMessage(ProgressUpdate)



_EVALUATOR = _descriptor.ServiceDescriptor(
  name='Evaluator',
  full_name='evaluator.Evaluator',
  file=DESCRIPTOR,
  index=0,
  serialized_options=None,
  serialized_start=527,
  serialized_end=609,
  methods=[
  _descriptor.MethodDescriptor(
    name='Evaluate',
    full_name='evaluator.Evaluator.Evaluate',
    index=0,
    containing_service=None,
    input_type=_EVALUATEREQUEST,
    output_type=_PROGRESSUPDATE,
    serialized_options=None,
  ),
])
_sym_db.RegisterServiceDescriptor(_EVALUATOR)

DESCRIPTOR.services_by_name['Evaluator'] = _EVALUATOR

# @@protoc_insertion_point(module_scope)
