### Unity-плагин RuStore для обновления приложения

#### [🔗 Документация разработчика][10]  

#### Установка плагина в свой проект

Поддерживаются версии Unity 2022+. Для установки выполните следующие действия.

1. Скачайте пакет [`RuStoreUnityAppUpdateSDK-x.y.z.unitypackage`][20] и импортируйте в проект (**Assets → Import Package → Custom Package...**).
1. Откройте настройки проекта: **Edit → Project Settings → Player → Android Settings**.
1. В pазделе **Publishing Settings** включите настройки **Custom Main Manifest**, **Custom Main Gradle Template**, **Custom Gradle Properties Template**.
1. В разделе **Other Settings** настройте **package name**, **Minimum API Level** = **24**, **Target API Level** = **34**.
1. Обновите зависимости проекта: **Assets → External Dependency Manager → Android Resolver → Force Resolve**.

#### История изменений

[CHANGELOG](../CHANGELOG.md)

#### Условия распространения

Данное программное обеспечение, включая исходные коды, бинарные библиотеки и другие файлы, распространяется под лицензией MIT. Информация о лицензировании доступна в документе [MIT-LICENSE](../MIT-LICENSE.txt).

#### Техническая поддержка

Дополнительная помощь и инструкции доступны в [документации RuStore](https://www.rustore.ru/help/) и по электронной почте support@rustore.ru.

[10]: https://www.rustore.ru/help/sdk/updates/unity/10-0-0
[20]: https://gitflic.ru/project/rustore/unity-rustore-appupdate-sdk/blob/raw?file=unitypackages%2FRuStoreUnityAppUpdateSDK-10.0.0.unitypackage&inline=false
