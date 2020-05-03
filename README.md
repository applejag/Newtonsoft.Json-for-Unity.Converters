# Unity Converters for Newtonsoft.Json

[![CircleCI](https://img.shields.io/circleci/build/gh/jilleJr/Newtonsoft.Json-for-Unity.Converters/master?logo=circleci&style=flat-square)](https://circleci.com/gh/jilleJr/Newtonsoft.Json-for-Unity.Converters)
[![Codacy grade](https://img.shields.io/codacy/grade/de7041b5f9f9415a8add975d1b8a9fcf?logo=codacy&style=flat-square)](https://www.codacy.com/manual/jilleJr/Newtonsoft.Json-for-Unity.Converters?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=jilleJr/Newtonsoft.Json-for-Unity.Converters&amp;utm_campaign=Badge_Grade)
[![Contributor Covenant](https://img.shields.io/badge/Contributor%20Covenant-v2.0%20adopted-ff69b4.svg?style=flat-square)](/CODE_OF_CONDUCT.md)

This package contains converters to and from common Unity types. Types such as
Vector2, Vector3, Matrix4x4, Quaternions, Color, and more.
(See the [full compatibility table of all +50 supported Unity types][wiki-Converters-compatability-table])

The perfect complement to the [jilleJr/Newtonsoft.Json-for-Unity][jillejr.newtonsoft.json-for-unity] repo.

# ❌ NOT RELEASED YET ❌

Click the "Watch" button at the top to get an email when we release.

## Installation via Unity Package Manager

Visit the jilleJr/Newtonsoft.Json-for-Unity/wiki for installation

- [Installation via <abbr title="UPM: Unity Package Manager, included in Unity since 2018.1+">UPM</abbr>][wiki-Install-Converters-via-UPM]
- [Installation via <abbr title="OpenUPM: A very popular open source Unity package registry for UPM packages">OpenUPM</abbr> ![OpenUPM icon](Doc/images/openupm-icon-16.png)][wiki-Install-Converters-via-OpenUPM]
- [Installation via <abbr title="Git: Git is a free and open source distributed version control system.">Git</abbr> in UPM][wiki-Install-Converters-via-Git-in-UPM]

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

## Contributing

Thankful that you're even reading this :)

If you want to contribute, here's what you can do:

- **Spread the word!** ❤ More users &rarr; more feedback &rarr; I get more
  will-power to work on this project. This is the best way to contribute!

- [Open an issue][issue-create]. Could be a feature request for a new converter,
  or maybe you've found a bug?

- [Tackle one of the unassigned issues][issue-list-unassigned]. If it looks like
  a fun task to solve and no one is assigned, then just comment on it and say
  that you would like to try it out.

- Open a PR with some new feature or issue solved. Remember to ask before
  starting to work on anything, so no two are working on the same thing.

  Having a feature request or issue pop up and having the submitter suggesting
  themselves to later add a PR for a solution is the absolute greatest gift
  a repository maintainer could ever receive. 🎁

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
[wiki-Install-Converters-via-Git-in-UPM]: https://github.com/jilleJr/Newtonsoft.Json-for-Unity/wiki/Install-Converters-via-Git-in-UPM
[wiki-Install-Converters-via-UPM]: https://github.com/jilleJr/Newtonsoft.Json-for-Unity/wiki/Install-Converters-via-UPM
[wiki-Install-Converters-via-OpenUPM]: https://github.com/jilleJr/Newtonsoft.Json-for-Unity/wiki/Install-Converters-via-OpenUPM
[wiki-Converters-compatability-table]: https://github.com/jilleJr/Newtonsoft.Json-for-Unity/wiki/Converters-compatability-table
[issue-create]: https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters/issues/new/choose
[issue-list-unassigned]: https://github.com/jilleJr/Newtonsoft.Json-for-Unity.Converters/issues?q=is%3Aopen+is%3Aissue+no%3Aassignee
