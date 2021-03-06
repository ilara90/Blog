
--Создание таблиц
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO

CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO

CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO

CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO

ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO

CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO

   CREATE TABLE Categories (
     Id    INT IDENTITY(1,1) NOT NULL CONSTRAINT Categorie_Id PRIMARY KEY,
     Title Nvarchar(50) NOT NULL,
     IsDeleted TINYINT DEFAULT 1     
   );
   CREATE TABLE Articles (
     Id INT IDENTITY(1,1) NOT NULL CONSTRAINT Article_Id PRIMARY KEY,
     Title Nvarchar(50) NOT NULL,
     Description Nvarchar(250) NULL,
     Content Text NOT NULL,
     CategoryId  INT NOT NULL,
     DATETIME datetime DEFAULT (getdate()),
     FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
   );
   
   --Добавление строк в таблицу
INSERT INTO Articles (Title, Description, Content, CategorieId)
     VALUES (N'Вокруг света в блинах', 
	     N'Грядёт Масленица — праздник света и тепла, знаменующий переход от зимы к лету, от тьмы к солнцу.',
	     'И тех, где ещё живы языческие культы, и тех, где эти культы вписались в традиционные религии, как это произошло с православием. 
		 Так, в целом ряде национальных традиций блины — в самом разном обличье — так или иначе связаны с разными обрядами. Правда, со временем культовый смысл круглой выпечки ушёл, а рецепты сохранились, оставив нам целое мировое блинное наследие, по которому интересно и вкусно путешествовать. Итак.
		 Франция. Крепы
		 Крепы — это большие тонкие блины из достаточно жидкого теста, которые готовят на смазанной маслом сковороде. Самый популярный рецепт французских крепов — это знаменитый креп-сюзетт: изысканный десерт из блинов, подаваемых с карамелью и ароматным апельсиновым соусом. В дополнение к этому в ресторанной подаче крепы поливают апельсиновым ликёром и фламбируют.
		 Америка. Панкейки
		 Воздушные, пухленькие и небольшого диаметра панкейки в Америке часто подают стопкой с фруктовыми или другими сладкими начинками на десерт или с хрустящим беконом и кленовым сиропом на завтрак. В тесто непременно добавляют разрыхлитель или взбитые яичные белки, отчего панкейки и получаются такими пышными.
		 Япония. Окономияки
		 Окономияки — это пикантные японские блины, которые могут стать началом насыщенной трапезы. Судите сами: их обычно готовят из мучной основы в сочетании со смесью тертого картофеля, капусты, морепродуктов или свиной грудинки, имбиря и сои. И подают с различной степени остроты и пикантности соусами, но чаще всего — со специальным японским майонезом.',
	     5),
            (N'Выйти из кризиса и обновиться',
             N'Топ-5 лучших мест для ментальной перезагрузки',
	     'В последнее время очень модно стало находиться «в моменте» и чувствовать себя ресурсной. Чтобы соответствовать этим критериям, необходимо зарядиться позитивной энергией и пересмотреть свои приоритеты.
	     Снять стресс, сбросить напряжение, переключить мозг и дать глазам отдохнуть после бесконечной удаленки — вот о чем сейчас мечтает практически каждый. Куда отправиться за полным релаксом и перезагрузкой? Пять мест для спокойного отдыха советует тревел-эксперт Марина Чепнян.
1.Алтай
Ставший за последние годы невероятно популярным, этот горный регион предлагает массу возможностей для спокойного, расслабляющего отдыха. Захватывающие дух пейзажи, чистейшие реки и озера, заснеженные вершины гор помогают переключиться на релакс-волну и подумать о том, на что обычно не хватает времени. Любители активного отдыха могут покататься на лыжах, отправиться в поход по горным лабиринтам или сплавиться на байдарке по горной реке. Если экстрим вам не по душе, можно просто гулять, смотреть на природные красоты и размышлять о высоком. Обратите внимание на глэмпинги — мини-отели с отдельно стоящими домиками, расположенные в самых красивых местах Алтая. Можно выбрать достаточно бюджетный отель, а можно остановиться и в очень приличном пятизвездочном домике.
2.Байкал
Поездка к самому большому и загадочному озеру страны может стать отдельным приключением — берите билеты на поезд и отправляйтесь в путешествие по Транссибу. Романтика железнодорожных путешествий многих возвращает в детство, незамысловатая еда и настольные игры вместе с отсутствием интернета заставляют отвлечься от диджитал-гонки. Зимой или летом, на Байкале всегда фантастически красиво и интересно. Остановитесь в санатории, чтобы поправить не только ментальное, но и физическое здоровье, или полностью оторвитесь от реальности, поселившись в палатке в кемпинге. Озеро считается мощным энергетическим местом, сюда приезжают заряжаться и проводить ритуалы все северные шаманы. Так что даже обычные прогулки по берегу помогут вам перезагрузиться и отдохнуть.
3.Эльбрус
Покорить самую высокую гору России не так сложно, как кажется. Прямой рейс до Минеральных Вод, затем несколько часов на автобусе или такси по извилистым горным дорогам, и вот вы уже в окружении величественных Кавказских гор. Подъемы на Эльбрус проводятся в теплое время года, маршруты разработаны так, чтобы с походом справился практически любой турист. Жить предстоит в палаточном лагере в горах, без сотовой связи и социальных сетей, а прогулки по горному хребту, захватывающие виды и свежий воздух вернут к жизни даже самого уставшего офисного работника. Можно запланировать такую поездку на выходные, а можно устроить себе настоящее путешествие по Северному Кавказу и посетить еще Архыз и Домбай или провести несколько дней в легендарных санаториях в Ессентуках или Кисловодске.
4. Каппадокия, Турция
Самый красивый горный регион Турции знаменит полетами на воздушных шарах, фантастическими видами и отелями, вырезанными прямо в скалах. Северная Турция совсем не похожа на морские курорты, здесь более колоритно, ярко и аутентично. Настоящая турецкая кухня, размеренная жизнь, прекрасная погода в любое время года сделают ваше путешествие незабываемым. Посмотрите подземные города и пещерные монастыри, древние мечети и историческую османскую архитектуру и обязательно поднимитесь на воздушном шаре! Можно совместить поездку с катанием на лыжах на курорте Эрджиес (сезон длится до середины апреля) или с прогулкой по Стамбулу, самому популярному и насыщенному турецкому городу.
5. Норвегия
Страна фьордов и викингов официально открыта для россиян с 26 января, и это место идеально подходит для отдыха от цивилизации. Здесь все словно создано для того, чтобы забыть о заботах и проблемах. Прогулка по горному маршруту с поэтическим названием «Лестница троллей», ночевки в деревянных домиках посреди вековых лесов, морские путешествия по фьордам принесут чистый восторг и приведут в состояние абсолютного счастья. Свежий воздух, яркие краски природы, прекрасный северный лосось на завтрак, обед и ужин — путешествие в Норвегию обещает быть незабываемым!',
2);

 --Добавление строк в таблицу
   INSERT INTO Categories(Title)
	VALUES (N'Спорт'),
	(N'Путешествия'),
	(N'Бизнес'),
	(N'Музыка'),
	(N'Рестораны и еда');
  
 -- Добавление таблицы Tags
