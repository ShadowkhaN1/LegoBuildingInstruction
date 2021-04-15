using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<BuildingInstruction> BuildingInstructions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DifficultyLevel> DifficultyLevels { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Mindstorms" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "WeDo" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Power Function" });



            modelBuilder.Entity<DifficultyLevel>().HasData(new DifficultyLevel { Id = 1, Name = "Easy" });
            modelBuilder.Entity<DifficultyLevel>().HasData(new DifficultyLevel { Id = 2, Name = "Normal" });
            modelBuilder.Entity<DifficultyLevel>().HasData(new DifficultyLevel { Id = 3, Name = "Hard" });



            modelBuilder.Entity<BuildingInstruction>().HasData(new BuildingInstruction
            {
                Id = 1,
                CategoryId = 1,
                Name = "Lifter",
                Pages = 52,
                Set = "45544 + 45560",
                VideoUrl = "~/Video/LifterVideo.mp4",
                ImageUrl = "~/Images/Lifter.png",
                ShortDescription = "Pick up objects!",
                LongDescription = "Robot picking up items. The robot detects the object itself using the color sensor.",
                DifficultyLevelId = 2,
                ImageThumbnailUrl = "~/Images/LifterSmall.png",
                Rating = 4.5f,
                NumberOfPeopleRating = 2

            });


            modelBuilder.Entity<BuildingInstruction>().HasData(new BuildingInstruction
            {
                Id = 2,
                CategoryId = 1,
                Name = "Color Segregation",
                Pages = 24,
                Set = "45544",
                VideoUrl = "~/Video/ColorSegregationVideo.mp4",
                ImageUrl = "~/Images/ColorSegregation.png",
                ShortDescription = "Pick up objects!",
                LongDescription = "Robot picking up items. The robot detects the object itself using the color sensor.",
                DifficultyLevelId = 1,
                ImageThumbnailUrl = "~/Images/ColorSegregationSmall.png",
                Rating = 5,
                NumberOfPeopleRating = 3

            });
        }
    }
}
