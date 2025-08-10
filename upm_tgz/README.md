### Unity-плагин RuStore для обновления приложения

#### [🔗 Документация разработчика][10]

#### Установка плагина в свой проект

Поддерживаются версии Unity 2022+. Для установки выполните следующие действия.

1. Скачайте файлы [`ru.rustore.core-x.y.z.tgz`][20] и [`ru.rustore.update-x.y.z.tgz`][30].
1. Импортируйте скачанные пакеты в проект через **Package Manager** (**Window → Package Manager → __+__ → Add package from tarball...**).
1. Обновите зависимости проекта с помощью [**External Dependency Manager**](https://github.com/googlesamples/unity-jar-resolver.git?path=/upm) (**Assets → External Dependency Manager → Android Resolver → Force Resolve**).

#### Установка External Dependency Manager

**External Dependency Manager** для Android поставляется в составе пакета **RuStore Core**. Для установки выполните следующие действия.

1. Откройте **RuStore Core** в окне менеджера пакетов (**Window → Package Manager → Packages RuStore → RuStore Core**).
1. Перейдите на вкладку **Sample**.
1. Импортируйте сэмпл **External Dependency Manager**.

Вы также можете установить последнюю версию **External Dependency Manager** из официального репозитория на [GitHub](https://github.com/googlesamples/unity-jar-resolver.git?path=/upm).

#### История изменений

[CHANGELOG](../CHANGELOG.md)

#### Условия распространения

Данное программное обеспечение, включая исходные коды, бинарные библиотеки и другие файлы, распространяется под лицензией MIT. Информация о лицензировании доступна в документе [MIT-LICENSE](../MIT-LICENSE.txt).

#### Техническая поддержка

Дополнительная помощь и инструкции доступны в [документации RuStore](https://www.rustore.ru/help/) и по электронной почте support@rustore.ru.

[10]: https://www.rustore.ru/help/sdk/updates/unity/10-0-0
[20]: https://gitflic.ru/project/rustore/unity-rustore-appupdate-sdk/blob/raw?file=upm_tgz%2Fru.rustore.core-10.0.0.tgz&inline=false
[30]: https://gitflic.ru/project/rustore/unity-rustore-appupdate-sdk/blob/raw?file=upm_tgz%2Fru.rustore.update-10.0.0.tgz&inline=false
