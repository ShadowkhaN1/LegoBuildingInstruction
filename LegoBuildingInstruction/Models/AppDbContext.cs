using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<BuildingInstruction> BuildingInstructions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<DifficultyLevel> DifficultyLevels { get; set; }

        public DbSet<Comment> Comments { get; set; }


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
                VideoUrl = "https://www.youtube.com/embed/lRVrWwEMntQ",
                ImageUrl = "~/Images/ColorSegregation.png",
                ShortDescription = "Pick up objects!",
                LongDescription = "Robot picking up items. The robot detects the object itself using the color sensor.",
                DifficultyLevelId = 1,
                ImageThumbnailUrl = "~/Images/ColorSegregationSmall.png",
                Rating = 5,
                NumberOfPeopleRating = 3

            });


            modelBuilder.Entity<BuildingInstruction>().HasData(new BuildingInstruction
            {
                Id = 3,
                CategoryId = 2,
                Name = "Dinosaur",
                Pages = 40,
                Set = "45300",
                VideoUrl = "https://www.youtube.com/embed/aUszco5UdeU",
                ImageUrl = "~/Images/DinosaurImageSmall.png",
                ShortDescription = "Create a dinosaur from your lego bricks!",
                LongDescription = "Create a dinosaur from your lego bricks!",
                DifficultyLevelId = 1,
                ImageThumbnailUrl = "~/Images/DinosaurImageSmall.png",
                Rating = 5,
                NumberOfPeopleRating = 3

            });




            modelBuilder.Entity<BuildingInstruction>().HasData(new BuildingInstruction
            {
                Id = 4,
                CategoryId = 2,
                Name = "Hit the mole",
                Pages = 40,
                Set = "45300",
                VideoUrl = "https://www.youtube.com/embed/aUszco5UdeU",
                ImageUrl = "~/Images/HitTheMole.PNG",
                ShortDescription = "Hit the right mole at the right moment",
                LongDescription = "Create a dinosaur from your lego bricks!",
                DifficultyLevelId = 1,
                ImageThumbnailUrl = "~/Images/HitTheMole.PNG",
                Rating = 5,
                NumberOfPeopleRating = 3

            });

            modelBuilder.Entity<ApplicationUser>().HasMany(c => c.Comments).WithOne(u => u.User).IsRequired();
        }
    }
}
