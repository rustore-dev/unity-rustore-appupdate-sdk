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

> ⚠️ Не используйте кнопку "Код → Скачать" на сайте GitFlic – этот метод не загружает файлы из Git LFS. [Инструкция по клонированию](../README_CLONE.md).

### Unity-плагин RuStore для обновления приложения

#### [🔗 Документация разработчика][10]

#### Условия работы SDK

Для работы RuStore In-app updates SDK необходимо соблюдение следующих условий:

- ОС Android версии 7.0 или выше.
- На устройстве пользователя установлен RuStore.
- Актуальная версия RuStore на устройстве пользователя.
- Приложению RuStore разрешена установка приложений.

#### Подготовка требуемых параметров

Перед настройкой примера приложения необходимо подготовить следующие данные.

- `applicationId` — уникальный идентификатор приложения в системе Android в формате обратного доменного имени (например: ru.rustore.sdk.example).
- `*.keystore` — файл ключа, который используется для [подписи и аутентификации Android-приложения](https://www.rustore.ru/help/developers/publishing-and-verifying-apps/app-publication/apk-signature/).

#### Настройка примера приложения

1. Откройте проект **Unity** из папки `appupdate_example_6000`.
1. Откройте сцену **AppUpdateSampleScene** из папки `Assets / RuStoreAppUpdateExample / Scenes`.
1. В разделе **Publishing Settings** (**Edit → Project Settings → Player → Android Settings**) выберите вариант **Custom Keystore** и задайте параметры **Path / Password**, **Alias / Password** подготовленного файла `*.keystore`.
1. В разделе **Other Settings** (**Edit → Project Settings → Player → Android Settings**) настройте раздел **Identification**, отметив опцию **Override Default Package Name** и указав `applicationId` в поле **Package Name**.
1. Выполните сборку проекта командой **Build** (**File → Build Settings**) и проверьте работу приложения.

#### Сценарий использования

##### Проверка наличия обновлений

Тап по кнопке `Получить AppUpdateInfo` выполняет процедуру [проверки наличия обновлений][20].

![Проверка наличия обновлений](images/01_get_app_update_info.png)

##### Запуск скачивания обновления

Тап по кнопке `Запустить гибкое обновление` выполняет процедуру [запуска скачивания обновления][30].

![Запуск скачивания обновления](images/02_start_update_flow_delayed.png)

##### Установка обновления

Тап по кнопке `Завершить гибкое обновление` выполняет процедуру [установки обновления][40].

![Установка обновления](images/03_complete_update.png)

#### История изменений

[CHANGELOG](../CHANGELOG.md)

#### Условия распространения

Данное программное обеспечение, включая исходные коды, бинарные библиотеки и другие файлы, распространяется под лицензией MIT. Информация о лицензировании доступна в документе [MIT-LICENSE](../MIT-LICENSE.txt).

#### Техническая поддержка

Дополнительная помощь и инструкции доступны в [документации RuStore](https://www.rustore.ru/help/) и по электронной почте support@rustore.ru.

[10]: https://www.rustore.ru/help/sdk/updates/unity/10-5-1
[20]: https://www.rustore.ru/help/sdk/updates/unity/10-5-1#checkavailable
[30]: https://www.rustore.ru/help/sdk/updates/unity/10-5-1#scenariodelayedupdate
[40]: https://www.rustore.ru/help/sdk/updates/unity/10-5-1#installupdateflexible

[en]: README.en.md
