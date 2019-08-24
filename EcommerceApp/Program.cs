using System;
using System.Collections.Generic;
using System.Linq;
using EcommerceApp.DatabaseContext;
using EcommerceApp.Models;
using EcommerceApp.Repositories;

namespace EcommerceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductRepository productRepository = new ProductRepository();
            CategoryRepository categoryRepository = new CategoryRepository();


            var order = new Order()
            {
                OrderDate = DateTime.Today,
                OrderNo = "001",
                Products = new List<ProductOrder>()
                {
                    new ProductOrder()
                    {
                        ProductId = 1
                    },
                    new ProductOrder()
                    {
                        ProductId=4
                    },
                    new ProductOrder()
                    {
                        ProductId = 5
                    }
                }
            };


            EcommerceDbContext db = new EcommerceDbContext();

            db.Orders.Add(order);

            bool isSaved = db.SaveChanges() > 0;

            if (isSaved)
            {
                Console.WriteLine("Success");
            }


            


            Console.ReadKey();

        }

        static void ShowAllProducts()
        {
            EcommerceDbContext db = new EcommerceDbContext();
            var products = db.Products.ToList();

            foreach (var product in products)
            {
                Console.WriteLine(product.Id+" " +product.Name +" "+product.Price+" "+product.ExpireDate.Value.ToShortDateString());
            }
        }
    }
}
