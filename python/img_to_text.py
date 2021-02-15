from types import new_class
from typing import Pattern
import cv2
import time
from os import curdir
from tensorflow import device
from keras import backend as K
from keras.models import load_model
import numpy as np
from tensorflow.python.framework.tensor_conversion_registry import get



alphabets         = u"ABCDEFGHIJKLMNOPQRSTUVWXYZ-' "
max_str_len       = 24 # max length of input labels
num_of_characters = len(alphabets) + 1 # +1 for ctc pseudo blank
num_of_timestamps = 64 # max length of predicted labels
old_href = ""

def readFromBuffer():
    buffer = open(curdir + '//buffer.txt')
    result = []
    for i in range(3):
        result.append(buffer.readline())
    buffer.close()
    return result

def writeToBuffer(text):
    buffer = open(curdir + '//buffer.txt','w')
    buffer.write(text)
    buffer.close()

def getCurrentState():
    stateLine = readFromBuffer()[0]
    cut = stateLine[8:]
    return cut.replace('\n','')

def getHref():
    stateLine = readFromBuffer()[1]
    cut = stateLine[7:]
    return cut.replace('\n','')

def change_textOnImg_in_buffer(text):
    newBuffer = "state = " + getCurrentState() + "\nhref = " + getHref() + "\ntext on image = "
    writeToBuffer(newBuffer + text)

def load_model_from_disk():

    # load weights into new model
    loaded_model = load_model('model_55.hdf5', compile=False)
    return loaded_model

def label_to_num(label):
    label_num = []
    for ch in label:
        label_num.append(alphabets.find(ch))
        
    return np.array(label_num)

def num_to_label(num):
    ret = ""
    for ch in num:
        if ch == -1:  # CTC Blank
            break
        else:
            ret+=alphabets[ch]
    return ret





def preprocess(img):
    (h, w)    = img.shape

    final_img = np.ones([64, 256])*255 # blank white image

    # crop
    if w > 256:
        img = img[:, :256]

    if h > 64:
        img = img[:64, :]


    final_img[:h, :w] = img
    return cv2.rotate(final_img, cv2.ROTATE_90_CLOCKWISE)

def strFromImg(img,loaded_model):
    img = np.array([img])
    with device("/cpu:0"):
        pred = loaded_model.predict(img)
        decode = K.get_value(K.ctc_decode(pred, input_length=np.ones(pred.shape[0])*pred.shape[1], greedy=True)[0][0])
    return num_to_label( decode[0])


def txtFromImgFromHref(href,loaded_model):
    img_dir = href
    image   = cv2.imread(img_dir, cv2.IMREAD_GRAYSCALE)
    image   = preprocess(image)
    image   = image/255.
    return strFromImg(image,loaded_model)


def hrefChanged():
    new_href = getHref()
    if old_href != new_href:
        return True
    return False

def is_c_sharp_closing():
    if getCurrentState() == "closing":
        return True
    
    return False


loaded_model = load_model_from_disk()
i = 0
while(True):
    if is_c_sharp_closing():
        break

    if not hrefChanged():
        time.sleep(0.1)
        continue
 
    old_href = getHref()
    if  old_href == "":
        time.sleep(0.1)
        continue 
    new_text_on_img = txtFromImgFromHref(old_href,loaded_model)
    change_textOnImg_in_buffer(new_text_on_img)
    time.sleep(1)