CREATE TABLE Tags
(
    Id INT IDENTITY(1,1) NOT NULL CONSTRAINT Tags_Id PRIMARY KEY,
    Title Nvarchar(50) NOT NULL,
    IsDeleted TINYINT DEFAULT 1
)

CREATE TABLE "ArticlesTags" (
    "ArticleId" INT NOT NULL,
    "TagId"    INT NOT NULL,
    CONSTRAINT "FK_ArticlesTags_Articles_ArticleId" FOREIGN KEY("ArticleId") REFERENCES "Articles"("Id"),
    CONSTRAINT "FK_ArticlesTags_Tags_TagId" FOREIGN KEY("TagId") REFERENCES "Tags"("Id"),
    CONSTRAINT "PK_ArticlesTags" PRIMARY KEY("ArticleId","TagId")
)

--Добавление строк в таблицу
INSERT INTO Tags (Title)
	VALUES (N'Здоровое питание'),
		(N'Досуг'),
		(N'Для бизнеса'),
		(N'Фотография')

INSERT INTO ArticlesTags (ArticleId, TagId)
	VALUES 
	(6,2), (6,4), (7,4),
	(7,3), (12,1), (12,4)

-- Добавление столбца в таблицу Articles
ALTER TABLE Articles ADD Image varbinary(max);