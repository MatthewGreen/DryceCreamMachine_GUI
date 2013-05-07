# Dryce Cream Machine GUI
---------------------------------------
**@Author Matthew Green**

## Purpose & Usage
---------------------------------------
This code, the C# Window Application and the Arduino .ino file are used in conjunction to send information from the C# window as 0s and 1s to be interpretted and used by the Arduino microController to do *whatever* with. The Arduino code sends a signal back when the process is completed - the C# code handles this action and resets the serial port to do it again, gracefully.