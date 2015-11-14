# SGEnviro
An unofficial C# Portable Class Library for Singapore's [National Environment Agency](https://www.nea.gov.sg/api) API. Compatible with .NET 4.5, Silverlight 5, Windows 8, Windows Phone 8.1, and Windows Phone Silverlight 8 (and up - Universal Windows Apps should work too.)

Currently supports retrieving the PSI Update and PM2.5 Update datasets.

## Installation
[NuGet](https://www.nuget.org/packages/SGEnviro/): `Install-Package SGEnviro`

## New in Version 1.0
* This is the initial release of the PCL, supporting the PSI and PM2.5 Update datasets.

## Quick Start
If you haven't already, grab an API key from [the NEA site.](https://www.nea.gov.sg/api)

Initialize the API by:
```C#
using SGEnviro;
...

var api = new SGEnviroApi("YOUR API KEY HERE");
// Check further examples below.
...
```

### Retrieving 3-hour PSI Readings
```C#
// At the top,
using SGEnviro.Forecasts;

...

// Then, after initializing the API object:

PsiUpdate result = await api.GetPsiUpdateAsync();

...
```

The results are broken down per region, and presented with more human-friendly names (compared to those given in the API):

![](http://imgur.com/SHpvLtk)

### Retrieving 1-hour PM2.5 Readings
```C#
// At the top,
using SGEnviro.Forecasts;

...

// Then, after initializing the API object:

Pm25Update result = await api.GetPm25UpdateAsync();

...
```

Just as with 3-hour PSI, results are broken down per region (minus "National", which isn't provided for PM2.5).

![](http://imgur.com/qnm6iqR)

## Dependencies
    Microsoft.Bcl (1.1.10)
    Microsoft.Bcl.Async (1.0.168)
    Microsoft.Bcl.Build (1.0.21)
    Microsoft.Net.Http (2.2.29)

## Tests
Tests are written using the Visual Studio Unit Testing Framework. To run them, a valid API key must be added to the `App.config` file in the `SGEnviroTest` folder.