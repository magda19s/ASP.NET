using Lab10v2.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab10v2.Data
{
    public static class MyBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Category>().HasData(
               new Category()
               {
                   Id = 1,
                   Name = "Vegetables"
               },
               new Category()
               {
                   Id = 2,
                   Name = "Fruits"
               }

               );


            modelBuilder.Entity<Article>().HasData(
                    new Article()
                    {
                        Id = 1,
                        Name = "Brocolli",
                        Price = 8.22,
                        CategoryId = 1,
                        FilePath = "/images/noPhoto.jpg"

                    },
                    new Article()
                    {
                        Id = 2,
                        Name = "Grape",
                        Price = 10.22,
                        CategoryId = 2,
                        FilePath = "/images/noPhoto.jpg"
                    }

                    );
        }
    }
}
