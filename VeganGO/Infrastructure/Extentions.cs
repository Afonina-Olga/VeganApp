using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace VeganGO.Infrastructure
{
    public static class ModelBuilderExtensions
    {
        private static readonly string _path = Regex.Replace(Directory.GetCurrentDirectory(), "bin.*", "");

        public static void Seed(this ModelBuilder modelBuilder)
        {
            SeedUsers(modelBuilder);
            SeedArticles(modelBuilder);
            SeedUtilities(modelBuilder);
            SeedRecipes(modelBuilder);
        }

        private static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Login = "Admin",
                    Password = "123",
                    FirstName = "Марина",
                    LastName = "Иванова",
                    MiddleName = "Сергеевна",
                    PhoneNumber = "+79261235469",
                    Role = Role.Admin
                }
            );
        }

        private static void SeedArticles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>().HasData(
                new Tag
                {
                    Id = 1,
                    Name = "Защита природы",
                    ArticleRelative = true,
                    UtilityRelative = false,
                    RecipeRelative = false
                },
                new Tag
                {
                    Id = 2,
                    Name = "Защита животных",
                    ArticleRelative = true,
                    UtilityRelative = false,
                    RecipeRelative = false
                },
                new Tag
                {
                    Id = 3,
                    Name = "Образ жизни",
                    ArticleRelative = true,
                    UtilityRelative = false,
                    RecipeRelative = false
                }
            );

            modelBuilder.Entity<ArticleTag>().HasData(
                new ArticleTag { ArticleId = 1, TagId = 1 },
                new ArticleTag { ArticleId = 2, TagId = 2 },
                new ArticleTag { ArticleId = 3, TagId = 2 },
                new ArticleTag { ArticleId = 4, TagId = 2 },
                new ArticleTag { ArticleId = 4, TagId = 3 },
                new ArticleTag { ArticleId = 5, TagId = 3 }
            );

            modelBuilder.Entity<Article>().HasData(
                new Article
                {
                    Id = 1,
                    Description =
                        "Загрязнение Мирового океана пластиковым мусором — одна из самых актуальных глобальных проблем",
                    Name = "Экостартап производит топливо из пластика, собранного в океане",
                    Text = File.ReadAllText(_path + @"/Data/Articles/1.txt"),
                    MainImagePath = "/Images/Articles/image1.jpg"
                },
                new Article
                {
                    Id = 2,
                    Description = "Команда Teddy Food запустила необычный сервис помощи бездомным животным",
                    Name = "В России запущен необычный сервис помощи бездомным животным Teddy Food",
                    Text = File.ReadAllText(_path + @"/Data/Articles/2.txt"),
                    MainImagePath = "/Images/Articles/image2.jpg"
                },
                new Article
                {
                    Id = 3,
                    Description = "Активисты совершали набеги на фермы и проводили мирные протесты по всей Австралии",
                    Name = "Защитники животных могут ударить по мясной индустрии в размере 3,2 млрд долларов",
                    Text = File.ReadAllText(_path + @"/Data/Articles/3.txt"),
                    MainImagePath = "/Images/Articles/image3.jpg"
                },
                new Article
                {
                    Id = 4,
                    Name = "Веганство кошек и собак поможет устойчивому развитию",
                    Description =
                        "Eсли бы американские кошки и собаки основали свою собственную страну, она заняла бы пятое место в мире по потреблению мяса сразу после России, Бразилии, США и Китая",
                    Text = File.ReadAllText(_path + @"/Data/Articles/4.txt"),
                    MainImagePath = "/Images/Articles/image4.jpg"
                },
                new Article
                {
                    Id = 5,
                    Description =
                        @"Фестиваль прошел на площадке 1-го этажа ТЦ ""SILA VOLI"" и привлек к себе большое внимание",
                    Name = "В Екатеринбурге прошел первый вегетарианский фестиваль VEGAN FEST Ekat",
                    Text = File.ReadAllText(_path + @"/Data/Articles/5.txt"),
                    MainImagePath = "/Images/Articles/image5.jpg"
                }
            );
        }

        private static void SeedRecipes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>().HasData(
                new Tag
                {
                    Id = 4,
                    Name = "Десерты",
                    RecipeRelative = true
                },
                new Tag
                {
                    Id = 5,
                    Name = "Супы",
                    RecipeRelative = true
                },
                new Tag
                {
                    Id = 6,
                    Name = "Напитки",
                    RecipeRelative = true
                },
                new Tag
                {
                    Id = 7,
                    Name = "Основные блюда",
                    RecipeRelative = true
                },
                new Tag
                {
                    Id = 8,
                    Name = "Салаты",
                    RecipeRelative = true
                }
            );

            modelBuilder.Entity<RecipeTag>().HasData(
                new List<RecipeTag>
                {
                    new RecipeTag { RecipeId = 1, TagId = 4 },
                    new RecipeTag { RecipeId = 2, TagId = 5 },
                    new RecipeTag { RecipeId = 3, TagId = 6 },
                    new RecipeTag { RecipeId = 4, TagId = 7 },
                    new RecipeTag { RecipeId = 5, TagId = 8 },
                    new RecipeTag { RecipeId = 6, TagId = 4 },
                    new RecipeTag { RecipeId = 7, TagId = 5 },
                    new RecipeTag { RecipeId = 8, TagId = 6 }
                }
            );

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient
                {
                    Id = 1,
                    RecipeId = 1,
                    Name = "молоко кокосовое консервированное 0.5 стак."
                },
                new Ingredient
                {
                    Id = 2,
                    RecipeId = 1,
                    Name = "масло кокосовое 0.25 стак."
                },
                new Ingredient
                {
                    Id = 3,
                    RecipeId = 1,
                    Name = "мука 400 г."
                },
                new Ingredient
                {
                    Id = 4,
                    RecipeId = 1,
                    Name = "сахарный песок — 2 ст. л."
                },
                new Ingredient
                {
                    Id = 5,
                    RecipeId = 1,
                    Name = "сода 1 ч. л."
                },
                new Ingredient
                {
                    Id = 6,
                    RecipeId = 1,
                    Name = "цедра одного лайма"
                },
                new Ingredient
                {
                    Id = 7,
                    RecipeId = 1,
                    Name = "сок лайма 2 ст. л."
                },
                new Ingredient
                {
                    Id = 8,
                    RecipeId = 1,
                    Name = "соль 0.5 ч. л."
                },
                new Ingredient
                {
                    Id = 9,
                    RecipeId = 1,
                    Name = "сахарная пудра 1 стак."
                },
                new Ingredient
                {
                    Id = 10,
                    RecipeId = 1,
                    Name = "масло кокосовое 3 ч. л."
                },
                new Ingredient
                {
                    Id = 11,
                    RecipeId = 1,
                    Name = "сок лайма 3 ч. л."
                },
                new Ingredient
                {
                    Id = 12,
                    RecipeId = 1,
                    Name = "цедра лайма, кокосовая стружка - для украшения"
                },
                new Ingredient { Id = 13, RecipeId = 2, Name = "томаты свежие - 800 г." },
                new Ingredient { Id = 14, RecipeId = 2, Name = "кокосовое молоко - 400 г." },
                new Ingredient { Id = 15, RecipeId = 2, Name = "сладкий репчатый лук - 2 шт." },
                new Ingredient { Id = 16, RecipeId = 2, Name = "масло растительное - 2 ст. л." },
                new Ingredient
                    { Id = 17, RecipeId = 2, Name = "специи (перец чили в хлопьях, паприка) - по 0.5 ч. л." },
                new Ingredient { Id = 18, RecipeId = 2, Name = "черный перец молотый - 1 щеп." },
                new Ingredient { Id = 19, RecipeId = 2, Name = "чеснок сухой (в порошке) - на кончике ножа" },
                new Ingredient { Id = 20, RecipeId = 3, Name = "листья шпината - 1 стак." },
                new Ingredient { Id = 21, RecipeId = 3, Name = "банан - 1 шт." },
                new Ingredient { Id = 22, RecipeId = 3, Name = "овсяные хлопья - 2 ст. л." },
                new Ingredient { Id = 23, RecipeId = 3, Name = "киви - 2 шт." },
                new Ingredient { Id = 24, RecipeId = 3, Name = "рапсовый мед - 1 ст. л." },
                new Ingredient { Id = 25, RecipeId = 3, Name = "минеральная вода - 1 стак." },
                new Ingredient { Id = 26, RecipeId = 4, Name = "шампиньоны - 150 г." },
                new Ingredient { Id = 27, RecipeId = 4, Name = "рис круглозерный - 0.5 стак." },
                new Ingredient { Id = 28, RecipeId = 4, Name = "лук репчатый - 1 шт." },
                new Ingredient { Id = 29, RecipeId = 4, Name = "морковь - 1 шт." },
                new Ingredient { Id = 30, RecipeId = 4, Name = "растительное масло - 2 ст. л." },
                new Ingredient { Id = 31, RecipeId = 4, Name = "мука пшеничная - 2 ст. л." },
                new Ingredient { Id = 32, RecipeId = 4, Name = "соль - по вкусу" },
                new Ingredient { Id = 33, RecipeId = 4, Name = "перец молотый черный - по вкусу" },
                new Ingredient { Id = 34, RecipeId = 5, Name = "консервированная белая фасоль - 1 банка" },
                new Ingredient { Id = 35, RecipeId = 5, Name = "манго - 1 шт." },
                new Ingredient { Id = 36, RecipeId = 5, Name = "микс салатной зелени - 1 упаковка" },
                new Ingredient { Id = 37, RecipeId = 5, Name = "красный репчатый лук - 0.5 шт." },
                new Ingredient { Id = 38, RecipeId = 5, Name = "сок 1/3 лимона" },
                new Ingredient { Id = 39, RecipeId = 5, Name = "специи - по вкусу" },
                new Ingredient { Id = 40, RecipeId = 6, Name = "соевое молоко - 1 стак." },
                new Ingredient { Id = 41, RecipeId = 6, Name = "шпинат замороженный измельченный - 0.75 стак." },
                new Ingredient { Id = 42, RecipeId = 6, Name = "соль - 0.5 ч. л." },
                new Ingredient { Id = 43, RecipeId = 6, Name = "сахар - 1 ч. л." },
                new Ingredient { Id = 44, RecipeId = 6, Name = "разрыхлитель теста - 1 ч. л." },
                new Ingredient { Id = 45, RecipeId = 6, Name = "мука пшеничная - 0.75 стак." },
                new Ingredient { Id = 46, RecipeId = 6, Name = "масло растительное - 0.3 стак." },
                new Ingredient { Id = 47, RecipeId = 7, Name = "тофу, нарезанный кубиками - 1.25 стак." },
                new Ingredient { Id = 48, RecipeId = 7, Name = "кокосовое масло - 1 ст. л." },
                new Ingredient
                    { Id = 49, RecipeId = 7, Name = "красный лук (нарезанный тонкими кольцами) - 0.25 стак." },
                new Ingredient { Id = 50, RecipeId = 7, Name = "желтый перец (нарезанный пластинами) - 0.5 стак." },
                new Ingredient { Id = 51, RecipeId = 7, Name = "красная паста карри - 2 ч. л." },
                new Ingredient { Id = 52, RecipeId = 7, Name = "кокосовое молоко - 350 мл." },
                new Ingredient { Id = 53, RecipeId = 7, Name = "овощной бульон (или вода) - 1 стак." },
                new Ingredient { Id = 54, RecipeId = 7, Name = "стручковая фасоль - 1 стак." },
                new Ingredient { Id = 55, RecipeId = 7, Name = "рисовая лапша - 2 горсти" },
                new Ingredient { Id = 56, RecipeId = 7, Name = "листья базилика - 1 горсть" },
                new Ingredient { Id = 57, RecipeId = 7, Name = "орехи кешью (нарезанные) - по вкусу" },
                new Ingredient { Id = 58, RecipeId = 7, Name = "соевый соус - по вкусу" },
                new Ingredient { Id = 59, RecipeId = 8, Name = "сухая лаванда - 2 ст. л." },
                new Ingredient { Id = 60, RecipeId = 8, Name = "сахар - 0.5 стак." },
                new Ingredient { Id = 61, RecipeId = 8, Name = "сок 3 лимонов" },
                new Ingredient { Id = 62, RecipeId = 8, Name = "вода - 4.5 стак." }
            );

            modelBuilder.Entity<Recipe>().HasData(
                new Recipe
                {
                    Id = 1,
                    Name = "Веганские кокосовые пончики",
                    Text = File.ReadAllText(_path + @"/Data/Recipes/1.txt"),
                    MainImagePath = "/Images/Recipes/image1.jpg"
                },
                new Recipe
                {
                    Id = 2,
                    Name = "Томатный суп-пюре с кокосовым молоком",
                    Text = File.ReadAllText(_path + @"/Data/Recipes/2.txt"),
                    MainImagePath = "/Images/Recipes/image2.jpg"
                },
                new Recipe
                {
                    Id = 3,
                    Name = "Смузи со шпинатом",
                    Text = File.ReadAllText(_path + @"/Data/Recipes/3.txt"),
                    MainImagePath = "/Images/Recipes/image3.jpg"
                },
                new Recipe
                {
                    Id = 4,
                    Name = "Грибные котлеты",
                    Text = File.ReadAllText(_path + @"/Data/Recipes/4.txt"),
                    MainImagePath = "/Images/Recipes/image4.jpg"
                },
                new Recipe
                {
                    Id = 5,
                    Name = "Салат с фасолью и манго",
                    Text = File.ReadAllText(_path + @"/Data/Recipes/5.txt"),
                    MainImagePath = "/Images/Recipes/image5.jpg"
                },
                new Recipe
                {
                    Id = 6,
                    Name = "Оладьи из шпината",
                    Text = File.ReadAllText(_path + @"/Data/Recipes/6.txt"),
                    MainImagePath = "/Images/Recipes/image6.jpg"
                },
                new Recipe
                {
                    Id = 7,
                    Name = "Суп из тофу с лапшой",
                    Text = File.ReadAllText(_path + @"/Data/Recipes/7.txt"),
                    MainImagePath = "/Images/Recipes/image7.jpg"
                },
                new Recipe
                {
                    Id = 8,
                    Name = "Лимонад из лаванды",
                    Text = File.ReadAllText(_path + @"/Data/Recipes/8.txt"),
                    MainImagePath = "/Images/Recipes/image8.jpg"
                }
            );
        }

        private static void SeedUtilities(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>().HasData(
                new List<Tag>
                {
                    new Tag { Id = 9, UtilityRelative = true, Name = "Люди" },
                    new Tag { Id = 10, UtilityRelative = true, Name = "Книги" },
                    new Tag { Id = 11, UtilityRelative = true, Name = "Фильмы" },
                    new Tag { Id = 12, UtilityRelative = true, Name = "Бренды" },
                    new Tag { Id = 13, UtilityRelative = true, Name = "Маркировки" }
                }
            );

            modelBuilder.Entity<UtilityTag>().HasData(
                new List<UtilityTag>
                {
                    new UtilityTag { TagId = 9, UtilityId = 1 },
                    new UtilityTag { TagId = 9, UtilityId = 2 },
                    new UtilityTag { TagId = 10, UtilityId = 3 },
                    new UtilityTag { TagId = 11, UtilityId = 4 },
                    new UtilityTag { TagId = 12, UtilityId = 5 },
                    new UtilityTag { TagId = 13, UtilityId = 6 },
                    new UtilityTag { TagId = 9, UtilityId = 7 }
                }
            );

            modelBuilder.Entity<Utility>().HasData(
                new Utility
                {
                    Id = 1,
                    Author = "Автор",
                    PublishDate = DateTime.Now,
                    Name = "Трэвис Баркер",
                    Description = "Вегетарианец",
                    Text =
                        "Барабанщик, известен, прежде всего, по работе в поп-панк-группе blink-182. Начал играть на ударных в 4 года, 32-й номер в списке 50-ти величайших барабанщиков рока. Дочь Трэвиса, Алабама Баркер, растёт вегетарианкой и очень любит животных.",
                    MainImagePath = "/Images/Utilities/image1.jpg"
                },
                new Utility
                {
                    Id = 2,
                    Author = "Автор",
                    PublishDate = DateTime.Now,
                    Name = "Арнольд Шварценеггер",
                    Description = "Вегетарианец",
                    MainImagePath = "/Images/Utilities/image2.jpg",
                    Text =
                        "Американский культурист, бизнесмен и актёр австрийского происхождения, политик-республиканец, 38-й губернатор Калифорнии. Он был избран на эту должность в октябре 2003 года и переизбран на второй срок в 2006 году."
                },
                new Utility
                {
                    Id = 3,
                    Author = "Автор",
                    PublishDate = DateTime.Now,
                    Name = "Скрытые: животные в антропоцене (2020)",
                    Description =
                        "Непоколебимая книга фотографий о нашем конфликте с нечеловеческими животными по всему миру",
                    MainImagePath = "/Images/Utilities/image3.jpg",
                    Text =
                        "Непоколебимая книга фотографий о нашем конфликте с нечеловеческими животными по всему миру, показанном через линзы тридцати отмеченных наградами фотожурналистов, в том числе Айтора Гармендиа,Джо-Энн Макартур и Эндрю Скоурона. Через линзы тридцати фотожурналистов эта книга проливает свет на невидимых животных в нашей жизни; тех, с кем у нас близкие отношения и тех, кого мы пока не видим. Истории на её страницах откровенны и жестки. Они являются доказательством чрезвычайной ситуации, с которой сталкиваются животные во всем мире, от промышленного фермерства до изменения климата, и дают ценную информацию о значении страданий животных для здоровья человека. Скрытые: животные в антропоцене — это исторический документ, мемориал и обвинительный акт о том, что есть и никогда не должно быть."
                },
                new Utility
                {
                    Id = 4,
                    Author = "Автор",
                    PublishDate = DateTime.Now,
                    Name = "Свобода (2020)",
                    MainImagePath = "/Images/Utilities/image4.jpg",
                    Description =
                        "Короткометражный фильм LIBERTY рассказывает историю как животных перевезли в Farm Sanctuary в Актоне, Калифорния.",
                    Text =
                        "В понедельник, 11 февраля 2020 года, на следующее утро после получения премии «Оскар» за лучшую мужскую роль второго плана в фильме «Джокер», Хоакин Феникс встретился с владельцем упаковочного цеха в Лос-Анджелесе, который согласился освободить теленка и его мать, родившихся на бойне. Короткометражный фильм LIBERTY рассказывает историю той встречи и того, как животных перевезли в Farm Sanctuary в Актоне, Калифорния."
                },
                new Utility
                {
                    Id = 5,
                    Author = "Автор",
                    PublishDate = DateTime.Now,
                    Name = "Порнофильмы",
                    MainImagePath = "/Images/Utilities/image5.jpg",
                    Description = "Все участники группы — вегетарианцы, не употребляют алкоголь, наркотики и не курят.",
                    Text =
                        "Российская панк группа из города Дубна, основанная в 2008 году. Коллектив выделяется на фоне других российских панк-рок групп сильно политизированными текстами песен, а также пропагандой здорового образа жизни, все участники группы — вегетарианцы, не употребляют алкоголь, наркотики и не курят."
                },
                new Utility
                {
                    Id = 6,
                    Author = "Автор",
                    PublishDate = DateTime.Now,
                    Name = "PETA’s Beauty Without Bunnies",
                    MainImagePath = "/Images/Utilities/image6.jpg",
                    Description = "Крупнейшая в мире организация по защите прав животных",
                    Text =
                        "Крупнейшая в мире организация по защите прав животных, насчитывающая более 6,5 миллионов членов и сторонников. «PETA» уделяет основное внимание четырём областям, в которых животные страдают больше всего: пищевой промышленности, торговле одеждой, лабораториям и в индустрии развлечений."
                },
                new Utility
                {
                    Id = 7,
                    Author = "Автор",
                    PublishDate = DateTime.Now,
                    Name = "Никола Тесла",
                    MainImagePath = "/Images/Utilities/image7.jpg",
                    Description = "Цитата",
                    Text =
                        "То, что мы можем существовать на растительном рационе, работать и даже преуспевать — не просто теория, а хорошо продемонстрированный факт. Представители множества народов, живущих практически на одной растительной пище, обладают превосходным телосложением и силой."
                });
        }
    }
}