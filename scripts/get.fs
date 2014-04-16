﻿/// Downloads all dependencies used by project
open System
open System.IO
open System.Diagnostics
open System.Net

let nuget = Path.GetFullPath("nuget.exe")
let packages = Path.Combine(System.Environment.CurrentDirectory,"../packages/")

printfn "Start fetching dependencies"
printfn "Nuget path: %s" nuget
printfn "Out folder: %s" packages

let cmd pack ver = "install " + pack.ToString() + " -OutputDirectory " +  packages + " -Version " + ver.ToString()

// downloads dependencies used via nuget
// to unpack archive on pre .NET 4.5
Process.Start(nuget,cmd "DotNetZip" "1.9.2" ).WaitForExit()
//for tests
Process.Start(nuget,cmd "NRegFreeCom" "0.1.4.1").WaitForExit()
Process.Start(nuget,cmd "TestStack.White" "0.12.0").WaitForExit()

//download autoitx
let wget = new WebClient()
wget.Headers.Add("User-Agent: Other")//fixes 403 Forbidden
let zip = "autoit-v3.zip"
//TODO: download licesehttp://www.autoitscript.com/autoit3/docs/license.htm
let autoit = "http://www.autoitscript.com/cgi-bin/getfile.pl?autoit3/" + zip
printfn "Start downloading: %s" autoit
// unpack 
let zipPath = Path.Combine(packages,zip)
wget.DownloadFile(autoit,zipPath)