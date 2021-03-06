# -*- coding: utf-8 -*-

'''Trains a simple convnet on the MNIST dataset.

Gets to 99.25% test accuracy after 12 epochs
(there is still a lot of margin for parameter tuning).
'''

from __future__ import print_function
import numpy as np
import yaml
np.random.seed(1337)

from keras.datasets import mnist
from keras.models import Sequential
from keras.layers import Dense, Dropout, Activation, Flatten
from keras.layers import Conv2D, MaxPooling2D
from keras.utils import np_utils

from keras import backend as K

batch_size = 128
nb_classes = 10
nb_epoch = 12

img_rows, img_cols = 28, 28

nb_filters = 32

pool_size = (2, 2)

kernel_size = (3, 3)

(X_train, y_train), (X_test, y_test) = mnist.load_data()

if K.image_dim_ordering() == 'th':
	X_train = X_train.reshape(X_train.shape[0], 1, img_rows, img_cols)
	X_test = X_test.reshape(X_test.shape[0], 1, img_rows, img_cols)
	input_shape = (1, img_rows, img_cols)
else:
	X_train = X_train.reshape(X_train.shape[0], img_rows, img_cols, 1)
	X_test = X_test.reshape(X_test.shape[0], img_rows, img_cols, 1)
	input_shape = (img_rows, img_cols, 1)

X_train = X_train.astype('float32')
X_test = X_test.astype('float32')
X_train /= 255
X_test /= 255
print('X_train shape:', X_train.shape)
print(X_train.shape[0], 'train samples')
print(X_test.shape[0], 'test samples')

# convert class vectors to binary class matrices
Y_train = np_utils.to_categorical(y_train, nb_classes)
Y_test = np_utils.to_categorical(y_test, nb_classes)

# reading yaml file and converting it to list
document = "yaml-v2.yaml"
dataFile = yaml.load(open(document))

layers = []
for item in dataFile:
    if '.' in item.split()[1]:
        layers.append((item.split()[0],float(item.split()[1])))
    else:
        layers.append((item.split()[0],int(item.split()[1])))
        
# print(layers)

layers = [('Conv',32),('Conv',32),('Maxpooling',1),('Dropout',0.25),('Flatten',1),('Dense',128),('Dropout',0.5)]

model = Sequential()

layerId = 0
for layer in layers:
	if layer[0] == 'Conv':
		nb_filters = layer[1]
		if layerId == 0:
			model.add(Conv2D(nb_filters, kernel_size,border_mode='valid',input_shape=input_shape))
			model.add(Activation('relu'))
		else:
			model.add(Conv2D(nb_filters, kernel_size))
			model.add(Activation('relu'))
	if layer[0] == 'Maxpooling':
		model.add(MaxPooling2D(pool_size=pool_size))
	if layer[0] == 'Dropout':
		dropVal = layer[1]	
		model.add(Dropout(dropVal))
	if layer[0] == 'Flatten':
		model.add(Flatten())
	if layer[0] == 'Dense':
		denseVal = layer[1]
		model.add(Dense(denseVal))
		model.add(Activation('relu'))
	layerId += 1
model.add(Dense(nb_classes))
model.add(Activation('softmax'))

print(model.summary())
model.compile(loss='categorical_crossentropy',optimizer='adadelta',metrics=['accuracy'])
for i in range(nb_epoch):
	model_log = model.fit(X_train, Y_train, batch_size=batch_size,epochs = 1, verbose=1, validation_data=(X_test, Y_test))
	score = model.evaluate(X_test, Y_test, verbose=0)
	print('Test score:', score[0])
	print('Test accuracy:', score[1])

model_digit_json = model.to_json()
with open('model_digit.json','w') as json_file:
	json_file.write(model_digit_json)
model.save_weights('model_digit.h5')
print('Saved model to disk')

