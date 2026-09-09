<!-- ── Language switch (EN active) ──────────────────────────────────── -->
<div align="left" style="margin:0 0 14px 0;">

  <span style="display:inline-block;
               padding:.28rem .6rem;
               border:1px solid rgba(0,0,0,.18);
               border-radius:10px 0 0 10px;
               font-weight:400;
               font-size:12px;
               letter-spacing:.06em;
               color:#111827;
               background:linear-gradient(180deg,#ffffff,#f3f4f6);
               box-shadow:0 1px 0 rgba(0,0,0,.06);">
    [RU][ru]
  </span><span style="display:inline-block;
               margin-left:-1px;
               padding:.28rem .6rem;
               border:1px solid rgba(0,0,0,.14);
               border-radius:0 10px 10px 0;
               font-weight:400;
               font-size:12px;
               letter-spacing:.06em;
               background:linear-gradient(180deg,#e9edf2,#ffffff);
               box-shadow:inset 0 2px 6px rgba(0,0,0,.10);">
    EN
  </span>

</div>
<!-- ────────────────────────────────────────────────────────────────── -->

> ⚠️ Do not use the "Code → Download" button on the GitFlic website – this method does not download files from Git LFS. [Cloning instructions](README_CLONE.en.md).

### Unity Plugin RuStore for App Updates

#### [🔗 Developer Documentation][10]

The "RuStoreAppUpdateManager" plugin helps keep your app up-to-date on the user's device.

The repository contains the "RuStoreAppUpdateManager" and "RuStoreCore" plugins, as well as a demo application with examples of usage and settings. Supports Unity 6000+.

#### Building the Demo Application

You can explore the demo application containing an overview of all SDK methods:
- [appupdate_example](https://gitflic.ru/project/rustore/unity-rustore-appupdate-sdk/file?file=appupdate_example) — a Unity 6000.0.66f2 demo project (can be automatically converted to newer Unity versions).

#### Connecting to the Project

**From a network location (recommended)**

RuStore packages are published to an npm registry and can be added to the project through Package Manager without manually downloading archives.

1. Open the settings: **Edit → Project Settings → Package Manager**.
2. In the **Scoped Registries** section, click **+** and fill in the fields:
   - **Name** — `RuStore Nexus`.
   - **URL** — `https://nexus-external.rustore.ru/repository/npm-unity-rustore-exposed/`.
   - **Scopes** — `ru.rustore`.
3. Open **Window → Package Manager**. The **RuStore Nexus** registry will appear in the list of sources.
4. Select **RuStore Nexus** and install the `ru.rustore.update` package by clicking **Install**. The `ru.rustore.core` dependency will be installed automatically.

**From a local location**

**Installing via Package Manager**

1. Download the following packages from the [releases page][20]:
   - `ru.rustore.core-version.tgz`.
   - `ru.rustore.update-version.tgz`.
2. Import the packages into the project via **Package Manager** (**Window → Package Manager → __+__ → Add package from tarball...**).

**Installing via \*.unitypackage**

1. Download the `RuStoreUnityAppUpdateSDK-version.unitypackage` file from the [releases page][20].
2. Import it into the project (**Assets → Import Package → Custom Package...**).

**Cloning the Repository**

To install from source code, follow the [cloning instructions](README_CLONE.en.md).

For each release artifact, checksum (`.sha256`) and digital signature (`.sig`) files are available and can be used to verify the artifact's integrity and authenticity after downloading.

> **Tip**
>
> If you use macOS, change the archive utility settings. In **Archive Utility**, clear the **Keep expanding if possible** checkbox. Otherwise, the project archive may be downloaded incorrectly.

#### Project Setup

Configure the following settings for the SDK dependencies to work correctly.

1. Open the project settings: **Edit → Project Settings → Player → Android Settings**.
2. In the **Publishing Settings** section, enable:
   - Custom Main Manifest.
   - Custom Main Gradle Template.
   - Custom Gradle Properties Template.
3. In the **Other Settings** section, configure:
   - Package name.
   - Minimum API Level = 24.
   - Target API Level = 34.

#### Connecting Dependencies

After installation, update the project dependencies using [**External Dependency Manager**](README_EDM.en.md): **Assets → External Dependency Manager → Android Resolver → Force Resolve**.

#### Change Log

[CHANGELOG](CHANGELOG.en.md)

#### Licensing Terms

This software, including source codes, binary libraries, and other files, is distributed under the MIT license. Licensing information is available in the [MIT-LICENSE](MIT-LICENSE.txt) document.

#### Technical Support

Additional help and instructions are available in the [RuStore documentation](https://www.rustore.ru/help/en/) and by email at support@rustore.ru.

[10]: https://www.rustore.ru/help/en/sdk/updates/unity/10-5-1
[20]: https://gitflic.ru/project/rustore/unity-rustore-appupdate-sdk/release

[ru]: README.md
[en]: README.en.md
