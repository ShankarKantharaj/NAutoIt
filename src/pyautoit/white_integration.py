﻿
#IronPython case use other .NET testing framework like MS UI Automation or White

import sys
import os
import clr

clr.AddReferenceToFile("nautoit.dll")   

clr.AddReferenceToFile("TestStack.White.dll")     

from nautoit import au
from  TestStack.White import Application
from  TestStack.White.InputDevices import Keyboard

application = Application.Launch("notepad.exe");
window = application.GetWindow("Untitled - Notepad");
window.Focus()
Keyboard.Instance.Enter("This is some text.");
window.Close()
#Allows step by step migration from AutoIt to anything else
close = au.WinWaitActive("Notepad", "Save")
au.Send("!n")
