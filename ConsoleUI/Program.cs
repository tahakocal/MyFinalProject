﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }

            Console.WriteLine("**********************************************");

            foreach (var product in productManager.GetAllByCategoryId(2))
            {
                Console.WriteLine(product.ProductName);
            }

            Console.WriteLine("**********************************************");

            foreach (var product in productManager.GetByUnitPrice(100, 5000))
            {
                Console.WriteLine(product.ProductName);
            }

            Console.ReadLine();
        }
    }
}
