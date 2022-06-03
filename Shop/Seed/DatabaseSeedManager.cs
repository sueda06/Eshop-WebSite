using System;
using System.Collections.Generic;
using DataAccessLayer.Context;
using EntityLayer.Entities;

namespace Shop.Seed
{
    public class DatabaseSeedManager
    {
        public static void Seed(DataContext context)
        {
            var users = UserSeedData();
            users.ForEach(x=>context.Users.Add(x));
            context.SaveChanges();
            var categories = CategorySeedData();
            categories.ForEach(x=>context.Categories.Add(x));
            context.SaveChanges();
            var products = ProductSeedData();
            products.ForEach(x=>context.Products.Add(x));
            context.SaveChanges();
            var sales = SalesSeedData();
            sales.ForEach(x=>context.Sales.Add(x));
            context.SaveChanges();
            var comments = CommentSeedData();
            comments.ForEach(x=>context.Comments.Add(x));
            context.SaveChanges();
        }

        private static List<User> UserSeedData()
        {
            return new List<User>
            {
                new User
                {
                    Email = "admin@admin.com",
                    Name = "Sueda",
                    SurName = "Akın",
                    Password = "123456",
                    RePassword = "123456",
                    Role = "Admin",
                    UserName = "suedaakin"
                },
                new User
                {
                    Email = "baran@gmail.com",
                    Name = "Baran",
                    SurName = "Demir",
                    Password = "123456",
                    RePassword = "123456",
                    Role = "User",
                    UserName = "barandemir"
                },
                new User
                {
                    Email = "selim@gmail.com",
                    Name = "Selim",
                    SurName = "Kara",
                    Password = "123456",
                    RePassword = "123456",
                    Role = "User",
                    UserName = "selimkara"
                },
            };
        }
        private static List<Category> CategorySeedData()
        {
            return new List<Category>
            {
                new Category
                {
                    Name = "El Kremi",
                    Description = "El Kremi"
                },
                new Category
                {
                    Name = "Yüz Kremi",
                    Description = "Yüz Kremi"
                },
                new Category
                {
                    Name = "Şampuan",
                    Description = "Şampuan"
                },
                new Category
                {
                    Name = "Maske",
                    Description = "Maske"
                },
            };
        }
        private static List<Product> ProductSeedData()
        {
            return new List<Product>
            {
                new Product
                {
                    Name = "Neutrogena Soothing Clear",
                    Description = "Neutrogena El Kremi",
                    Price = 30,
                    Stock = 100,
                    Popular = true,
                    IsApproved = true,
                    Image = "1.jpg",
                    CategoryId = 1
                },
                new Product
                {
                    Name = "The Purest Solution",
                    Description = "Yüz Kremi",
                    Price = 40,
                    Stock = 50,
                    Popular = true,
                    IsApproved = true,
                    Image = "2.jpg",
                    CategoryId = 2
                },
                new Product
                {
                    Name = "Sun Şampuan",
                    Description = "Şampuan",
                    Price = 60,
                    Stock = 23,
                    Popular = false,
                    IsApproved = true,
                    Image = "3.jpg",
                    CategoryId = 3
                },
                new Product
                {
                    Name = "Garnier Nem Bombası",
                    Description = "Maske",
                    Price = 50,
                    Stock = 25,
                    Popular = true,
                    IsApproved = true,
                    Image = "4.jpg",
                    CategoryId = 4
                },
                
            };
        }
        private static List<Sales> SalesSeedData()
        {
            return new List<Sales>
            {
                new Sales
                {
                    ProductId = 1,
                    Quantity = 1,
                    Price = 30,
                    Date = DateTime.Now,
                    Image = "1.jpg",
                    UserId = 2
                },
                new Sales
                {
                    ProductId = 1,
                    Quantity = 2,
                    Price = 60,
                    Date = DateTime.Now,
                    Image = "1.jpg",
                    UserId = 3
                },
                new Sales
                {
                    ProductId = 2,
                    Quantity = 3,
                    Price = 120,
                    Date = DateTime.Now,
                    Image = "2.jpg",
                    UserId = 2
                },
                new Sales
                {
                    ProductId = 2,
                    Quantity = 2,
                    Price = 80,
                    Date = DateTime.Now,
                    Image = "2.jpg",
                    UserId = 3
                },
                new Sales
                {
                    ProductId = 3,
                    Quantity = 2,
                    Price = 120,
                    Date = DateTime.Now,
                    Image = "3.jpg",
                    UserId = 2
                },
                new Sales
                {
                    ProductId = 3,
                    Quantity = 1,
                    Price = 60,
                    Date = DateTime.Now,
                    Image = "3.jpg",
                    UserId = 3
                },
                new Sales
                {
                    ProductId = 4,
                    Quantity = 1,
                    Price = 50,
                    Date = DateTime.Now,
                    Image = "4.jpg",
                    UserId = 2
                },
                new Sales
                {
                    ProductId = 4,
                    Quantity = 5,
                    Price = 250,
                    Date = DateTime.Now,
                    Image = "4.jpg",
                    UserId = 3
                },
            };
        }

        private static List<Comment> CommentSeedData()
        {
            return new List<Comment>
            {
                new Comment
                {
                    Contents = "Harika! :)",
                    ProductId = 1,
                    UserId = 2,
                    Date=DateTime.Now
                },
                new Comment
                {
                    Contents = "Çok hoşuma gitti herkese tavsiye ederim.",
                    ProductId = 1,
                    UserId = 3,
                    Date=DateTime.Now
                },
                new Comment
                {
                    Contents = "Fena değil, iş görüyor.",
                    ProductId = 2,
                    UserId = 2,
                    Date=DateTime.Now
                },
                new Comment
                {
                    Contents = "Arkadaşımın ısrarı üzerine almıştım, hoşuma gitmedi tavsiye etmem.",
                    ProductId = 2,
                    UserId = 3,
                    Date=DateTime.Now
                },
                new Comment
                {
                    Contents = "Muazzam bir şey...",
                    ProductId = 3,
                    UserId = 2,
                    Date=DateTime.Now
                },
                new Comment
                {
                    Contents = "Yıllardır buna ihtiyacım varmış gibi hissettirdi :)",
                    ProductId = 3,
                    UserId = 3,
                    Date=DateTime.Now
                },
                new Comment
                {
                    Contents = "Beğenmedim çok kötü :(",
                    ProductId = 4,
                    UserId = 2,
                    Date=DateTime.Now
                },
                new Comment
                {
                    Contents = "Verdiğiniz paraya değmez...",
                    ProductId = 4,
                    UserId = 3,
                    Date=DateTime.Now
                },
            };
        }
    }
}