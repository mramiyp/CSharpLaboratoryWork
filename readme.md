# Задание на лабораторную работу №1

**Темы:** Классы, наследование и ассоциация (композиция, агрегация); поля, свойства и автосвойства; статические поля, свойства и методы; операторы и перегрузка операторов; методы и перегрузка методов, Ad-hoc-полиморфизм.

**Среда разработки:** Microsoft Visual Studio

**Язык программирования:** C#

**Тип проекта:** Консольное приложение


## ТРЕБОВАНИЯ К РАЗРАБОТКЕ

1. Запрещается использовать обработку исключительных ситуаций и генерировать исключения.
1. Каждый класс должен быть оформлен в отдельном файле.
1. Запрещается использовать полиморфизм подтипов. 
1. Придерживайтесь принципа DRY (`Don’t repeat yourself`).
1. Используйте комментарии и xml-комментарии

## ЗАДАНИЯ

Разработать программное обеспечение для терминала управления складом продукции (склад для хранения товара). Предусмотреть вывод информации по продукции, хранимой на складе, каждый экземпляр продукции имеет свой уникальный код.  Код представляет собой числовое значение и его строковый вид в формате штрих-кода. Склад представлен в виде последовательности ячеек для хранения. В каждой ячейке может храниться максимум один экземпляр продукции. При старте программы склад заполнен товаром частично. 

Терминал позволяет: 
- Загружать/выгружать продукцию на склад;
- Выводить информацию по продукции, в отсортированном виде;
- Менять продукцию местами, заменять на новую;
- Изменять стандартный способ вывода кода продукции;
- Определять наличие продукции, по коду (или штрих-коду) или наименованию;

### ТЕХНИЧЕСКОЕ ЗАДАНИЕ
### РАЗДЕЛ 1

4 часа

#### ЧАСТЬ 1

Продукцию описать в виде абстрактного класса, без виртуальных методов:
- Предусмотреть возможность задавать код товара как в числовом, так и в строковом виде (`см. часть 2` как преобразовать числовой код в строковый «штрих-код» и наоборот);
- Дать возможность указать способ вывода кода продукции по умолчанию для всей продукции сразу: штрих-код или числовой код;
- Помимо кода, продукция должна содержать информацию по наименованию;
- Перегрузить функцию **«ToString()»** для получения информации по наименованию и коду, учитывая способ вывода самого кода;
- Класс не должен содержать открытых методов и полей (**«Класс-Модель»**), но может позволять взаимодействовать с информацией по наименованию, коду и способу вывода данного кода.

#### ЧАСТЬ 2

Числовой код преобразовывается в строковый («штрих-код») по принципу: 
- Начало и конец строки обрамляются символом: `█` (Alt+219);
- Код преобразовывается в бинарный вид, а пара битов кодируются по принципу:

|Биты|Символ|Код|
|--|:--:|--:|
|00||32|
|01|`│`|179|
|10|`║`|186|
|11|`▌`|221|

- Допускается упускать в строке все начальные нулевые биты.

Пример:
|Номер|Промежуточная битовая запись|Ожидаемый код|
|--|:--|:--:|
|215456870|1100110101111001110001100110|`█▌ ▌ ││▌║│▌ │║│║█`|
|45|101101|`█║▌│█`|
|1000000|11110100001001000000|`█▌▌│  ║│   █`|
#### ЧАСТЬ 3
Создать класс, производный от абстрактного, согласно своему варианту из приложения 1:
- Добавить, как минимум 3 новых свойства, описывающих класс согласно вашему варианту;
- Перегрузить функцию «ToString()» для получения полной информации по данному виду продукции;

### ТЕХНИЧЕСКОЕ ЗАДАНИЕ
### РАЗДЕЛ 2
4 часа
#### ЧАСТЬ 1
Склад представить, как класс-контейнер, с возможностью хранить фиксированное количество продукции внутри:
- У каждого склада есть свой уникальный числовой код;
- Класс-контейнер взаимодействует с продукцией только через класс `раздела 1 части 1`.

У класса должен быть только один закрытый конструктор:
- Для создания экземпляров класса, запрещается использовать: синглтон, фабрики и рефлексию;
- Способ создания объектов класса должен быть описан только в самом классе;
- При создании объектов класса должно явно задаваться количество элементов контейнера.
#### ЧАСТЬ 2
Реализовать функционал получения нужного элемента по его порядковому номеру (индексу) через оператор индексации **[]**;
•	При этом обращение по индексу должно соответствовать принципу, как если бы продукция выгружалась из «ячейки», и ее можно было не возвращать обратно на место;
•	Присваивание через индексатор, должно учитывать что место в позиции свободное;

Реализовать методы:
- Добавления, удаления, замены и перестановки элементов контейнера;
- Поиска по коду и названию;
- Получения списка элементов, упорядоченных по коду и имени;

Перегрузить функцию **«ToString()»** для получения информации по всем элементам, хранящимся в контейнере.
- Учитывать пустые ячейки.
#### ЧАСТЬ 3
Реализовать возможность добавления к строковому коду продукции, информации по коду склада и коду позиции внутри склада:
- Коды склада и позиции не влияют на числовой код продукции;
- Алгоритм получения строкового кода склада и позиции такой же, как и алгоритм получения строкового кода продукции (`см. раздел 1 часть 2`);
- Продукция, выгруженная с одного склада, не теряет строковый код склада и позиции, до тех пор, пока не будет помещена на другой склад или перемещена внутри склада;
- Учесть случай, когда даже сам номер склада может поменяться;

