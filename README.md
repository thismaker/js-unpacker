# JsUnpacker

This is a simple JavaScript unpacker that unpacks scripts that were packed by Dean Edward's packer.
It is based off the unpacker written by [rkaradas
](https://github.com/rkaradas/php-javascript-unpacker/blob/master/inc/JavaScriptUnpacker.php).


## Usage
To use the unpacker, simply install the nuget package:

```
Package Manager:
Install-Package Thismaker.JsUnpacker

.NET CLI:
dotnet add package Thismaker.JsUnpacker
```

Then use the following code to unpack a script:

```cs
using Thismaker.JsUnpacker;

string unpacked = JsUnpacker.Unpack("packed script here");
```