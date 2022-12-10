using System;
using System.Collections.Generic;

namespace VeganGO.Infrastructure
{
    public class Entity
    {
        public int Id { get; set; }
    }

    public class Tag : Entity
    {
        public string Name { get; set; }
        public bool ArticleRelative { get; set; }
        public bool UtilityRelative { get; set; }
        public bool RecipeRelative { get; set; }
        public virtual  List<Article> Articles { get; set; }
        public  virtual List<Recipe> Recipes { get; set; }
        public  virtual List<Utility> Utilities { get; set; }
    }

    public enum Role
    {
        Admin,
        User
    }

    public class User : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string Login { get; set; }

        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }
    }

    public class Ingredient : Entity
    {
        public string Name { get; set; }
        public virtual Recipe Recipe { get; set; }
        public int RecipeId { get; set; }
    }

    public class Recipe : Entity
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string MainImagePath { get; set; }
        public virtual List<Tag> Tags { get; set; }
        public virtual List<Ingredient> Ingredients { get; set; }
    }

    public class Article : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public string MainImagePath { get; set; }
        public virtual List<Tag> Tags { get; set; }
    }

    public class ArticleTag
    {
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }

    public class Utility : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public string MainImagePath { get; set; }
        public virtual List<Tag> Tags { get; set; }
    }

    public class RecipeTag
    {
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }

    public class UtilityTag
     {
         public int UtilityId { get; set; }
         public virtual Utility Utility { get; set; }
         public int TagId { get; set; }
         public virtual Tag Tag { get; set; }
     }
}