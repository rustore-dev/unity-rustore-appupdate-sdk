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

## Change Log

### Master branch
- Updated Maven repository to https://nexus-external.rustore.ru/repository/maven-rustore-exposed.
- Updated npm registry to https://nexus-external.rustore.ru/repository/npm-unity-rustore-exposed.

### Release 10.5.1
- AppUpdate SDK version 10.5.1.
- Added `link.xml` with `preserve="all"` to protect against Managed Code Stripping.
- Added ProGuard/R8 rules in `consumer-rules.pro` to protect JNI bridge from minification.
- RuStore packages are now available through the npm registry.
- Updated Maven repository to `https://nexus-external.vkteam.ru/repository/maven-rustore-exposed`.

### Release 10.5.0
- AppUpdate SDK version 10.5.0.

### Release 10.3.1
- AppUpdate SDK version 10.3.1.

### Release 10.3.0
- AppUpdate SDK version 10.3.0.

### Release 10.2.0
- AppUpdate SDK version 10.2.0.
- The package has been tested and is supported on Unity 6000+.

### Release 10.1.0
- AppUpdate SDK version 10.1.0.

### Release 10.0.0
- AppUpdate SDK version 10.0.0.

### Release 9.1.0
- AppUpdate SDK version 9.1.0.
- Fixed namespace declaration in RuStoreSDKSettings.androidlib Android manifest.

### Release 9.0.2
- AppUpdate SDK version 9.0.2.

### Release 9.0.1
- AppUpdate SDK version 9.0.1.

### Release 8.0.0
- AppUpdate SDK version 8.0.0.

### Release 7.0.0
- AppUpdate SDK version 7.0.0.

### Release 6.1.0
- AppUpdate SDK version 6.1.0.
- RuStoreSDK moved to a separate assembly.

### Release 6.0.0
- AppUpdate SDK version 6.+.
- Repository structure changed.
- Added project with source code of `.aar` packages.

### Release 3.0.0
- AppUpdate SDK version 3.+.

### Release 2.0.0
- AppUpdate SDK version 2.+.

### Release 0.2.1
- Fixed SDK dependencies.

### Release 0.2.0
- AppUpdate SDK version 0.2.0.

[ru]: CHANGELOG.md
[en]: CHANGELOG.en.md
