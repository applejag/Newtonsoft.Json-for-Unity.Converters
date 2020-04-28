# Unity Converters for Newtonsoft.Json

[![CircleCI](https://img.shields.io/circleci/build/gh/jilleJr/Newtonsoft.Json-for-Unity.Converters/master?logo=circleci&style=flat-square)](https://circleci.com/gh/jilleJr/Newtonsoft.Json-for-Unity.Converters)
[![Codacy grade](https://img.shields.io/codacy/grade/de7041b5f9f9415a8add975d1b8a9fcf?logo=codacy&style=flat-square)](https://www.codacy.com/manual/jilleJr/Newtonsoft.Json-for-Unity.Converters?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=jilleJr/Newtonsoft.Json-for-Unity.Converters&amp;utm_campaign=Badge_Grade)
[![Contributor Covenant](https://img.shields.io/badge/Contributor%20Covenant-v2.0%20adopted-ff69b4.svg?style=flat-square)](/CODE_OF_CONDUCT.md)

This package contains converters to and from common Unity types. Types such as
Vector2, Vector3, Matrix4x4, Quaternions, Color, and more.

The perfect complement to the [jilleJr/Newtonsoft.Json-for-Unity][jillejr.newtonsoft.json-for-unity] repo.

# ❌ NOT RELEASED YET ❌

Click the "Watch" button at the top to get an email when we release.

## Installation via Unity Package Manager

Visit the jilleJr/Newtonsoft.Json-for-Unity/wiki for installation

- [Installation via <abbr title="UPM: Unity Package Manager, included in Unity since 2018.1+">UPM</abbr>][wiki-Install-Converters-via-UPM]
- [Installation via <abbr title="OpenUPM: A very popular open source Unity package registry for UPM packages">OpenUPM</abbr> ![OpenUPM icon](Doc/images/openupm-icon-16.png)][wiki-Install-Converters-via-OpenUPM]

## Versioning format

**Not using semantic versioning.** As Unity does not support assembly binding
redirects, this repo was forced to have multiple releases one for each version
of Newtonsoft.Json.

As Newtonsoft.Json assemblies only have major version defined
(ex: 12.0.1, 12.0.2, and 12.0.3 all technically have assembly version 12.0.0.0)
then we are able to abuse that and only having to re-publish this package once
for every major Json .NET version.

Therefore, the major version is reserved to mimic the Newtonsoft.Json major
version. As such, we're masking out the major in our versions.

- The first release of Newtonsoft.Json-for-Unity.Converters is `x.1.0`.
- To use together with Newtonsoft.Json 12.0.3, use the UPM version `12.1.0`

## Changelog

Please see the [CHANGELOG.md][changelog.md] file inside this package.

---

This package is licensed under The MIT License (MIT)

Copyright (c) 2019 Kalle Jillheden (jilleJr)  
<https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters>

See full copyrights in [LICENSE.md][license.md] inside repository

[license.md]: /LICENSE.md
[changelog.md]: /CHANGELOG.md
[jillejr.newtonsoft.json-for-unity]: https://github.com/jilleJr/Newtonsoft.Json-for-Unity#readme
[wiki-Install-Converters-via-UPM]: https://github.com/jilleJr/Newtonsoft.Json-for-Unity/wiki/Install-Converters-via-UPM
[wiki-Install-Converters-via-OpenUPM]: https://github.com/jilleJr/Newtonsoft.Json-for-Unity/wiki/Install-Converters-via-OpenUPM
