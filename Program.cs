using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace ProductNameAndPrice
{
    class Program
    {
        public class ProductDto
        {
            public string ProductName { get; set; }
            public double ProductPrice { get; set; }
            // List<ProductDto> Products { get; set; }

        }
        static void Main(string[] args)
        {
            /* List<string> name = new List<string>() { "Mouse", "Keyboard", "LCD", "Table", "Books" };

             List<double> priceValue = new List<double>() { 19.99, 35, 200, 70, 100 };

 */

            List<ProductDto> myProductList = new List<ProductDto>() { };

            myProductList.Add(new ProductDto { ProductName = "Mouse", ProductPrice = 19.99 });
            myProductList.Add(new ProductDto { ProductName = "Keyboard", ProductPrice = 35 });
            myProductList.Add(new ProductDto { ProductName = "Table", ProductPrice = 69.99 });
            myProductList.Add(new ProductDto { ProductName = "Laptop", ProductPrice = 500 });
            myProductList.Add(new ProductDto { ProductName = "Pen", ProductPrice = 2 });
            myProductList.Add(new ProductDto { ProductName = "Books", ProductPrice = 150 });
            myProductList.Add(new ProductDto { ProductName = "Speaker", ProductPrice = 200 });

            foreach (var packet in myProductList)
            {
                string name = packet.ProductName;
                double price = packet.ProductPrice;
                Console.Write(name + " - ");
                Console.WriteLine(price);
            }

            Console.Write("-------------------------------------------");
            Console.WriteLine();
 
            string ProductWithHighestPrice = (string) FindHighestPrice(myProductList);
            double TotalProductPrice = TotalPrice(myProductList);
            var ProductWithPriceHigherthanHundred = FindProductsWithPriceHigherThanHundred(myProductList);


            Console.WriteLine("Product with Highest Price: " + ProductWithHighestPrice);
            Console.WriteLine($"Total price: {TotalProductPrice}");
            Console.WriteLine(ProductWithPriceHigherthanHundred);
            Console.ReadKey();
        }

       

        public static string FindHighestPrice(List<ProductDto> myProductList)
        {
            /*double highestPrice =0;
            foreach (var packet in myProductList)
            { 
                double priceValue = myProductList.Max(x => x.ProductPrice);
                highestPrice = priceValue;
            }
            Console.Write(highestPrice);*/
            var HighestPrice = myProductList.OrderByDescending(x => x.ProductPrice).First();

            return HighestPrice?.ProductName;
        }

        public static double TotalPrice(List<ProductDto> myProductList)
        {
            double sum =0;
            foreach(var product in myProductList)
            {
                double total = myProductList.Sum(x => x.ProductPrice);
                sum += total;

            }
            return sum;

        }
        public static string FindProductsWithPriceHigherThanHundred(List<ProductDto> myProductList)
        {
            var productsHigherThanHundred = myProductList.Where(x => x.ProductPrice > 100);
            var productNames = productsHigherThanHundred.Select(p => p.ProductName);

            return string.Join("  | ", productNames.ToArray());
        }


    }


}
