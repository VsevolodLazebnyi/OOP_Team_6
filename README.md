#  ООП Команда №6
<a name="Вернуться в начало"></a>

<div align="center">

  <h3>Тема: "Портал недвижимости для агентов и клиентов"</h3>
  <h4>по дисциплине: "Обьекто ориентированное программирование"</h4>

<div align="center">
	
```
    Состав команды:
  Старцева Арина Михайловна (@irene_startseva)
  Махоткина Екатерина Дмитриевна (@thekateeeee)
  Лазебный Всеволод Владимирович (@vllazebnyi)
  Терёшкина Наталья Андреевна (@arabobiha)
  Шабарина Мария Андреевна (@MpAsSgHA)
  Турищев Артем (@ArtFive55555)
```

<div align="center">
  
<div align="left">


<details>
  <summary> Навигация </summary>
  <ol>
    <li>
      <a href="#Доменные сущности которые мы уже успели спроектировать">Доменные сущности которые мы уже успели спроектировать</a>
      <ul>
        <li><a href="#Описание методов работы приложения">Описание методов работы приложения</a></li>
        <li><a href="#Описание интерфейсов">Описание интерфейсов</a></li>
        <li><a href="#Ход работы:">Ход работы</a></li>
      </ul>
    </li>
  </ol>
</details>


<a name="Доменные сущности которые мы уже успели спроектировать"></a>
# Доменные сущности, которые мы уже успели спроектировать
```
1. Авторизация (ID присваивается, username, эл. почта, телефон, статус на сайте)
2. Покупатель (ID пользователя, история покупок, может разместить объявление)
3. Риелтор (ID пользователя, может разместить объявление)
4. Продавец (ID пользователя, может разместить объявление)
5. Банк (аккаунты по другим ID, привязан ко всем типам пользователей, списание и начисление)
6. Объект (квартира/дом/площадь в доме, продавец, риелтор если есть)
7. Сделка (ID объекта, риелтор, продавец, покупатель, банковский аккаунт покупателя)
8. Отзывы (привязываем к объекту, оценить риелтора, оценить продавца)
```

<a name="Описание методов работы приложения"></a>
## Описание методов работы приложения

```
Регистрация - POST api/new_account
request - {"login": "name", "password": "qwerty", "role": "Realtor",
           "Name": "name", "Surname": "Surname", 
           "email": "example@example.com", "Phone": "89999999999"}
response - {"UserID": "12345"}

Изменение аккаунта - PUT api/change_account
request - {"login": "name", "password": "qwerty", "role": "Realtor",
           "Name": "name", "Surname": "Surname", 
           "email": "example@example.com", "Phone": "89999999999"}
response - {"status": "OK"}

Удаление аккаунта - DELETE api/delete_account
request - {"login": "name", "password: "qwerty"}
response - {"status": "OK"}

Размещение объявления - POST api/new_object
request - {"UserID": "12345", "Type": "Квартира", "RealtorID": "12345",
            "RoomNumber": "123", "Square": "50", "Area": "50"}
responce - {"ObjectId": "67890"}

Изменение объявления - PUT api/change_object
request - {"ObjectId": "67890", "Type": "", "RealtorID": "12345",
            "RoomNumber": "123", "Square": "50", "Area": "50"}
responce - {"status": "OK"}

Удаление объявления - DELETE api/delete_object
request - {"UserID": "12345" "Objectid": "67890"}
response - {"status": "OK"}

Просмотр объявления - GET api/get_object
request - {"ObjectId": "67890"}
response - {"UserID": "12345", "Type": "квартира", "RealtorID": "12345",
            "RoomNumber": "123", "Square": "50", "Area": "50"}

Создание оценки - POST api/new_review
request - {"UserID": "12345", "ObjectId": "67890",
           "Text": "Очень понравилось", "Rating": "0.1"}
response - {"ReviewId": "54321"}

Изменение оценки - Put api/change_review
request - {"ReviewId": "54321", "UserID": "12345", "ObjectId": "67890",
           "Text": "Очень понравилось", "Rating": "0.1"}
response - {"status": "OK"}

Удаление оценки - DELETE api/delete_review
request - {"UserID": "12345", "ReviewId": "54321"}
response - {"status": "OK"}

Просмотр оценки - Get api/get_review
request - {"ReviewId": "54321"}
responce - {"Text": "Очень понравилось", "Rating": "0.1"}

Просмотр пользователя - GET api/get_user
request - {"UserID": "12345"}
response - {"role": "Realtor", "objectList": {"Object1": "67890"...},
            "reviewList": {"review1": "54321"...}}

Заключение сделки - Post api/new_deal
request - {"CustomerID": "12345", "ObjectId": "67890"}
response - {"DealID": "09876"}

Изменение сделки - Put api/change_deal
request - {"DealID": "09876", "CustomerID": "12345", "ObjectId": "67890"}
response - {"status": "OK"}

Удаление сделки - DELETE api/delete_deal
request - {"DealID": "09876", "UserID": "12345"}
response - {"status": "OK"}

Просмотр сделки - GET api/get_deal
request - {"DealId": "09876"}
responce - {"CustomerID": "12345", "ObjectId": "67890"}
```

