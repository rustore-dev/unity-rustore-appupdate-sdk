## RuStore Unity плагин для обновления приложения

### [🔗 Документация разработчика][10]

- [Условия работы SDK](#Условия-работы-SDK)
- [Подготовка требуемых параметров](#Подготовка-требуемых-параметров)
- [Настройка примера приложения](#Настройка-примера-приложения)
- [Сценарий использования](#Сценарий-использования)
- [Условия распространения](#Условия-распространения)
- [Техническая поддержка](#Техническая-поддержка)


### Условия работы SDK

Для работы RuStore In-app updates SDK необходимо соблюдение следующих условий:

1. ОС Android версии 7.0 или выше.

2. На устройстве пользователя установлен RuStore.

3. Актуальная версия RuStore на устройстве пользователя.

4. Приложению RuStore разрешена установка приложений.


### Подготовка требуемых параметров

1. `applicationId` - уникальный идентификатор приложения в системе Android в формате обратного доменного имени (пример: ru.rustore.sdk.example).

2. `*.keystore` - файл ключа, который используется для [подписи и аутентификации Android приложения](https://www.rustore.ru/help/developers/publishing-and-verifying-apps/app-publication/apk-signature/).


### Настройка примера приложения

1. Откройте проект Unity из папки _“review_example”_.

2. В разделе Publishing Settings: Edit → Project Settings → Player → Android Settings выберите вариант _“Custom Keystore”_ и задайте параметры “Path / Password”, “Alias / Password” подготовленного файла `*.keystore`.

3. В разделе Other Settings: Edit → Project Settings → Player → Android Settings настройте раздел “Identification”, отметив опцию “Override Default Package Name” и указав `applicationId` в поле “Package Name”.

4. Выполните сборку проекта командой Build: File → Build Settings и проверьте работу приложения.


### Сценарий использования

#### Проверка наличия обновлений

Тап по кнопке `Получить AppUpdateInfo` выполняет процедуру [проверки наличия обновлений][20].

![Проверка наличия обновлений](images/01_get_app_update_info.png)


#### Запуск скачивания обновления

Тап по кнопке `Запустить гибкое обновление` выполняет процедуру [запуска скачивания обновления][30].

![Запуск скачивания обновления](images/02_start_update_flow_delayed.png)


#### Установка обновления

Тап по кнопке `Завершить гибкое обновление` выполняет процедуру [установки обновления][40].

![Установка обновления](images/03_complete_update.png)


### Условия распространения

Данное программное обеспечение, включая исходные коды, бинарные библиотеки и другие файлы распространяется под лицензией MIT. Информация о лицензировании доступна в документе [MIT-LICENSE](../MIT-LICENSE.txt).


### Техническая поддержка

Дополнительная помощь и инструкции доступны на странице [rustore.ru/help/](https://www.rustore.ru/help/) и по электронной почте [support@rustore.ru](mailto:support@rustore.ru).

[10]: https://www.rustore.ru/help/sdk/updates/unity/6-1-0
[20]: https://www.rustore.ru/help/sdk/updates/unity/6-1-0#checkavailable
[30]: https://www.rustore.ru/help/sdk/updates/unity/6-1-0#scenariodelayedupdate
[40]: https://www.rustore.ru/help/sdk/updates/unity/6-1-0#%D0%B3%D0%B8%D0%B1%D0%BA%D0%BE%D0%B5-%D0%B7%D0%B0%D0%B2%D0%B5%D1%80%D1%88%D0%B5%D0%BD%D0%B8%D0%B5-%D0%BE%D0%B1%D0%BD%D0%BE%D0%B2%D0%BB%D0%B5%D0%BD%D0%B8%D1%8F
