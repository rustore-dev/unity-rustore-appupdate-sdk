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

> ⚠️ Do not use the "Code → Download" button on the GitFlic website – this method does not download files from Git LFS. [Cloning instructions](../README_CLONE.md).

### Unity plugin for RuStore app updates

#### [🔗 Developer documentation][10]

#### SDK requirements

To work with the RuStore In-app updates SDK, the following conditions must be met:

- Android OS version 7.0 or higher.
- RuStore is installed on the user's device.
- The latest version of RuStore is installed on the user's device.
- RuStore is allowed to install applications.

#### Preparing required parameters

Before setting up the sample application, prepare the following data.

- `applicationId` — a unique identifier of the application in the Android system in reverse domain name format (e.g., ru.rustore.sdk.example).
- `*.keystore` — a key file used for [signing and authenticating an Android application](https://www.rustore.ru/help/developers/publishing-and-verifying-apps/app-publication/apk-signature/).

#### Setting up the sample application

1. Open the **Unity** project from the `appupdate_example_6000` folder.
1. Open the **AppUpdateSampleScene** scene from the `Assets / RuStoreAppUpdateExample / Scenes` folder.
1. In the **Publishing Settings** section (**Edit → Project Settings → Player → Android Settings**), select the **Custom Keystore** option and set the **Path / Password**, **Alias / Password** for the prepared `*.keystore` file.
1. In the **Other Settings** section (**Edit → Project Settings → Player → Android Settings**), configure the **Identification** section by checking the **Override Default Package Name** option and specifying the `applicationId` in the **Package Name** field.
1. Build the project using the **Build** command (**File → Build Settings**) and verify the application functionality.

#### Usage scenario

##### Checking for updates

Tap the `Get AppUpdateInfo` button to perform the [check for available updates][20] procedure.

![Checking for updates](images/01_get_app_update_info.png)

##### Starting update download

Tap the `Start flexible update` button to initiate the [download of an update][30] procedure.

![Starting update download](images/02_start_update_flow_delayed.png)

##### Installing the update

Tap the `Complete flexible update` button to perform the [installation of the update][40] procedure.

![Installing the update](images/03_complete_update.png)

#### Changelog

[CHANGELOG](../CHANGELOG.md)

#### Licensing terms

This software, including source codes, binary libraries, and other files, is distributed under the MIT license. Licensing information is available in the [MIT-LICENSE](../MIT-LICENSE.txt) document.

#### Technical support

Additional help and instructions are available in the [RuStore documentation](https://www.rustore.ru/help/en/) and via email at support@rustore.ru.

[10]: https://www.rustore.ru/help/en/sdk/updates/unity/10-5-1
[20]: https://www.rustore.ru/help/en/sdk/updates/unity/10-5-1#checkavailable
[30]: https://www.rustore.ru/help/en/sdk/updates/unity/10-5-1#scenariodelayedupdate
[40]: https://www.rustore.ru/help/en/sdk/updates/unity/10-5-1#installupdateflexible

[ru]: README.md
[en]: README.en.md
