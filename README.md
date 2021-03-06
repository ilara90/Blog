Приложение Blog

Разработан блог как ASP.NET (Core) MVC приложение, позволяющее создавать, редактировать и просматривать статьи.
Приложение имеет две области: для контент-редактора (https://localhost:ХХХХ/Administration) и для обычного пользователя (https://localhost:ХХХХ/).

Контент-редакторы - авторизированные пользователи – вход осуществляют по логину и паролю (для аутентификации/авторизации использовался стандартный ASP.NET (Core)Identity).

Контент-редакторы могут выполнять следующие операции:
- Создавать, редактировать и удалять (использован метод "soft delete") категории статей (category)
- Создавать, редактировать и удалять статьи (article)
- Добавлять и удалять (использован метод "soft delete") теги для статей (tag)

Обычные пользователи – не авторизированные пользователи – не требуют аутентификации.
Обычные пользователи могут выполнять следующие операции:
- Просматривать список статей
- Просматривать конкретную статью
- Фильтровать статьи по категориям (у каждой статьи есть только одна категория)
- Фильтровать статьи по датам (статьи, опубликованные с даты X по дату Y)
- Фильтровать статьи по тегам (у каждой статьи есть несколько тегов, соответственно фильтровать можно по нескольким тегам)

Статья имеет следующие поля:
- Название (Title) – поле обязательное
- Краткое описание (Description) – поле не обязательное
- Текст статьи (Content) – поле обязательное
- Картинка (Image) – поле не обязательное
- Категория (Category) – поле обязательное
- Теги (Tags) – поле не обязательное

Страница со списком статей (Articles List) содержит сам список статей (в карточках можно увидеть название, категорию, краткое описание, дату публикации и картинку если заданы), пагинацию, фильтры (по категории, датам, тегам).
Страница конкретной статьи (Article Details) содержит название, текст статьи, картинку (если задана), категорию и теги (если заданы), дату публикации.

Использовались следующие технологии:
- Back-end: ASP.NET Core MVC
- Databases: MS SQL
- Front-end: Bootstrap + jQuery
