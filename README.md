### Unity-плагин RuStore для обновления приложения

#### [🔗 Документация разработчика][10]

Плагин “RuStoreAppUpdateManager” помогает поддерживать актуальную версию вашего приложения на устройстве пользователя.

Репозиторий содержит плагины “RuStoreAppUpdateManager” и “RuStoreCore”, а также демонстрационное приложение с примерами использования и настроек. Поддерживаются версии Unity 2022+.


### Сборка примера приложения

Вы можете ознакомиться с демонстрационным приложением содержащим представление работы всех методов sdk:
- [README](appupdate_example/README.md)
- [appupdate_example](https://gitflic.ru/project/rustore/unity-rustore-appupdate-sdk/file?file=appupdate_example)


### Установка плагина в свой проект

1. Импортируйте пакет Example/RuStoreReviewSDKExample.unitypackage в проект Unity.

2. Откройте настройки проекта: Edit → Project Settings → Player → Android Settings.

3. В pазделе Publishing Settings: включите настройки Custom Main Manifest, Custom Main Gradle Template, Custom Gradle Properties Template. 

4. В разделе Other Settings: настройте package name, Minimum API Level = 24, Target API Level = 34.

5. Откройте настройки External Dependency Manager: Assets → External Dependency Manager → Android Resolver → Settings. Включите настройки Use Jetifier, Patch mainTemplate.gradle, Patch gradleTemplate.properties.

6. Обновите зависимости проекта: Assets → External Dependency Manager → Android Resolver → Force Resolve.

#### История изменений

[CHANGELOG](CHANGELOG.md)

#### Условия распространения

Данное программное обеспечение, включая исходные коды, бинарные библиотеки и другие файлы, распространяется под лицензией MIT. Информация о лицензировании доступна в документе [MIT-LICENSE](MIT-LICENSE.txt).

#### Техническая поддержка

Дополнительная помощь и инструкции доступны в [документации RuStore](https://www.rustore.ru/help/) и по электронной почте support@rustore.ru.

[10]: https://www.rustore.ru/help/sdk/updates/unity/10-0-0
