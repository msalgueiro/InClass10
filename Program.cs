using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InClass10
{
    class Store
    {
        [Key]
        public int Store_ID { get; set; }

        public string Store_Name { get; set; }

        public string Address { get; set; }

        public int Zip_Code { get; set; }

        public List<Order> Product_Orders { get; set; }

    }

    class Product
    {
        [Key]
        public int Product_ID { get; set; }

        public string Product_Name { get; set; }

        public string Product_Description { get; set; }

        public double Product_Price { get; set; }

        public List<Order> Store_Orders { get; set; }

    }


    class Order
    {
        [Key]
        public int Order_ID { get; set; }

        public Store StoreOrder { get; set; }

        public Product ProductOrder { get; set; }

        public DateTime OrderDate { get; set; }


    }



    class Product_OrdersContext : DbContext
    {
        public DbSet<Store> Stores { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }


        string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=InClass10;Trusted_Connection=True;MultipleActiveResultSets=true";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }


    }




    class Program
    {
        static void Main(string[] args)
        {
            using (Product_OrdersContext context = new Product_OrdersContext())
            {
                context.Database.EnsureCreated();

                Store store1 = new Store { Store_Name = "Walmart", Address = "15302 N Nebraska Ave, Tampa, FL", Zip_Code = 33613 };

                Store store2 = new Store { Store_Name = "Publix", Address = "4425 E Fletcher Ave, Tampa, FL", Zip_Code = 33613 };

                Store store3 = new Store { Store_Name = "Winn-Dixie", Address = "2770 E Fowler Ave, Tampa, FL", Zip_Code = 33612 };

                Store store4 = new Store { Store_Name = "Costco", Address = "2225 Grand Cypress Dr, Lutz, FL", Zip_Code = 33559 };

                
                
                Product product1 = new Product { Product_Name = "Gillete Match 3 Turbo", Product_Description = "Men Razor with steel blades", Product_Price = 11.99 };

                Product product2 = new Product { Product_Name = "Remington Head-To-Toe Grooming Set", Product_Description = "Men's Personal Electric Razor, Electric Shaver, Trimmer, Black", Product_Price = 27.97 };

                Product product3 = new Product { Product_Name = "Gillette Series Sensitive Cool Shaving Gel", Product_Description = "Shaving Gel for Men", Product_Price = 5.99 };

                Product product4 = new Product { Product_Name = "Gillete Fusion 5 Shaving Gel", Product_Description = "Shaving Gel For Men", Product_Price = 7.50 };

                Product product5 = new Product { Product_Name = "Philips Norelco trimmer", Product_Description = "Nose, ear and eyebrow Trimmer", Product_Price = 9.45 };

                Product product6 = new Product { Product_Name = "Listerine", Product_Description = "Cool Mint Antiseptic Mouthwash for Bad Breath,", Product_Price = 5.37 };


                Order order1 = new Order 
                {
                    StoreOrder =store1,
                    ProductOrder = product1,
                    OrderDate = DateTime.Now

                };

                Order order2 = new Order
                {
                    StoreOrder = store1,
                    ProductOrder = product2,
                    OrderDate = DateTime.Now

                };

                Order order3 = new Order
                {
                    StoreOrder = store2,
                    ProductOrder = product3,
                    OrderDate = DateTime.Now

                };


                Order order4 = new Order
                {
                    StoreOrder = store2,
                    ProductOrder = product4,
                    OrderDate = DateTime.Now

                };


                Order order5 = new Order
                {
                    StoreOrder = store3,
                    ProductOrder = product5,
                    OrderDate = DateTime.Now

                };


                Order order6 = new Order
                {
                    StoreOrder = store3,
                    ProductOrder = product6,
                    OrderDate = DateTime.Now

                };


                Order order7 = new Order
                {
                    StoreOrder = store4,
                    ProductOrder = product1,
                    OrderDate = DateTime.Now

                };

                Order order8 = new Order
                {
                    StoreOrder = store4,
                    ProductOrder = product3,
                    OrderDate = DateTime.Now

                };


                context.Stores.Add(store1);
                context.Stores.Add(store2);
                context.Stores.Add(store3);
                context.Stores.Add(store4);

                context.Products.Add(product1);
                context.Products.Add(product2);
                context.Products.Add(product3);
                context.Products.Add(product4);
                context.Products.Add(product5);
                context.Products.Add(product6);

                context.Orders.Add(order1);
                context.Orders.Add(order2);
                context.Orders.Add(order3);
                context.Orders.Add(order4);
                context.Orders.Add(order5);
                context.Orders.Add(order6);
                context.Orders.Add(order7);
                context.Orders.Add(order8);

                context.SaveChanges();

            }
        }
    }

    //class Queries
    //{
    //    static void Main(string[] args)
    //    {
    //        Order OrderQuery1 = DbContext.Orders




    //        Order OrderQuery2 = DbContext.Orders
    //                           .OrderByDescending(x => x.Delivery.SubmissionDate);
                               
    //    }
    //}


}
