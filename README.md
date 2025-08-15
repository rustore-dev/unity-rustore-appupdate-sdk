> ⚠️ Не используйте кнопку "Код → Скачать" на сайте GitFlic – этот метод не загружает файлы из Git LFS. [Инструкция по клонированию](README_CLONE.md).

### Unity-плагин RuStore для обновления приложения

#### [🔗 Документация разработчика][10]

Плагин “RuStoreAppUpdateManager” помогает поддерживать актуальную версию вашего приложения на устройстве пользователя.

Репозиторий содержит плагины “RuStoreAppUpdateManager” и “RuStoreCore”, а также демонстрационное приложение с примерами использования и настроек. Поддерживаются версии Unity 2022+.

#### Сборка примера приложения

Вы можете ознакомиться с демонстрационным приложением содержащим представление работы всех методов sdk:
- [appupdate_example](https://gitflic.ru/project/rustore/unity-rustore-appupdate-sdk/file?file=appupdate_example)

#### Установка плагина в свой проект

**Подключение UPM-пакета через Package Manager**:
   - вариант **Add package from tarball...** — рекомендуемый способ установки.
   
   1. Скачайте файлы <code>ru.rustore.core-<em>version</em>.tgz</code> и <code>ru.rustore.update-<em>version</em>.tgz</code> со страницы [релизов][20].
   1. Импортируйте скачанные пакеты в проект через **Package Manager** (**Window → Package Manager → __+__ → Add package from tarball...**).
   1. Выполните шаги раздела **Настройка проекта**, см. ниже.

   - вариант **Add package from disk...** — при необходимости самостоятельных доработок, см. [README](https://gitflic.ru/project/rustore/unity-rustore-appupdate-sdk/file/?file=ru.rustore.update);

**Подключение \*.unitypackage через Import Assets** — устаревший способ установки.

   1. Скачайте пакет <code>RuStoreUnityAppUpdateSDK-<em>version</em>.unitypackage</code> со страницы [релизов][20].
   1. Импортируйте скачанный пакета в проект: **Assets → Import Package → Custom Package...**.
   1. Выполните шаги раздела **Настройка проекта**, см. ниже.

#### Настройка проекта

1. Откройте настройки проекта: **Edit → Project Settings → Player → Android Settings**.
1. В pазделе **Publishing Settings** включите настройки:
   - Custom Main Manifest.
   - Custom Main Gradle Template.
   - Custom Gradle Properties Template.
1. В разделе **Other Settings** настройте:
   - Package name.
   - Minimum API Level = 24.
   - Target API Level = 34.
1. Обновите зависимости проекта с помощью [**External Dependency Manager**](README_EDM.md): **Assets → External Dependency Manager → Android Resolver → Force Resolve**.

#### История изменений

[CHANGELOG](CHANGELOG.md)

#### Условия распространения

Данное программное обеспечение, включая исходные коды, бинарные библиотеки и другие файлы, распространяется под лицензией MIT. Информация о лицензировании доступна в документе [MIT-LICENSE](MIT-LICENSE.txt).

#### Техническая поддержка

Дополнительная помощь и инструкции доступны в [документации RuStore](https://www.rustore.ru/help/) и по электронной почте support@rustore.ru.

[10]: https://www.rustore.ru/help/sdk/updates/unity/10-0-0
[20]: https://gitflic.ru/project/rustore/unity-rustore-appupdate-sdk/release
