[![Build Status](https://travis-ci.com/dracoon/dracoon-csharp-sdk.svg?branch=master)](https://travis-ci.com/dracoon/)
[![GitHub license](https://img.shields.io/github/license/dracoon/dracoon-csharp-sdk.svg)](http://www.apache.org/licenses/LICENSE-2.0)
[![NuGet](https://img.shields.io/nuget/v/Dracoon.Sdk.svg)](https://www.nuget.org/packages/Dracoon.Sdk/)
[![NuGet downloads](https://img.shields.io/nuget/dt/Dracoon.Sdk.svg?label=nuget-downloads&colorB=F03C20)](https://www.nuget.org/packages/Dracoon.Sdk/)
![GitHub issues](https://img.shields.io/github/issues-raw/dracoon/dracoon-csharp-sdk.svg)
# DRACOON C# SDK

A library to access the DRACOON REST API.

## Fork Notice

This package is forked by DAVISOL GmbH. This fork has three main focuses:
- Make SDK platform independent by supporting .NET 5.0 (update to .NET 6.0 is planned for near future)
- Extend SDK to provide access to more REST API routes to cover espacially management and house keeping requirements
- Keep internal dependencies up-to-date, allowing use of their recent enhancements as well as recent security and bug fixes

### .NET 5.0 compliance

To assure multi-platform support, we had updated the package's projects to .NET 5.0. We've dropped support for legacy .NET versions (up to 4.x.y) as well as support for .NET Standard 2.x. Additionally, references to `System.Drawing.Common` were removed and image functionality (for avatars only) is now based on [SkiaSharp]().

A [.NET Standard 2.0 compliant version](https://github.com/shuebner20/dracoon-csharp-sdk/tree/netstandard) is also available. Please note, that we've stopped working on that branch. 

Learn more about our decision to generally move away from System.Drawing.Common [here](https://docs.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only).

### Fork Dependent Requirements

First of all, if you wan't to use this package, you *MUST* use .NET 5.0.

Also, make sure you're referencing at least the following dependencies:
1. Bouncy Castle (= 1.9.0): [nuget](https://www.nuget.org/packages/BouncyCastle/)
2. Dracoon Crypto SDK (.NET 5.0 fork by DAVISOL)(= 2.1.0): [GitHub](https://github.com/DAVISOL-GmbH/dracoon-csharp-crypto-sdk)
3. NewtonSoft.Json (= 13.0.1): [nuget](https://www.nuget.org/packages/Newtonsoft.Json/)
4. RestSharp (= 106.11.5): [nuget](https://www.nuget.org/packages/RestSharp/)
5. SkiaSharp (= 2.80.3): [nuget](https://www.nuget.org/packages/SkiaSharp/)

The dependency to `System.Drawing.Common` does not exist any longer, as its functionality was fully replaced by SkiaSharp.

### Fork's License and Copyright

This package is originally created and maintained by DRACOON GmbH and licensed under Apache-2.0.

The enhancements in this fork are done by DAVISOL GmbH. We'll also publish the full source code under Apache-2.0 license.

Copyright 2021 DAVISOL GmbH. All rights reserved.

**Please see the [original copyright notice at the end of this document](#copyright-and-license).**

## Setup

#### Minimum Requirements

.NET version: 5.0\
API version: 4.11.0

#### Download

##### NuGet
In nuget, you can find the DRACOON SDK [here](https://www.nuget.org/packages/Dracoon.Sdk/).

If you are using NuGet with package management "Packages.config", then edit your project's "packages.config" and add this to the packages section:
```xml
<package id="Dracoon.Sdk.Net5" version="2.1.0-beta3" />
```
If you are using Visual Studio 2017 (or higher) and you are using NuGet with package management "PackageReference" then edit your .csproj file and add this to the package dependency group:
```xml
<PackageReference Include="Dracoon.Sdk.Net5" Version="2.1.0-beta3" />
```

Note that you also need to include the following dependencies (see fork notices above):
1. Bouncy Castle (= 1.8.6.1): [nuget](https://www.nuget.org/packages/BouncyCastle/)
2. Dracoon Crypto SDK (= 2.1.0): [nuget](https://www.nuget.org/packages/Dracoon.Crypto.Sdk/)
3. NewtonSoft.Json (= 12.0.3): [nuget](https://www.nuget.org/packages/Newtonsoft.Json/)
4. RestSharp (= 106.11.5): [nuget](https://www.nuget.org/packages/RestSharp/)

## Example

A full example of the SDK usage can be found [here](DracoonSdkExample/DracoonExamples.cs).\
A full example of the OAuth usage can be found [here](DracoonSdkExample/OAuthExamples.cs).

The following example shows how simple the SDK can be used. It shows how to get all root rooms.

```c#
DracoonAuth auth = new DracoonAuth("access-token");

DracoonClient client = new DracoonClient(new Uri("https://dracoon.team"), auth);

NodeList resultList = client.Nodes.GetNodes();
foreach (Node currentNode in resultList.Items) {
	Console.WriteLine("NodeId: " + currentNode.Id + "; NodeName: " + currentNode.Name);
}
```

## Documentation

Documentation of all public classes and methods are provided through the standard `<summary></summary>` xml tags. 
The easiest way to view these is through Visual Studio's built in "Object Browser" (VIEW -> Object Browser, or CTRL+W, J).

## Contribution

If you would like to contribute code, fork the repository and send a pull request. We don't use the GitHub Flow, so please create a feature branch of the develop branch and make your changes there.

## Copyright and License

Copyright DRACOON GmbH. All rights reserved.

Licensed under the Apache License, verison 2.0 (the "License"); you may not use this file except in compliance with the License. You may optain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software distributed under the License is
distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
implied. See the License for the specific language governing permissions and limitations under the
License.