using Microsoft.EntityFrameworkCore;

namespace VeganGO.Infrastructure
{
    public class EfContext : DbContext
    {
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Utility> Utilities { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }
        public DbSet<RecipeTag> RecipeTags { get; set; }
        public DbSet<UtilityTag> UtilityTags { get; set; }

        public EfContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Tag>().HasIndex(x => x.Name).IsUnique();
            
            modelBuilder.Entity<User>().Property(x => x.Login).IsRequired();
            modelBuilder.Entity<User>().HasIndex(x => x.Login).IsUnique();
            modelBuilder.Entity<User>().Property(x => x.Password).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.FirstName).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.LastName).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.MiddleName).IsRequired();
            modelBuilder.Entity<User>().Property(x => x.PhoneNumber).IsRequired();
            
            modelBuilder.Entity<Recipe>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Recipe>().Property(x => x.Text).IsRequired();
            modelBuilder.Entity<Recipe>().Property(x => x.MainImagePath).IsRequired();
            
            modelBuilder.Entity<Article>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Article>().Property(x => x.Description).IsRequired();
            modelBuilder.Entity<Article>().Property(x => x.Text).IsRequired();
            modelBuilder.Entity<Article>().Property(x => x.MainImagePath).IsRequired();
            
            modelBuilder.Entity<Utility>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Utility>().Property(x => x.Description).IsRequired();
            modelBuilder.Entity<Utility>().Property(x => x.Text).IsRequired();
            modelBuilder.Entity<Utility>().Property(x => x.Author).IsRequired();
            modelBuilder.Entity<Utility>().Property(x => x.MainImagePath).IsRequired();

            modelBuilder.Entity<Article>()
                .HasMany(x => x.Tags)
                .WithMany(x => x.Articles)
                .UsingEntity<ArticleTag>(
                    x => x.HasOne(at => at.Tag).WithMany(),
                    x => x.HasOne(at => at.Article).WithMany())
                .HasKey(x => new { x.ArticleId, x.TagId });
            
            modelBuilder.Entity<Recipe>()
                .HasMany(x => x.Ingredients)
                .WithOne(x => x.Recipe)
                .HasForeignKey(x=>x.RecipeId);
            
            modelBuilder.Entity<Recipe>()
                .HasMany(x => x.Tags)
                .WithMany(x => x.Recipes)
                .UsingEntity<RecipeTag>(
                    x => x.HasOne(rt => rt.Tag).WithMany(),
                    x => x.HasOne(rt => rt.Recipe).WithMany())
                .HasKey(x => new { x.RecipeId, x.TagId });
            
            modelBuilder.Entity<Utility>()
                .HasMany(x => x.Tags)
                .WithMany(x => x.Utilities)
                .UsingEntity<UtilityTag>(
                    x => x.HasOne(rt => rt.Tag).WithMany(),
                    x => x.HasOne(rt => rt.Utility).WithMany())
                .HasKey(x => new { x.UtilityId, x.TagId });

            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}