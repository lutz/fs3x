[Deutsch](https://github.com/lutz/fs3x/blob/master/README.md)

# fs3x

## disclaimer

> This is a private project and the use of electricity can be life-threatening. Therefore you should always take precautions and know what you are doing. Therefore there are no support claims by my person or other liability claims for problems or data loss. Any use is at your own risk. All rights to the name Digitech are owned by Harman (A SAMSUNG Company).

## goals

FS3X has the goal to use the footswitch FS3X from Digitech on a PC/Notebook with the help of an Arduino Nano. For this purpose the appropriate materials are provided here which I use myself.

## code

The following contents can be found in the [src](https://github.com/lutz/fs3x/tree/master/src):

- FS3X.Arduino (contains the sketch for the Arduino)
- FS3X.Lib (contains a small class library for evaluating the information provided by SerialComPort)
- FS3X.Tray (includes a small test application)

## material

- Arduino Nano (e.g. a replica of [Bangood](https://www.banggood.com/3Pcs-ATmega328P-Nano-V3-Controller-Board-Compatible-Arduino-Improved-Version-p-983486.html))
- 6.28 mm stereo Klinke female socket (e.g. a replica of [AliExpress](https://de.aliexpress.com/item/32767247005.html?spm=a2g0s.9042311.0.0.42014c4dqhtAB3))
- a box
- wires
- tools for soldering

## hints for the Arduino replica
I used the replica of the Arduino Nanos v3 from China by Bangood. With replicas from China it can happen that the USB/Serial converter chip is not from FTDI as with the original but a cheaper one e.g. the WCH CH340. To copy data to the Arduino you need a driver for this chip. After a long search I came across the following combination for Windows 10, which worked for me without any problems:
- driver CH340 (04.11.2011 version: 3.3.2011.11)
- Arduino IDE (version 1.6.5)

## how it works

The Sketch on the Arduino checks whether a certain voltage is applied to the analog pins (A0, A2) or not. The combination of voltage at terminal A0 and A2 then results in which switch was pressed. __Important!__ The internal pull-up resistors are activated by the sketch. If you don't want this you should use resistors in the circuit! 

## pins of Arduino

[Image of stereo klinke pin](https://de.wikipedia.org/wiki/Klinkenstecker#/media/Datei:3.5mm_jack_plug_3_norm.svg)

_socket -> Arduino_
- L -> A0 
- R -> A2
- GND > GND

## Wishes/Comments/Questions
Please post all questions, wishes and comments as an issue. I will try to answer them as much as possible.

## Sources

[FS3X circuit diagram (https://www.musiker-board.de)](https://www.musiker-board.de/threads/fs113x-behringer-fs112-goes-fs3x.486045/) 

[FS3X circuit diagram (http://schematron.org)](http://schematron.org/digitech-fs3x-wiring-diagram.html)
