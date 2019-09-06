[ENGLISH](https://github.com/lutz/fs3x/blob/master/i18n/README.en.md)

# fs3x

## Disclaimer

>Dies ist ein Privatprojekt und der Umgang mit Strom kann lebensgefährlich sein. Daher sollte man im Umgang damit immer Vorsicht walten lassen und wissen was man tut. Daher bestehen keine Supportansprüche durch meine Person oder sonstige Haftungsansprüche bei Problemen oder Datenverlust. Jegliche Nutzung erfolgt auf eigene Gefahr hin. Alle Rechte am Namen **Digitech** liegen bei **Harman (A SAMSUNG Company)**.

## Projektziel

FS3X hat das Ziel unter Zuhilfenahme eines Arduino Nanos den Fusschalter FS3X von Digitech an einem PC/Notebook nutzen zu können. Dazu werden hier die entsprechenden Materialien bereitgestellt die ich selbst dafür nutze.

## Code

Im [src](https://github.com/lutz/fs3x/tree/master/src) sind folgende Inhalte zu finden:
- FS3X.Arduino (Beinhaltet den Sketch für den Arduino)
- FS3X.Lib (Beinhaltet eine kleine Klassenbibliothek zur Auswertung der über SerialComPort gelieferten Informationen) 
- FS3X.Tray (Beinhaltet eine kleine Testanwendung)

## Material

- Arduino Nano (z.B. ein Nachbau von [Bangood](https://www.banggood.com/3Pcs-ATmega328P-Nano-V3-Controller-Board-Compatible-Arduino-Improved-Version-p-983486.html))
- 6.28 mm Stereo Klinke female Buchse (z.B. von [AliExpress](https://de.aliexpress.com/item/32767247005.html?spm=a2g0s.9042311.0.0.42014c4dqhtAB3))
- eine Box
- bissel Kabel
- Werkzeug zum Löten usw.

## Hinweise zum Arduino Nachbau

Ich habe den Nachbau des Arduino Nanos v3 aus China von Bangood genutzt. Bei Nachbauten aus China kann es vorkommen dass der USB/Seriell Wandler Chip nicht von FTDI wie beim Original ist sondern ein günstigerer z.B. der WCH CH340. Um Daten auf den Arduino darüber zu kopieren, benötigt man einen Treiber für diesen Chip. Nach längerer Suche bin ich für Windows 10 auf folgende Kombination gestossen, die dann bei mir ohne Probleme funktioniert hat:
- Treiber CH340 (04.11.2011 Version: 3.3.2011.11)
- Arduino IDE (Version 1.6.5)

## Funktionsweise

Der Sketch auf dem Arduino prüft ob an den analogen Anschlusspins (A0, A2) eine bestimmte Spannung anliegt oder nicht. Die Kombination aus Spannung am Anschluss A0 und A2 ergibt dann welcher Schalter gedrückt wurde. __Wichtig!__ Die internen Pull-Up Wiederstände werden durch den Sketch mit aktiviert. Wenn man dies nicht möchte sollte man entsprechende Widerstände in der Schaltung verwenden! 

## Anschlüsse des Arduinos

[Bild: Stereo Klinkestecker ](https://de.wikipedia.org/wiki/Klinkenstecker#/media/Datei:3.5mm_jack_plug_3_norm.svg)

_Buchse -> Arduino_
- L -> A0 
- R -> A2
- GND -> GND


## Wünsche/Kommentare/Frage

Bitte sämtliche Fragen, Wünsche und Kommentare als Issue posten. Ich werde versuchen diese soweit wie möglich zu beantworten.

## Quellen

[FS3X Schaltplan (https://www.musiker-board.de)](https://www.musiker-board.de/threads/fs113x-behringer-fs112-goes-fs3x.486045/) 

[FS3X Schaltplan (http://schematron.org)](http://schematron.org/digitech-fs3x-wiring-diagram.html)
