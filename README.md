<!-- ── Language switch (RU active) ──────────────────────────────────── -->
<div align="left" style="margin:0 0 14px 0;">

  <span style="display:inline-block;
               padding:.28rem .6rem;
               border:1px solid rgba(0,0,0,.18);
               border-radius:10px 0 0 10px;
               font-weight:400;
               font-size:12px;
               letter-spacing:.06em;
               color:#111827;
               background:linear-gradient(180deg,#e9edf2,#ffffff);
               box-shadow:inset 0 2px 6px rgba(0,0,0,.10);">
    RU
  </span><span style="display:inline-block;
               margin-left:-1px;
               padding:.28rem .6rem;
               border:1px solid rgba(0,0,0,.14);
               border-radius:0 10px 10px 0;
               font-weight:400;
               font-size:12px;
               letter-spacing:.06em;
               background:linear-gradient(180deg,#ffffff,#f3f4f6);
               box-shadow:0 1px 0 rgba(0,0,0,.06);">
    [EN][en]
  </span>

</div>
<!-- ────────────────────────────────────────────────────────────────── -->

> ⚠️ Не используйте кнопку "Код → Скачать" на сайте GitFlic – этот метод не загружает файлы из Git LFS. [Инструкция по клонированию](README_CLONE.md).

### Unity-плагин RuStore для обновления приложения

#### [🔗 Документация разработчика][10]

Плагин “RuStoreAppUpdateManager” помогает поддерживать актуальную версию вашего приложения на устройстве пользователя.

Репозиторий содержит плагины “RuStoreAppUpdateManager” и “RuStoreCore”, а также демонстрационное приложение с примерами использования и настроек. Поддерживаются версии Unity 6000+.

#### Сборка примера приложения

Вы можете ознакомиться с демонстрационным приложением содержащим представление работы всех методов sdk:
- [appupdate_example](https://gitflic.ru/project/rustore/unity-rustore-appupdate-sdk/file?file=appupdate_example) — демонстрационный проект на Unity 6000.0.66f2 (может быть автоматически сконвертирован на более поздние версии Unity).

#### Подключение в проект

**Из сетевого расположения (рекомендуется)**

Пакеты RuStore публикуются в npm-registry и подключаются к проекту через Package Manager без ручного скачивания архивов.

1. Откройте настройки: **Edit → Project Settings → Package Manager**.
2. В разделе **Scoped Registries** нажмите **+** и заполните поля:
   - **Name** — `RuStore Nexus`.
   - **URL** — `https://nexus-external.rustore.ru/repository/npm-unity-rustore-exposed/`.
   - **Scopes** — `ru.rustore`.
3. Откройте **Window → Package Manager** — в списке источников появится реестр **RuStore Nexus**.
4. Выберите **RuStore Nexus** и установите пакет `ru.rustore.update` кнопкой **Install**. Зависимость `ru.rustore.core` установится автоматически.

**Из локального расположения**

**Установка через Package Manager**

1. Для подключения скачайте со страницы [релизов][20] пакеты:
   - `ru.rustore.core-version.tgz`.
   - `ru.rustore.update-version.tgz`.
2. Импортируйте пакеты в проект через **Package Manager** (**Window → Package Manager → __+__ → Add package from tarball...**).

**Установка через \*.unitypackage**

1. Скачайте файл `RuStoreUnityAppUpdateSDK-version.unitypackage` со страницы [релизов][20].
2. Импортируйте его в проект (**Assets → Import Package → Custom Package...**).

**Клонирование репозитория**

1. Для установки из исходного кода воспользуйтесь [инструкцией по клонированию](README_CLONE.md).

Для каждого артефакта в релизе доступны файлы контрольных сумм (`.sha256`) и цифровой подписи (`.sig`), которые могут использоваться для проверки целостности и подлинности артефакта после скачивания.

> **Подсказка**
>
> Если вы используете операционную систему macOS, измените настройки утилиты архивации. В настройках **Archive Utility** снимите флажок **Keep expanding if possible**. В противном случае архив проекта будет скачан некорректно.

#### Настройка проекта

Для корректной обработки зависимостей SDK выполните следующие настройки.

1. Откройте настройки проекта: **Edit → Project Settings → Player → Android Settings**.
2. В разделе **Publishing Settings** включите настройки:
   - Custom Main Manifest.
   - Custom Main Gradle Template.
   - Custom Gradle Properties Template.
3. В разделе **Other Settings** настройте:
   - Package name.
   - Minimum API Level = 24.
   - Target API Level = 34.

#### Подключение зависимостей

После установки обновите зависимости проекта с помощью [**External Dependency Manager**](README_EDM.md): **Assets → External Dependency Manager → Android Resolver → Force Resolve**.

#### История изменений

[CHANGELOG](CHANGELOG.md)

#### Условия распространения

Данное программное обеспечение, включая исходные коды, бинарные библиотеки и другие файлы, распространяется под лицензией MIT. Информация о лицензировании доступна в документе [MIT-LICENSE](MIT-LICENSE.txt).

#### Техническая поддержка

Дополнительная помощь и инструкции доступны в [документации RuStore](https://www.rustore.ru/help/) и по электронной почте support@rustore.ru.

[10]: https://www.rustore.ru/help/sdk/updates/unity/10-5-1
[20]: https://gitflic.ru/project/rustore/unity-rustore-appupdate-sdk/release

[en]: README.en.md
