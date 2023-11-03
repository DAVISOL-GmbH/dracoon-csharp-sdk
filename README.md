[![Build Status](https://travis-ci.com/dracoon/dracoon-csharp-sdk.svg?branch=master)](https://travis-ci.com/dracoon/)
[![GitHub license](https://img.shields.io/github/license/dracoon/dracoon-csharp-sdk.svg)](http://www.apache.org/licenses/LICENSE-2.0)
[![NuGet](https://img.shields.io/nuget/v/Dracoon.Sdk.svg)](https://www.nuget.org/packages/Dracoon.Sdk/)
[![NuGet downloads](https://img.shields.io/nuget/dt/Dracoon.Sdk.svg?label=nuget-downloads&colorB=F03C20)](https://www.nuget.org/packages/Dracoon.Sdk/)
![GitHub issues](https://img.shields.io/github/issues-raw/dracoon/dracoon-csharp-sdk.svg)
# DRACOON C# SDK

A library to access the DRACOON REST API.

## Fork Notice

This package is forked by DAVISOL GmbH. This fork has three main focuses:
- Make SDK platform independent by supporting .NET 8.0
- Extend SDK to provide access to more REST API routes to cover espacially management and house keeping requirements
- Keep internal dependencies up-to-date, allowing use of their recent enhancements as well as recent security and bug fixes

### .NET Standard 2.0 compliance

This package was ported by DAVISOL GmbH to .NET Standard 2.x with support up to .NET 7.0 whilst still supporting legacy .NET framework (.NET 4.7.2 and 4.8.1). Please note that we do not offer binary releases. For official releases from Dracoon please refer to the Download section below.

Support for .NET 8.0 coming soon (after official release, which is currently planned for 2023-11-14).

### Fork Dependent Requirements

As a minimum requirement, you have to use a .NET Standard 2.0 compliant .NET implementation. Refer to [Microsoft Docs](https://learn.microsoft.com/en-us/dotnet/standard/net-standard?tabs=net-standard-2-0#select-net-standard-version) for a list of compatible implementations of .NET, .NET Framework, .NET Core, Mono, Xamarin and UWP.

Also, make sure you're referencing at least the following dependencies:
1. Bouncy Castle (= 2.2.1): [nuget](https://www.nuget.org/packages/BouncyCastle/)
2. Dracoon Crypto SDK (.NET 8.0 capable fork by DAVISOL)(= 3.2.0): [GitHub](https://github.com/DAVISOL-GmbH/dracoon-csharp-crypto-sdk)
3. NewtonSoft.Json (= 13.0.3): [nuget](https://www.nuget.org/packages/Newtonsoft.Json/)
4. RestSharp (= 106.11.5): [nuget](https://www.nuget.org/packages/RestSharp/)

### Fork's License and Copyright

**Please see the [original copyright notice at the end of this document](#copyright-and-license).**

This package is originally created and maintained by DRACOON GmbH and licensed under Apache-2.0.

The enhancements in this fork are done by DAVISOL GmbH. We also publish the full source code under Apache-2.0 license.

Copyright DRACOON GmbH. All rights reserved.\
Copyright 2021 DAVISOL GmbH. All rights reserved.

## Migration from 2.x versions

The 2.x branches and releases of this fork relied on SkiaSharp as a replacement for the Windows-only System.Drawing.Common library. Following the recent changes in the official SDK implementation, the user avatar routes are now working with an agnostic byte array. **All references to the SkiaSharp dependencies are removed with version 3.2**. Now the consumer of the avatar routes is responsible to implement image processing based on the raw image data.

The following examples show how to read and update the avatar with the previously used [SkiaSharp library](https://www.nuget.org/packages/SkiaSharp/).

### Read avatar images with SkiaSharp (example)

```
// client is assumed to be a valid, authenticated instance of DracoonClient
var avatarImageBytes = client.Account.GetAvatar();	// returns a byte[]
SkiaSharp.SKData avatarImage = SkiaSharp.SKData.CreateCopy(avatarImageBytes);
```

### Update avatar image with SkiaSharp (example)

```
SkiaSharp.SKData avatarImage = [avatar image];
ReadOnlySpan<byte> avatarBytes = avatarImage.AsSpan();
// client is assumed to be a valid, authenticated instance of DracoonClient
client.Account.UpdateAvatar(avatarBytes.ToArray());
```

## Setup

#### Minimum Requirements

.NET Standard 2.0
API version: 4.44.0

#### Download

##### NuGet
In nuget, you can find the DRACOON SDK [here](https://www.nuget.org/packages/Dracoon.Sdk/).

If you are using NuGet with package management "Packages.config", then edit your project's "packages.config" and add this to the packages section:
```xml
<package id="Dracoon.Sdk.Net8" version="3.2.0" />
```
If you are using Visual Studio 2017 (or higher) and you are using NuGet with package management "PackageReference" then edit your .csproj file and add this to the package dependency group:
```xml
<PackageReference Include="Dracoon.Sdk.Net8" Version="3.2.0" />
```

Note that you also need to include the following dependencies:
1. Bouncy Castle Provider (v2.2.1): https://www.nuget.org/packages/BouncyCastle.Cryptography
2. Dracoon Crypto SDK (v3.1.0): https://www.nuget.org/packages/Dracoon.Crypto.Sdk/
3. NewtonSoft.Json (v13.0.3): https://www.nuget.org/packages/Newtonsoft.Json/
4. RestSharp (v106.15.0): https://www.nuget.org/packages/RestSharp/

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

Copyright ©2021 Dracoon GmbH. All rights reserved.

Licensed under the Apache License, verison 2.0 (the "License"); you may not use this file except in compliance with the License. You may optain a copy of the License at

http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software distributed under the License is
distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
implied. See the License for the specific language governing permissions and limitations under the
License.