Допустимые варианты формирования строкового кода:
|Склад|Номер|Продукция|Ожидаемый код|
|--|:--|:--|:--:|
|45|1|215456870|`█║▌│█│█▌ ▌ ││▌║│▌ │║│║█|`
|45|2|1000000|`█▌▌│  ║│   █║█║▌│█`
# Приложение 1

## Варианты:
1. Аппаратное обеспечение вычислительной техники
2. Программное обеспечение вычислительной техники
3. Элементная база для сборки компьютеров
4. Инструментальные среды для разработки программного обеспечения
5. Видеомониторы
6. Печатающие устройства
7. Принтеры
8. Плоттеры
9. Запоминающие устройства
10. Устройства для управления компьютером
11. Устройства передачи данных
12. Аппаратное обеспечение компьютерных сетей
13. Звуковоспроизводящая аппаратура
14. Звукозаписывающая аппаратура
15. Телефонные аппараты
16. Осветительные приборы
17. Оптические приборы
18. Нагревательные приборы
19. Холодильная техника
20. Бытовая техника
21. Вычислительные машины
22. Электрические машины
23. Подъемно-транспортные машины
24. Строительные машины
25. Металлургические машины
26. Сельскохозяйственные машины
27. Железнодорожный транспорт
28. Автомобильный транспорт
29. Воздушный транспорт
30. Водный транспорт
31. Энергетические установки
32. Элементы интерьера
33. Офисная мебель
34. Электроинструмент
35. Канцелярские товары
36. Изделия целлюлозно-бумажной промышленности
37. Строительные материалы
38. Строительные конструкции
39. Металлургические технологии
40. Врачебный контроль физиологического состояния спортсмена
41. Печи
42. Камины

# Задание на лабораторную работу №2

**Темы:** Интерфейсы, множественная реализация интерфейсов; полиморфизм подтипов.

**Среда разработки:** Microsoft Visual Studio

**Язык программирования:** C#

**Тип проекта:** Консольное приложение
## ТРЕБОВАНИЯ К РАЗРАБОТКЕ
1. Запрещается использовать обработку исключительных ситуаций и генерировать исключения. 
2. Запрещается использовать делегаты и события.
3.	Придерживайтесь принципа DRY (`Don’t repeat yourself`).
4.	Используйте комментарии и xml-комментарии

## ЗАДАНИЯ

1. Извлеките интерфейсную часть из класса `п.1.` в лабораторной работе №1 (`ЛР1`):
- Создайте интерфейс описывающий товар со стоимостью;
- Перенесите хранение текущего курса валют в интерфейс.
2.	Извлеките интерфейсную часть из производного класса (`п.3. ЛР1`).
- Дополнительно реализуйте определенный интерфейс, позволяющий сравнить два объекта по коду между собой;
- Создайте еще один производный класс от класса `части 1. ЛР1`;
    - Запретите дальнейшее наследование от этого класса;
    - Дайте возможность указывать цену только в одной валюте, но учтите, вторая валюта никуда не денется;
    - Переопределите реализацию интерфейса сравнения.
3.	Обобщите класс-контейнер (`п.2. ЛР1`):
- Замените хранимый тип контейнера на обобщение;
- Извлеките интерфейсную часть класса, при это важно чтобы интерфейсная часть класса сохранила в себе все открытие методы и свойства из класса-контейнера `ЛР1`;
- Обеспечьте следующий функционал:
    - Можно изменить код склада;
    - Если меняется курс первой валюты относительно второй, то и ценник в этой валюте тоже должен обновиться для каждого товара в контейнере;
    - Аналогичное поведение при смене курса второй валюты относительно первой;
    - Созданный товар, но не помещенный в контейнер создается по актуальному куру валют, и при последующем обновлении курса меняться не должен. То есть только попав в контейнер при обновлении курса должна обновиться его стоимость в зависимой валюте.
4.	Протестируйте работу программы:
- Продемонстрируйте все возможные варианты объявления продукции;
- Как минимум задействуйте два различных объекта класса-контейнера;
- Покажите, как работает перемещение товара из объекта одного класса контейнера в другой и наоборот, и в каких случаях это невозможно.

# Задание на лабораторную работу №3

**Темы:** Делегаты и события; потоки выполнения. _Обработка и генерация исключений._

**Среда разработки:** Microsoft Visual Studio 2022

**Язык программирования:** C# 9.0

**Тип проекта:** Консольное приложение


## ЗАДАНИЯ
1.	Обеспечьте реализацию интерфейса товара по умолчанию из `ЛР2`:
- Создайте делегат информирующий о смене курса, содержащий информацию по старому и новому курсу;
- Добавьте в интерфейс статическое свойство, для хранения информации по текущему курсу;
- Добавьте в интерфейс статическое свойство типа делегат из первого пункта;
- Обеспечьте при смене курса вызов делегата.
2.	Измените поведение класса-контейнера:
- Дайте возможность в конструкторе подписываться на делегат смены курса из `п.1`;
- Создайте запакованный класс производный от `EventArgs`, хранящий информацию по старому и новому курсу;
- Добавьте в класс контейнер событие смены курса, делегат должен быть типа: `EventHandler<T>`, где `T` – ваш производный класс от `EventArgs`;
- Расширьте интерфейс методом для возможности подписываться на событие из пункта выше, внутри метода реализуйте перерасчет стоимости товара;
- Обеспечьте при добавлении и удалении элементов контейнера подписку и отписку от события смены курса соответственно.
3.	Протестируйте работу программы.

## ДОПОЛНИТЕЛЬНО

1.	Реализация интерфейсов по умолчанию доступна в `С# 8.0`!
2.	Придерживайтесь принципа DRY (`Don’t repeat yourself`).
3.	Используйте комментарии и xml-комментарии.
4.	Обработка и генерация исключительных ситуаций на ваше усмотрение.