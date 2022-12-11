using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VeganGO.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    MainImagePath = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    MainImagePath = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ArticleRelative = table.Column<bool>(type: "INTEGER", nullable: false),
                    UtilityRelative = table.Column<bool>(type: "INTEGER", nullable: false),
                    RecipeRelative = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", nullable: false),
                    Login = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MainImagePath = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    RecipeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleTags",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTags", x => new { x.ArticleId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ArticleTags_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeTags",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeTags", x => new { x.RecipeId, x.TagId });
                    table.ForeignKey(
                        name: "FK_RecipeTags_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UtilityTags",
                columns: table => new
                {
                    UtilityId = table.Column<int>(type: "INTEGER", nullable: false),
                    TagId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UtilityTags", x => new { x.UtilityId, x.TagId });
                    table.ForeignKey(
                        name: "FK_UtilityTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UtilityTags_Utilities_UtilityId",
                        column: x => x.UtilityId,
                        principalTable: "Utilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Description", "MainImagePath", "Name", "Text" },
                values: new object[] { 1, "Загрязнение Мирового океана пластиковым мусором — одна из самых актуальных глобальных проблем", "/Images/Articles/image1.jpg", "Экостартап производит топливо из пластика, собранного в океане", "Загрязнение Мирового океана пластиковым мусором — одна из самых актуальных глобальных проблем. Вариант её решения предлагает американский экостартап «The Clean Oceans International»: разработанная ими установка способна превратить пластиковые отходы в углеводородное топливо.\r\nАвторы проекта — моряк Джеймс Холм и химик Сваминатан Рамеш. Используемая технология основана на принципе пиролиза: пластик разрушается и деполимеризируется. Устройство представляет собой металлоценовый катализатор, преимущество которого в том, что дополнительно очищать полученное топливо не требуется.\r\nУстановка мобильна и может применяться как на берегу, так и на борту плавательного средства. За 10 часов вполне реально переработать от 90 до 4 500 килограмм пластика. Дизельное топливо из мусора пригодно и для автомобилей, и для судов. Презентация установки состоится в ближайшее время на 253-й национальной встрече и выставке Американского химического общества (ACS) в Калифорнии.\r\nВ настоящий момент в океане уже находится не менее 150 млн тонн пластика и количество его растёт с каждым днём." });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Description", "MainImagePath", "Name", "Text" },
                values: new object[] { 2, "Команда Teddy Food запустила необычный сервис помощи бездомным животным", "/Images/Articles/image2.jpg", "В России запущен необычный сервис помощи бездомным животным Teddy Food", "18 мая команда Teddy Food запустила необычный сервис помощи бездомным животным. Благодаря ему можно выбрать бездомного питомца, заказать услугу и проследить за ее выполнением в режиме реального времени. При этом вы получите интересные звания и баллы за свою помощь. Стоимость услуг начинается от 15 рублей.\r\nСвоей высшей целью основатели проекта считают — помочь как можно большому числу животных обрести настоящие дома и реальных хозяев. Поэтому сервис такой яркий и с запоминающейся айдентикой.\r\nПроекту активно помогают различные компании. Например, брендинговое агентство «Punk You Brands» сделало для TEDDY FOOD фирменную айдентику бесплатно, корм с мировым именем «Acana» стал информационным партнером проекта, а международное рекламное агентство «Ogilvy&Mather Russia» помогает сейчас в продвижении проекта.\r\n" });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Description", "MainImagePath", "Name", "Text" },
                values: new object[] { 3, "Активисты совершали набеги на фермы и проводили мирные протесты по всей Австралии", "/Images/Articles/image3.jpg", "Защитники животных могут ударить по мясной индустрии в размере 3,2 млрд долларов", "Жаклин Баптиста, менеджер по взаимодействию с сообществом в Meat and Livestock Australia (MLA), рассказала о «вызове растущему веганскому движению». По её словам, животноводство, которое сейчас стоит 15 миллиардов долларов, потеряет 3,8 миллиарда к 2030 году, и 84% из них — это результат не-адаптации к изменению потребительских настроений, связанных с благополучием животных.\r\nАктивисты совершали набеги на фермы и проводили мирные протесты по всей Австралии, чтобы повысить осведомленность людей о жестокости, связанной с мясной, молочной и яичной индустрией. \r\nВ своём заявлении активисты некоммерческой организации по правам животных Animal Liberation Victoria заявили, что «были бы рады увидеть, как промышленность раскроет свои практики», но также отметили, что «траектория веганского движения» не будет спадать." });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Description", "MainImagePath", "Name", "Text" },
                values: new object[] { 4, "Eсли бы американские кошки и собаки основали свою собственную страну, она заняла бы пятое место в мире по потреблению мяса сразу после России, Бразилии, США и Китая", "/Images/Articles/image4.jpg", "Веганство кошек и собак поможет устойчивому развитию", "Согласно исследованию 2017 года, если бы американские кошки и собаки основали свою собственную страну, она заняла бы пятое место в мире по потреблению мяса сразу после России, Бразилии, США и Китая.\r\nВ том же исследовании подсчитано влияние рациона домашних животных на климат: оно сопоставимо с выбросами от 13,6 миллионов автомобилей. Более того, в конце 2018 года аналогичные данные были получены из Японии, где углеродный след кормов для кошек и собак превышает общие выбросы таких стран, как Латвия и Камбоджа.\r\nАргумент о том, что переводить кошек и собак на веганство нельзя, потому что это как-то неестественно, также не оправдывает себя. Если мы используем аргумент «естественности», давайте взглянем на наших проглистогоненных, очищенных от микробов щенков и котят, которые бездельничают на удобных диванах, иногда даже в костюмах для Хэллоуина. Не очень естественно, правда?\r\n\r\nОсновные постулаты научных исследований о питании кошек и собак\r\nСбалансированные веганские корма подходят как собакам, так и кошкам.\r\nЖивотные на таких кормах живут столь же продолжительной и качественной жизнью, как и на премиальных мясных.\r\nПри любом питании у животных возможны проблемы со здоровьем (и при естественном, когда они ловят и едят жертву, тоже).\r\nПромышленные мясные корма, даже высокого качества, могут повлечь за собой ряд последствий точно также, как и веганские корма.\r\nИдеального корма до сих пор нет (да, к мясным это тоже относится).\r\nНам точно не нужно переводить на веганство своих домашних животных в одночасье. Но мы всегда можем сделать шаг навстречу более экологичному и гуманному их содержанию." });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Description", "MainImagePath", "Name", "Text" },
                values: new object[] { 5, "Фестиваль прошел на площадке 1-го этажа ТЦ \"SILA VOLI\" и привлек к себе большое внимание", "/Images/Articles/image5.jpg", "В Екатеринбурге прошел первый вегетарианский фестиваль VEGAN FEST Ekat", "Фестиваль прошел на площадке 1-го этажа  ТЦ \"SILA VOLI\" и привлек к себе большое внимание. Инициативные волонтеры и организаторы проводили кулинарные мастер-классы, занятия  спортивно-телесной практикой, читали лекции. Вся информация была легка для понимания и доступна всем.\r\n\r\n\"BuDa&Friends\" порадовали нас живой музыкой на барабанах, диджериду, флейте и фуяре, а кафе \"VegBurger\" - вкусной и полезной едой. Состоялся финал конкурса \"Мисс Веган\", а также другие розыгрыши. Не остался без внимания и фильм Колина Серро \"Прекрасная зеленая\" в КиноКлубе.\r\n\r\nНеравнодушными волонтерами был организован сбор средств для бездомных животных. Для семей с маленькими детьми работала детская площадка, детская йога и лекция-беседа \"Дети вегетарианцы\". И конечно же, своей пестротой не могла не привлечь внимание ярмарка этичной еды, одежды и других товаров, которая действовала на протяжении всего фестиваля.\r\n\r\nVEGAN FEST - это возможность узнать больше единомышленников в сфере здорового этичного питания и образа жизни, возможность получить много полезной информации и поделиться своим опытом с другими, возможность завести новых друзей, а для организаторов - замечательные условия для презентаций своих услуг и товаров!" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "MainImagePath", "Name", "Text" },
                values: new object[] { 8, "/Images/Recipes/image8.jpg", "Лимонад из лаванды", "В емкость среднего размера влейте 2.5 стакана воды, добавьте сахар и лаванду, хорошо перемешайте.\r\nДоведите полученную смесь до кипения, затем уменьшите огонь и варите в течение пяти минут. После, выключите огонь полностью и дайте настояться 1 час.\r\nПропустите жидкость через сито, очистив от лаванды, перелейте в большую емкость.\r\nДобавьте лимонный сок, оставшееся количество воды и хорошо перемешайте.\r\nПоместите жидкость в холодильник до полного охлаждения. Подавайте лимонад с кубиками льда." });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "MainImagePath", "Name", "Text" },
                values: new object[] { 7, "/Images/Recipes/image7.jpg", "Суп из тофу с лапшой", "В большой жаровне с высокими бортами или сковороде разогрейте кокосовое масло на среднем или сильном огне. Бросьте на сковороду тофу, красный лук и перец, обжаривая до появления мягкости лука.\r\nДобавьте пасту карри и перемешайте, так, чтобы сыр и овощи в нее окунулись.\r\nВлейте кокосовое молоко, воду (бульон) и засыпьте зеленую фасоль. Доведите смесь до кипения и добавьте рисовую лапшу. Тушите блюдо 2-3 минуты пока лапша не станет мягкой." });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "MainImagePath", "Name", "Text" },
                values: new object[] { 6, "/Images/Recipes/image6.jpg", "Оладьи из шпината", "Шпинат для оладий необходимо разморозить. Выделившуюся воду слить. При желании шпинат можно пробить блендером, если необходимо получить однородную текстуру, или же оставить кусочками.\r\nК шпинату добавить соевое молоко и тщательно перемешать. Посолить и добавить сахар. Влить растительное масло и взбить венчиком.\r\nМуку просеять, добавить разрыхлитель и перемешать. Небольшими порциями добавить мучную смесь и аккуратно перемешать до однородного состояния. Масса должна получиться довольно густой.\r\nСковороду, смазанную растительным маслом, хорошо разогреть. Тесто тщательно перемешать, чтобы шпинат не оседал вниз. Налить немного теста на сковороду, формируя оладушек. Выпечь до легкого золотистого цвета и перевернуть на другую сторону. Подобным образом приготовить оладьи из всего теста.\r\n" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "MainImagePath", "Name", "Text" },
                values: new object[] { 5, "/Images/Recipes/image5.jpg", "Салат с фасолью и манго", "Очистить манго от кожицы и нарезать средними кубиками.\r\nЛуковицу нарезать кубиками, схожими по размеру с манго.\r\nПереложить фасоль в дуршлаг и промыть кипяченой водой.\r\nСмешать все продукты в одной емкости, добавить специи." });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "MainImagePath", "Name", "Text" },
                values: new object[] { 3, "/Images/Recipes/image3.jpg", "Смузи со шпинатом", "Шпинат мелко нарезать, банан и киви очистить от кожуры. Все составляющие, кроме воды, поместить в блендер и перемешивать 15 секунд на показателе «турбо». Потом открыть блендер, добавить воды и перемешивать еще 10 секунд. Перелить в стаканы. Также можно добавить по кусочку льда." });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "MainImagePath", "Name", "Text" },
                values: new object[] { 2, "/Images/Recipes/image2.jpg", "Томатный суп-пюре с кокосовым молоком", "Тонко нарезать луковицы и выложить в масло. Обжарить до полупрозрачного состояния.\r\nТоматы измельчить, переложить в кастрюлю и перемешать. Довести содержимое до кипения и варить в течение 5 мин. Томаты размягчатся и впитают в себя ароматы специй.\r\nПоместить томатную смесь в чашу блендера. Долить кокосового молока. Перемешать.\r\nНа высокой скорости взбить до пюреобразного состояния. Добавить специи по своему усмотрению.\r\nПодавать суп сразу после приготовления, присыпав свежей зеленью." });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "MainImagePath", "Name", "Text" },
                values: new object[] { 1, "/Images/Recipes/image1.jpg", "Веганские кокосовые пончики", "В кокосовое молоко добавить сок лайма. После перемешивания оставить на 5 минут.\r\nРастопить кокосовое масло, смешать с сахаром.\r\nСмешать обе массы и добавить цедру лайма.\r\nВ просеянную муку добавить гашеную соду, присолить. Всыпать небольшими порциями в кокосовую массу, замешав тесто однородной консистенции.\r\nС помощью кондитерского мешка заполняем полученным тестом специальные формы для выпекания пончиков с отверстием посередине. Пончики увеличатся в объеме, поэтому формы должны быть заполнены на 2/3.\r\nВыпекать в духовом шкафу, разогретом до температуры 180 градусов. Время выпечки — 15 минут.\r\nДля глазури смешать сахарную пудру с растопленным кокосовым маслом.\r\nМедленно добавить сок лайма. Перемешать. Окунуть пончики с одной стороны в полученную глазурь* и выложить на пергаментную бумагу. Сверху присыпать цедрой лайма и стружкой кокоса." });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "MainImagePath", "Name", "Text" },
                values: new object[] { 4, "/Images/Recipes/image4.jpg", "Грибные котлеты", "Первоначально необходимо отварить рис. В данном случае он должен приобрести вязкую консистенцию. Рассыпчатые сорта риса не подойдут, так как котлеты с ними будут разваливаться. Готовый рис выложить на дуршлаг, слегка промыть холодной водой и дать ей полностью стечь.\r\nЛук и морковь очистить и тщательно промыть под проточной водой. Морковь нашинковать, а лук мелко порубить. Шампиньоны ополоснуть, очистить от тонкой верхней шкурки и нарезать небольшими ломтиками.\r\nВ сковороде прогреть 1 ст.л. масла, добавить шампиньоны, лук и морковь. Готовить на медленном огне до мягкости овощей.\r\nВ чаше смешать рис с овощами и грибами. Добавить соль, перец и снова хорошо перемешать фарш. Добавить 1 ст.л. муки и снова все перемешать. Должна получиться вязкая, но густая масса, из которой можно легко сформировать биточки.\r\nИз получившейся массы сформировать небольшие котлеты и обвалять в манке или муке. В сотейнике разогреть 1 ст.л. масла и выложить котлеты с грибной начинкой. Обжарить до красивой золотистой корочки с двух сторон." });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "ArticleRelative", "Name", "RecipeRelative", "UtilityRelative" },
                values: new object[] { 4, false, "Десерты", true, false });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "ArticleRelative", "Name", "RecipeRelative", "UtilityRelative" },
                values: new object[] { 8, false, "Салаты", true, false });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "ArticleRelative", "Name", "RecipeRelative", "UtilityRelative" },
                values: new object[] { 7, false, "Основные блюда", true, false });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "ArticleRelative", "Name", "RecipeRelative", "UtilityRelative" },
                values: new object[] { 6, false, "Напитки", true, false });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "ArticleRelative", "Name", "RecipeRelative", "UtilityRelative" },
                values: new object[] { 5, false, "Супы", true, false });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "ArticleRelative", "Name", "RecipeRelative", "UtilityRelative" },
                values: new object[] { 13, false, "Маркировки", false, true });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "ArticleRelative", "Name", "RecipeRelative", "UtilityRelative" },
                values: new object[] { 9, false, "Люди", false, true });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "ArticleRelative", "Name", "RecipeRelative", "UtilityRelative" },
                values: new object[] { 11, false, "Фильмы", false, true });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "ArticleRelative", "Name", "RecipeRelative", "UtilityRelative" },
                values: new object[] { 10, false, "Книги", false, true });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "ArticleRelative", "Name", "RecipeRelative", "UtilityRelative" },
                values: new object[] { 3, true, "Образ жизни", false, false });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "ArticleRelative", "Name", "RecipeRelative", "UtilityRelative" },
                values: new object[] { 2, true, "Защита животных", false, false });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "ArticleRelative", "Name", "RecipeRelative", "UtilityRelative" },
                values: new object[] { 1, true, "Защита природы", false, false });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "ArticleRelative", "Name", "RecipeRelative", "UtilityRelative" },
                values: new object[] { 12, false, "Бренды", false, true });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Login", "MiddleName", "Password", "PhoneNumber", "Role" },
                values: new object[] { 1, "Марина", "Иванова", "Admin", "Сергеевна", "123", "+79261235469", 0 });

            migrationBuilder.InsertData(
                table: "Utilities",
                columns: new[] { "Id", "Author", "Description", "MainImagePath", "Name", "PublishDate", "Text" },
                values: new object[] { 6, "Автор", "Крупнейшая в мире организация по защите прав животных", "/Images/Utilities/image6.jpg", "PETA’s Beauty Without Bunnies", new DateTime(2022, 12, 10, 15, 47, 33, 843, DateTimeKind.Local).AddTicks(4892), "Крупнейшая в мире организация по защите прав животных, насчитывающая более 6,5 миллионов членов и сторонников. «PETA» уделяет основное внимание четырём областям, в которых животные страдают больше всего: пищевой промышленности, торговле одеждой, лабораториям и в индустрии развлечений." });

            migrationBuilder.InsertData(
                table: "Utilities",
                columns: new[] { "Id", "Author", "Description", "MainImagePath", "Name", "PublishDate", "Text" },
                values: new object[] { 1, "Автор", "Вегетарианец", "/Images/Utilities/image1.jpg", "Трэвис Баркер", new DateTime(2022, 12, 10, 15, 47, 33, 842, DateTimeKind.Local).AddTicks(9210), "Барабанщик, известен, прежде всего, по работе в поп-панк-группе blink-182. Начал играть на ударных в 4 года, 32-й номер в списке 50-ти величайших барабанщиков рока. Дочь Трэвиса, Алабама Баркер, растёт вегетарианкой и очень любит животных." });

            migrationBuilder.InsertData(
                table: "Utilities",
                columns: new[] { "Id", "Author", "Description", "MainImagePath", "Name", "PublishDate", "Text" },
                values: new object[] { 2, "Автор", "Вегетарианец", "/Images/Utilities/image2.jpg", "Арнольд Шварценеггер", new DateTime(2022, 12, 10, 15, 47, 33, 843, DateTimeKind.Local).AddTicks(4838), "Американский культурист, бизнесмен и актёр австрийского происхождения, политик-республиканец, 38-й губернатор Калифорнии. Он был избран на эту должность в октябре 2003 года и переизбран на второй срок в 2006 году." });

            migrationBuilder.InsertData(
                table: "Utilities",
                columns: new[] { "Id", "Author", "Description", "MainImagePath", "Name", "PublishDate", "Text" },
                values: new object[] { 3, "Автор", "Непоколебимая книга фотографий о нашем конфликте с нечеловеческими животными по всему миру", "/Images/Utilities/image3.jpg", "Скрытые: животные в антропоцене (2020)", new DateTime(2022, 12, 10, 15, 47, 33, 843, DateTimeKind.Local).AddTicks(4887), "Непоколебимая книга фотографий о нашем конфликте с нечеловеческими животными по всему миру, показанном через линзы тридцати отмеченных наградами фотожурналистов, в том числе Айтора Гармендиа,Джо-Энн Макартур и Эндрю Скоурона. Через линзы тридцати фотожурналистов эта книга проливает свет на невидимых животных в нашей жизни; тех, с кем у нас близкие отношения и тех, кого мы пока не видим. Истории на её страницах откровенны и жестки. Они являются доказательством чрезвычайной ситуации, с которой сталкиваются животные во всем мире, от промышленного фермерства до изменения климата, и дают ценную информацию о значении страданий животных для здоровья человека. Скрытые: животные в антропоцене — это исторический документ, мемориал и обвинительный акт о том, что есть и никогда не должно быть." });

            migrationBuilder.InsertData(
                table: "Utilities",
                columns: new[] { "Id", "Author", "Description", "MainImagePath", "Name", "PublishDate", "Text" },
                values: new object[] { 4, "Автор", "Короткометражный фильм LIBERTY рассказывает историю как животных перевезли в Farm Sanctuary в Актоне, Калифорния.", "/Images/Utilities/image4.jpg", "Свобода (2020)", new DateTime(2022, 12, 10, 15, 47, 33, 843, DateTimeKind.Local).AddTicks(4890), "В понедельник, 11 февраля 2020 года, на следующее утро после получения премии «Оскар» за лучшую мужскую роль второго плана в фильме «Джокер», Хоакин Феникс встретился с владельцем упаковочного цеха в Лос-Анджелесе, который согласился освободить теленка и его мать, родившихся на бойне. Короткометражный фильм LIBERTY рассказывает историю той встречи и того, как животных перевезли в Farm Sanctuary в Актоне, Калифорния." });

            migrationBuilder.InsertData(
                table: "Utilities",
                columns: new[] { "Id", "Author", "Description", "MainImagePath", "Name", "PublishDate", "Text" },
                values: new object[] { 5, "Автор", "Все участники группы — вегетарианцы, не употребляют алкоголь, наркотики и не курят.", "/Images/Utilities/image5.jpg", "Порнофильмы", new DateTime(2022, 12, 10, 15, 47, 33, 843, DateTimeKind.Local).AddTicks(4891), "Российская панк группа из города Дубна, основанная в 2008 году. Коллектив выделяется на фоне других российских панк-рок групп сильно политизированными текстами песен, а также пропагандой здорового образа жизни, все участники группы — вегетарианцы, не употребляют алкоголь, наркотики и не курят." });

            migrationBuilder.InsertData(
                table: "Utilities",
                columns: new[] { "Id", "Author", "Description", "MainImagePath", "Name", "PublishDate", "Text" },
                values: new object[] { 7, "Автор", "Цитата", "/Images/Utilities/image7.jpg", "Никола Тесла", new DateTime(2022, 12, 10, 15, 47, 33, 843, DateTimeKind.Local).AddTicks(4894), "То, что мы можем существовать на растительном рационе, работать и даже преуспевать — не просто теория, а хорошо продемонстрированный факт. Представители множества народов, живущих практически на одной растительной пище, обладают превосходным телосложением и силой." });

            migrationBuilder.InsertData(
                table: "ArticleTags",
                columns: new[] { "ArticleId", "TagId" },
                values: new object[] { 5, 3 });

            migrationBuilder.InsertData(
                table: "ArticleTags",
                columns: new[] { "ArticleId", "TagId" },
                values: new object[] { 4, 3 });

            migrationBuilder.InsertData(
                table: "ArticleTags",
                columns: new[] { "ArticleId", "TagId" },
                values: new object[] { 4, 2 });

            migrationBuilder.InsertData(
                table: "ArticleTags",
                columns: new[] { "ArticleId", "TagId" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "ArticleTags",
                columns: new[] { "ArticleId", "TagId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "ArticleTags",
                columns: new[] { "ArticleId", "TagId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 1, "молоко кокосовое консервированное 0.5 стак.", 1 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 47, "тофу, нарезанный кубиками - 1.25 стак.", 7 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 46, "масло растительное - 0.3 стак.", 6 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 45, "мука пшеничная - 0.75 стак.", 6 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 44, "разрыхлитель теста - 1 ч. л.", 6 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 43, "сахар - 1 ч. л.", 6 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 39, "специи - по вкусу", 5 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 40, "соевое молоко - 1 стак.", 6 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 48, "кокосовое масло - 1 ст. л.", 7 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 38, "сок 1/3 лимона", 5 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 37, "красный репчатый лук - 0.5 шт.", 5 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 41, "шпинат замороженный измельченный - 0.75 стак.", 6 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 49, "красный лук (нарезанный тонкими кольцами) - 0.25 стак.", 7 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 53, "овощной бульон (или вода) - 1 стак.", 7 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 51, "красная паста карри - 2 ч. л.", 7 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 52, "кокосовое молоко - 350 мл.", 7 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 36, "микс салатной зелени - 1 упаковка", 5 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 54, "стручковая фасоль - 1 стак.", 7 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 55, "рисовая лапша - 2 горсти", 7 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 56, "листья базилика - 1 горсть", 7 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 57, "орехи кешью (нарезанные) - по вкусу", 7 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 58, "соевый соус - по вкусу", 7 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 59, "сухая лаванда - 2 ст. л.", 8 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 60, "сахар - 0.5 стак.", 8 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 61, "сок 3 лимонов", 8 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 62, "вода - 4.5 стак.", 8 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 50, "желтый перец (нарезанный пластинами) - 0.5 стак.", 7 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 35, "манго - 1 шт.", 5 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 42, "соль - 0.5 ч. л.", 6 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 33, "перец молотый черный - по вкусу", 4 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 15, "сладкий репчатый лук - 2 шт.", 2 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 14, "кокосовое молоко - 400 г.", 2 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 13, "томаты свежие - 800 г.", 2 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 12, "цедра лайма, кокосовая стружка - для украшения", 1 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 34, "консервированная белая фасоль - 1 банка", 5 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 10, "масло кокосовое 3 ч. л.", 1 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 16, "масло растительное - 2 ст. л.", 2 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 9, "сахарная пудра 1 стак.", 1 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 7, "сок лайма 2 ст. л.", 1 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 6, "цедра одного лайма", 1 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 5, "сода 1 ч. л.", 1 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 4, "сахарный песок — 2 ст. л.", 1 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 3, "мука 400 г.", 1 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 2, "масло кокосовое 0.25 стак.", 1 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 8, "соль 0.5 ч. л.", 1 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 17, "специи (перец чили в хлопьях, паприка) - по 0.5 ч. л.", 2 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 11, "сок лайма 3 ч. л.", 1 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 19, "чеснок сухой (в порошке) - на кончике ножа", 2 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 18, "черный перец молотый - 1 щеп.", 2 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 31, "мука пшеничная - 2 ст. л.", 4 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 30, "растительное масло - 2 ст. л.", 4 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 29, "морковь - 1 шт.", 4 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 28, "лук репчатый - 1 шт.", 4 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 27, "рис круглозерный - 0.5 стак.", 4 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 32, "соль - по вкусу", 4 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 25, "минеральная вода - 1 стак.", 3 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 24, "рапсовый мед - 1 ст. л.", 3 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 23, "киви - 2 шт.", 3 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 22, "овсяные хлопья - 2 ст. л.", 3 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 21, "банан - 1 шт.", 3 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 20, "листья шпината - 1 стак.", 3 });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "RecipeId" },
                values: new object[] { 26, "шампиньоны - 150 г.", 4 });

            migrationBuilder.InsertData(
                table: "RecipeTags",
                columns: new[] { "RecipeId", "TagId" },
                values: new object[] { 5, 8 });

            migrationBuilder.InsertData(
                table: "RecipeTags",
                columns: new[] { "RecipeId", "TagId" },
                values: new object[] { 4, 7 });

            migrationBuilder.InsertData(
                table: "RecipeTags",
                columns: new[] { "RecipeId", "TagId" },
                values: new object[] { 8, 6 });

            migrationBuilder.InsertData(
                table: "RecipeTags",
                columns: new[] { "RecipeId", "TagId" },
                values: new object[] { 3, 6 });

            migrationBuilder.InsertData(
                table: "RecipeTags",
                columns: new[] { "RecipeId", "TagId" },
                values: new object[] { 7, 5 });

            migrationBuilder.InsertData(
                table: "RecipeTags",
                columns: new[] { "RecipeId", "TagId" },
                values: new object[] { 6, 4 });

            migrationBuilder.InsertData(
                table: "RecipeTags",
                columns: new[] { "RecipeId", "TagId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "RecipeTags",
                columns: new[] { "RecipeId", "TagId" },
                values: new object[] { 2, 5 });

            migrationBuilder.InsertData(
                table: "UtilityTags",
                columns: new[] { "TagId", "UtilityId" },
                values: new object[] { 13, 6 });

            migrationBuilder.InsertData(
                table: "UtilityTags",
                columns: new[] { "TagId", "UtilityId" },
                values: new object[] { 9, 1 });

            migrationBuilder.InsertData(
                table: "UtilityTags",
                columns: new[] { "TagId", "UtilityId" },
                values: new object[] { 9, 2 });

            migrationBuilder.InsertData(
                table: "UtilityTags",
                columns: new[] { "TagId", "UtilityId" },
                values: new object[] { 10, 3 });

            migrationBuilder.InsertData(
                table: "UtilityTags",
                columns: new[] { "TagId", "UtilityId" },
                values: new object[] { 11, 4 });

            migrationBuilder.InsertData(
                table: "UtilityTags",
                columns: new[] { "TagId", "UtilityId" },
                values: new object[] { 12, 5 });

            migrationBuilder.InsertData(
                table: "UtilityTags",
                columns: new[] { "TagId", "UtilityId" },
                values: new object[] { 9, 7 });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTags_TagId",
                table: "ArticleTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeTags_TagId",
                table: "RecipeTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_Name",
                table: "Tags",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UtilityTags_TagId",
                table: "UtilityTags",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleTags");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "RecipeTags");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UtilityTags");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Utilities");
        }
    }
}
