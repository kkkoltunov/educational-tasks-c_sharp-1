# :label: Полноценные программы из курса по программированию на C#. 1 курс Вышки.
Здесь собраны все программы и задания к ним, которые были написаны мной на 1 курсе во время прохождения дисциплины программирование на `C#`. 

:desktop_computer: 2-4, 7 работы были выполнены как `консольное приложение`, остальные с использованием `Windows Forms`. Начиная с 6 работы я научился писать README, поэтому пусть этим комменты проверяющим останутся в истории :)

:clipboard: К каждому заданию приложен `pdf` файл, в котором содержится ТЗ от преподавателя, которое я стремился максимально четко выполнить. Стоит отметить что средняя оценка за все работы у меня была 9 баллов из 10.

Далее коротко о тематике каждого задания.

:interrobang: Здесь представлены довольно объемные программы для начинающего с точки зрения кода. С каждой новой задачей мои навыки и знания языка улучшались (так как изначально я начинал практически без знаний языка), это легко заметить если открыть 2-5 задание и сравнить их с последними.

:laughing: 1 задание было слишком простым, поэтому его здесь нет.

## :round_pushpin: [2 задание "Файловый менеджер"](/02_FileManager)

Заданием была разработка "Файлового менеджера", с которым происходит взаимодействие через консоль. Грубо говоря мы делали аналог командной строки, основными функциями которой являются просмотр списка дисков, переход по директориям, вывод содержимого текстовых файлов, создание, удаление, копирование, перемещение файлов.

## :round_pushpin: [3 задание "Калькулятор матриц"](/03_MatrixCalc)

Заданием была разработка консольного калькулятора для матриц. Основные функции: нахождение следа матрицы, транспонирование матрицы, сумма и разонсть двух матриц, нахождение определителя. Дополнительно я реализовал операцию для решения СЛАУ методом Гаусса. 

## :round_pushpin: [4 задание "Овощной склад"](/04_WarehouseManager)

Заданием была разработка консольного приложения, в котором должны присутствовать следущие сущности: склад, контейнер с ящиками, ящик с овощами. Каждую из этих сущностей можно добавлять и удалять со склада, изменять информацию о ней. Я реализовал это в виде приложения с контекстным меню. Здесь было положено начало работы с Объектно-ориентированным программированием.

## :round_pushpin: [5 задание "Фракталы"](/05_FractalsWinForms)

`Фрактал — множество, обладающее свойством самоподобия.`

Заданием была разработка оконного приложения с использованием WinForms для отрисовки, изменения и работы с фракталами. Нужно было реализовать 5 видов: "Обудваемое ветром фрактальное дерево", "Кривая Коха", "Ковер Серпинского", "Треугольник Серпинского", "Множество Кантора". Дополнительно я реализовал автоматическую перерисовку фрактала при изменение размеров окна, увеличение масштаба фрактала, сохранение фрактала в виде изображения. 

## :round_pushpin: [6 задание "Текстовый редактор"](/06_NotePad--)

Заданием была разработка оконного приложения для работы с текстовыми файлами. Оснойной функционал: открытие, редактирование, форматирование, сохранение простых файлов и файлов `rtf`, настройка горячих клавиш, отмены и повторения предыдущих действий, создание контекстного меню. Дополнительно я реализовал возможность открытия и сохранения файлов с исходным кодом на языке `C#`, а также подсветка кода для файлов такого типа.

## :round_pushpin: [7 задание "Управление задачами"](/07_YourPlaner)

Заданием была разработка библиотеки классов, а также консолького интерфейса для работы с ней. Было необходимо разработать аналог MS Project со следующими сущностями: пользователь, проект, задачи и их статусы, типы задач, а также интерфейс со списком исполнителей задач. Каждая сущность обладает своими ограничениями и преимуществами в зависимости от необходимого набора действий. Например, некоторые задачи могут содержать несколько исполнителей или у задач могут быть более специфические подзадачи.

## :round_pushpin: [8 задание "Анализ табличных данных"](/08_ExcelMini)

Заданием была разработка оконного приложения для анализа табличных данных, которые предоставлялись в формате `csv`. Нужно было реализовать загрузку, парсинг и обработку данных с выставлением некоторых умалчиваемых значений, а также предоставлять по ним некоторую статистику (среднее значение, медиана, среднеквадратическое отклонение и дисперсия) и возможность строить графики с подписями в том числе и двумерные графики. Дополнительно я реализовал сохранение графиков. 

## :round_pushpin: [9 задание "Склад товаров"](/09_ProductsWarehouse)

Заданием была разработка оконного приложения, позволяющего управлять оширной нуменклатурой товаров, хранимых на складе. Было необходимо реализовать классификатор товаров с их подробным описанием (название, код, производитель, стоимость, количество, гарантия и прочее). Основной функционал: вывод и управление классификатором с возможностью создания, изменения и удлаения разделов, а также выводом списка товаров и их управлением. Также нужно было реализовать сохранение состояния склада и реализовать возможность для сохранения в формате `csv` списка товаров, количество которых на складе меньше заданного.

## :round_pushpin: [10 задание "Покупатели и заказы"](/10_SellersAndBuyers)

Заданием была разработка оконного приложения для совершения заказов их классификатора разработанного в [предыдущем задании](/09_ProductsWarehouse). Было необходимо разработать клиентское приложение с возможность зарегистрироваться и авторизоваться, а также оформить заказ по товарам из каталога и оплатить его. Главная суть в том, что два приложения должны были корректно обращаться с одним хранилищем данных и правильно синхронизоваться. Из приложения для заказчика пользователь может добавлять товары, смотреть список клиентов, заказов и формировать отчеты.