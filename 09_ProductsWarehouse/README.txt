Приветствую тебя, уважаемый проверяющий!

Хочу рассказать немного о своей программе. В ней реализован весь основной функционал, а также один пункт из дополнительного функционалала,
а именно: возможность автоматической (используем Random) генерации классификатора и товаров по заданным пользователям параметрам, включающим, как
минимум: количество разделов классификатора и количество товаров.

ВАЖНО! NuGet пакеты не используются, но проект на .Net 5, что не противорчет ТЗ, но может привести к некомпилу, если у вас не скачан данный фреймворк.
Пожалуйста, обновитесь :)

Присутсвуют некоторые аспекты, которые необходимо знать:
1. Состояние склада перед закрытием приложения нужно сохранить самостоятельно, а при запуске выбирать подходящий сохраненный вариант.
Вы можете сохранять много версий склада, их число неограниченно. Открыть можно только одну версию. Для этого специально разработана форма.
ТЗ соблюдено, и сделан более удобный функционал для работы с версиями склада.
2. CSV отчет формируется с использованием UTF-8.
3. Из-за использования бинарной сериализации может выскакивать warning, игнорируйте это.
4. При рандомной генерации название товара и связок в дереве не задаются рандомным набором букв, так задумано. 

Если изменить расположение каких-то файлов или папок в папке с проектом, то корректная работоспособность программы не гарантируется.

──╔╗╔╗─╔══╗─╔══╗─╔╗╔╗─╔╗╔╗──╔╗──
──║║║║─║╔╗║─║╔╗║─║║║║─║║║║──║║──
──║╚╝║─║║║║─║╚╝║─║╚╝║─║║║║──║║──
──╚═╗║─║║║║─║╔╗║─╚═╗║─║║║║──╚╝──
───╔╝║╔╝╚╝╚╗║║║║───║║─║╚╝║──╔╗──
───╚═╝╚════╝╚╝╚╝───╚╝─╚══╝──╚╝──