<a name="Описание интерфейсов"></a>
## Описание интерфейсов

```Python
request - Account
response - Регистрация: {UserID: "12345"}
	Изменение аккаунта: {status: "OK"}
	Удаление аккаунта: {status: "OK"}

request - Object
response - Размещение объявления: {ObjectId: "67890"}
	Изменение объявления: {status: "OK"}
	Удаление объявления: {status: "OK"}
	Просмотр объявления: {UserID: 12345, Type: "", RealtorID: "12345", RoomNumber: "123", Square: "50", "Area": "50"}

request - Review
response - Создание оценки: {ReviewId: "54321"}
	Изменение оценки: {status: "OK"}
	Удаление оценки: {status: "OK"}
	Просмотр оценки: {Text: "Очень понравилось"}

request - User
response - Просмотр пользователя: {role: "Realtor", objectList: {Object1: "67890"...}, reviewList: {review1: "54321"...}}

request - Deal
response - Заключение сделки: {DealID: "09876"}
	Изменение сделки: {status: "OK"}
	Удаление сделки: {status: "OK"}
	Просмотр сделки: {CustomerID: "12345", "ObjectId": "67890"}
```

<a name="Ход работы:"></a>
## Ход работы: 

```
1) При встрече команды распределили роли на эту лабораторуню работу следующим образом: Екатерина Махоткина делала ER-диаграмму и заполняла Readme; Арина Старцева и Наталья Терёшкина разрабатывают доменные сущности; Мария Шабарина проектирует систему; Артём Турищев разрабатывает методы; Всеволод Лазебный, Арина Старцева и Наталья Терёшкина разрабатывают интерфейсы к моделям; Всеволод Лазебный также занимается CSproj и Gitgnore-файлами.
2) Арина Старцева и Наталья Терёшкина спроектировали доменные сущности.
3) Екатерина Махоткина на основе результата работы из пункта 2 составила ER-диаграмму.
4) Мария Шабарина спроектировала систему и пофиксила ошибки.
5) Далее спроектировал методы Артём Турищев.
6) Всеволод Лазебный, Арина Старцева и Наталья Терёшкина разработали описание интерфейсов.
7) Всеволод Лазебный почистил Gitgnore, CSproj будет очищен после merge. 

Наша доска распределения обязанностей: https://www.notion.so/d07be6994bc14268a4dfa2d15ac8b343?v=ba246b9f0d13490685b15dbe2f1fddb9

```



<h3>Тема: "Лабораторная работа №2"</h3>


1) Всеволод Лазебный "поднял" Docker для базы данных;
2) Артём Турищев написал скрипт для базы данных в Docker;
3) Екатерина Махоткина создавала таблицы в paAdmin;
4) Арина Старцева ревлизовала бизнес-логику;
5) Наталья Терёшкина и Мария Шабарина провели работу с Entity Framework;
6) Артём Турищев написал контроллеры;
7) Всеволод Лазебный "разложил" все файлы по нужным папкам и шаблонам;
8) Екатерина Махоткина заполнила Readme - файл.
