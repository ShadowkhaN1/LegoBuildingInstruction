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

        public DbSet<Comment> Comments { get; set; }
        public DbSet<FavoritesBuildingInstruction> FavoritesCategories { get; set; }
        public DbSet<RateInstruction> RateInstructions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Mindstorms" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "WeDo" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Power Function" });




            //modelBuilder.Entity<BuildingInstruction>().HasData(new BuildingInstruction
            //{
            //    BuildingInstructionId = 1,
            //    CategoryId = 1,
            //    Name = "Lifter",
            //    Pages = 52,
            //    Set = "45544 + 45560",
            //    VideoUrl = "~/Video/LifterVideo.mp4",
            //    ImageUrl = "~/Images/Lifter.png",
            //    LongDescription = "Robot picking up items. The robot detects the object itself using the color sensor.",
            //    ImageThumbnailUrl = "~/Images/LifterSmall.png",

            //});


            //modelBuilder.Entity<BuildingInstruction>().HasData(new BuildingInstruction
            //{
            //    BuildingInstructionId = 2,
            //    CategoryId = 1,
            //    Name = "Color Segregation",
            //    Pages = 24,
            //    Set = "45544",
            //    VideoUrl = "https://www.youtube.com/embed/lRVrWwEMntQ",
            //    ImageUrl = "~/Images/ColorSegregation.png",
            //    LongDescription = "Robot picking up items. The robot detects the object itself using the color sensor.",
            //    ImageThumbnailUrl = "~/Images/ColorSegregationSmall.png",

            //});


            //modelBuilder.Entity<BuildingInstruction>().HasData(new BuildingInstruction
            //{
            //    BuildingInstructionId = 3,
            //    CategoryId = 2,
            //    Name = "Dinosaur",
            //    Pages = 40,
            //    Set = "45300",
            //    VideoUrl = "https://www.youtube.com/embed/aUszco5UdeU",
            //    ImageUrl = "~/Images/DinosaurImageSmall.png",
            //    LongDescription = "Create a dinosaur from your lego bricks!",
            //    ImageThumbnailUrl = "~/Images/DinosaurImageSmall.png",

            //});




            //modelBuilder.Entity<BuildingInstruction>().HasData(new BuildingInstruction
            //{

            //    BuildingInstructionId = 4,
            //    CategoryId = 2,
            //    Name = "Hit the mole",
            //    Pages = 40,
            //    Set = "45300",
            //    VideoUrl = "https://www.youtube.com/embed/aUszco5UdeU",
            //    ImageUrl = "~/Images/HitTheMole.PNG",
            //    LongDescription = "Create a dinosaur from your lego bricks!",
            //    ImageThumbnailUrl = "~/Images/HitTheMole.PNG",

            //});

            //modelBuilder.Entity<ApplicationUser>().HasMany(c => c.Comments).WithOne(u => u.User).IsRequired();




            //modelBuilder.Entity<RateInstruction>().HasOne(b => b.BuildingInstruction).WithMany(r => r.RateInstructions)
            //    .HasForeignKey(b => b.BuildingInstructionId);


            //modelBuilder.Entity<RateInstruction>().HasOne(u => u.User).WithMany(r => r.RateInstructions)
            //    .HasForeignKey(u => u.UserId);
        }
    }
}
