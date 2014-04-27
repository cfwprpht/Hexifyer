
******************
*~~Hexifyer~~v1.0*
******************

--------------------
by cfwprpht (c) 2014
--------------------

What it is?
-----------
A Tool to convert strings of Hex Decimal "12FE4A852F" Values to a Hexifyed "0x12, 0xFE, 0x4A, 0x85, 0x2F, " Hex Decimal Value
 and Vice-Verca. Simpli.
 
It also hase Drag&Drop and you can DD a file to hexify into the GUI. Even more you can set a config file
for some standarts you may want to use. Just put the conf file into the same dir of the app or DD it into the GUI.


How does the config file work?
------------------------------
Create a File named "hexifyer.conf" and add following lines to it:

staticFile=C:\Path\To\Your\File\.txt
allignTo16=true
lowerToUpper=true
NoNewFile=false
deHexify=false
closeApp=false

The staticFile variable is used to define a file which you quickly can Past and Copy the Value to Hexify or DeHexify.
All others vars should be self explained.