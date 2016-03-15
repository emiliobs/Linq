using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
//
using static System.Console;

namespace Linq2
{
    public class LinqSamples
    {
        private List<Product> ProductsList;
        private List<Customer> CustomersList;
        

        public object XDocumento { get; private set; }

        [Description("This sample uses the where clause to find all elements of an array with a value less than 5")]
      public void Linq1()
      {
            int[] numbers = {5,4,7,8,9,6,3,2,1,4,5,45,58 };

            var lowNumbers = from number in numbers where number < 5 select number;

            WriteLine("Numbers < 5");
            foreach (var n in lowNumbers)
            {
                WriteLine(n);

            }
      }

      [Description("This sample uses the where clause to find all product that are out of stok.")]
      public void Linq2()
      {
            List<Product> products = GetProductList();

            var soldOutProducts = from product in products where product.UnitsinStock == 0 select product;

            WriteLine("Sold out Products.");
            foreach (var product in soldOutProducts)
            {
                WriteLine($"{product.ProductName} Is sold Out!");
            }
      }

      [Description("This sample uses the where clause to find all products that are in stock and cost more than 3.00 per unit.")]
      public void Linq3()
      {
            List<Product> products = GetProductList();

            var expansiveInStockProducts = from product in products where product.UnitsinStock > 0 && product.Unitprice > 3.00M select product;

            WriteLine("In-Stock products tha cost more tha that 3.00");
            foreach (var product  in expansiveInStockProducts)
            {
                WriteLine($"{product.ProductName} Is in stock ans costs more than 3...");

            }   
      }

      [Description("This sample uses the where clause to find all customers in  Washinton and then it uses a foreach loop to iterate over the  orders" +
                   "collection that belongs to each customer.")]
      public void Linq4()
      {
            List<Customer> customers = GetCustomerList();

            var waCustomers =
                from cust in customers
                where cust.Region == "WA"
                select cust;

            Console.WriteLine("Customers from Washington and their orders:");
            foreach (var customer in waCustomers)
            {
                Console.WriteLine($"Customer {customer.CustomerID}: {customer.CompanyName}");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine($"  Order {order.OrderID}: {order.OrderDate}");
                }
            }
        }

     [Description("This sample demostrate an indexed where clause that returns digits whose name is shorter than their value.")]
     public void Linq5()
     {
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var shortDigits = digits.Where((digit, index) => digit.Length < index);
            WriteLine("Short Digits: ");
            foreach (var d in shortDigits)
            {
                WriteLine($"The {d} is shorter that its value.");
            }
     }

        private List<Customer> GetCustomerList()
        {
            if (CustomersList == null)
            {
                createList();
            }

            return CustomersList;
        }

        private List<Product> GetProductList()
        {
            if (ProductsList == null)
            {
                createList();
            }

            return ProductsList;
        }                                                                                                                

         private void createList()
        {
            //Product data created in-memory using collection initializr:
            ProductsList = new List<Product>
             {
             
                new Product { ProductID = 1, ProductName = "chai", Category="Beverages", Unitprice = 18.0000M, UnitsinStock=39 },
                new Product { ProductID = 2, ProductName ="Chang", Category="Beverages", Unitprice = 19.0000m, UnitsinStock= 17 },
                new Product { ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments", Unitprice = 10.0000M, UnitsinStock = 13 },
                new Product { ProductID = 4, ProductName = "Chef Anton's Cajun Seasoning", Category = "Condiments", Unitprice = 22.0000M, UnitsinStock = 53 },
                new Product { ProductID = 5, ProductName = "Chef Anton's Gumbo Mix", Category = "Condiments", Unitprice = 21.3500M, UnitsinStock = 0 },
                new Product { ProductID = 6, ProductName = "Grandma's Boysenberry Spread", Category = "Condiments", Unitprice = 25.0000M, UnitsinStock = 120 },
                new Product { ProductID = 7, ProductName = "Uncle Bob's Organic Dried Pears", Category = "Produce", Unitprice = 30.0000M, UnitsinStock = 15 },
                new Product { ProductID = 8, ProductName = "Northwoods Cranberry Sauce", Category = "Condiments", Unitprice = 40.0000M, UnitsinStock = 6 },
                new Product { ProductID = 9, ProductName = "Mishi Kobe Niku", Category = "Meat/Poultry", Unitprice = 97.0000M, UnitsinStock = 29 },
                new Product { ProductID = 10, ProductName = "Ikura", Category = "Seafood", Unitprice = 31.0000M, UnitsinStock = 31 },
                new Product { ProductID = 11, ProductName = "Queso Cabrales", Category = "Dairy Products", Unitprice = 21.0000M, UnitsinStock = 22 },
                new Product { ProductID = 12, ProductName = "Queso Manchego La Pastora", Category = "Dairy Products", Unitprice = 38.0000M, UnitsinStock = 86 },
                new Product { ProductID = 13, ProductName = "Konbu", Category = "Seafood", Unitprice = 6.0000M, UnitsinStock = 24 },
                new Product { ProductID = 14, ProductName = "Tofu", Category = "Produce", Unitprice = 23.2500M, UnitsinStock = 35 },
                new Product { ProductID = 15, ProductName = "Genen Shouyu", Category = "Condiments", Unitprice = 15.5000M, UnitsinStock = 39 },
                new Product { ProductID = 16, ProductName = "Pavlova", Category = "Confections", Unitprice = 17.4500M, UnitsinStock = 29 },
                new Product { ProductID = 17, ProductName = "Alice Mutton", Category = "Meat/Poultry", Unitprice = 39.0000M, UnitsinStock = 0 },
                new Product { ProductID = 18, ProductName = "Carnarvon Tigers", Category = "Seafood", Unitprice = 62.5000M, UnitsinStock = 42 },
                new Product { ProductID = 19, ProductName = "Teatime Chocolate Biscuits", Category = "Confections", Unitprice = 9.2000M, UnitsinStock = 25 },
                new Product { ProductID = 20, ProductName = "Sir Rodney's Marmalade", Category = "Confections", Unitprice = 81.0000M, UnitsinStock = 40 },
                new Product { ProductID = 21, ProductName = "Sir Rodney's Scones", Category = "Confections", Unitprice = 10.0000M, UnitsinStock = 3 },
                new Product { ProductID = 22, ProductName = "Gustaf's Knäckebröd", Category = "Grains/Cereals", Unitprice = 21.0000M, UnitsinStock = 104 },
                new Product { ProductID = 23, ProductName = "Tunnbröd", Category = "Grains/Cereals", Unitprice = 9.0000M, UnitsinStock = 61 },
                new Product { ProductID = 24, ProductName = "Guaraná Fantástica", Category = "Beverages", Unitprice = 4.5000M, UnitsinStock = 20 },
                new Product { ProductID = 25, ProductName = "NuNuCa Nuß-Nougat-Creme", Category = "Confections", Unitprice = 14.0000M, UnitsinStock = 76 },
                new Product { ProductID = 26, ProductName = "Gumbär Gummibärchen", Category = "Confections", Unitprice = 31.2300M, UnitsinStock = 15 },
                new Product { ProductID = 27, ProductName = "Schoggi Schokolade", Category = "Confections", Unitprice = 43.9000M, UnitsinStock = 49 },
                new Product { ProductID = 28, ProductName = "Rössle Sauerkraut", Category = "Produce", Unitprice = 45.6000M, UnitsinStock = 26 },
                new Product { ProductID = 29, ProductName = "Thüringer Rostbratwurst", Category = "Meat/Poultry", Unitprice = 123.7900M, UnitsinStock = 0 },
                new Product { ProductID = 30, ProductName = "Nord-Ost Matjeshering", Category = "Seafood", Unitprice = 25.8900M, UnitsinStock = 10 },
                new Product { ProductID = 31, ProductName = "Gorgonzola Telino", Category = "Dairy Products", Unitprice = 12.5000M, UnitsinStock = 0 },
                new Product { ProductID = 32, ProductName = "Mascarpone Fabioli", Category = "Dairy Products", Unitprice = 32.0000M, UnitsinStock = 9 },
                new Product { ProductID = 33, ProductName = "Geitost", Category = "Dairy Products", Unitprice = 2.5000M, UnitsinStock = 112 },
                new Product { ProductID = 34, ProductName = "Sasquatch Ale", Category = "Beverages", Unitprice = 14.0000M, UnitsinStock = 111 },
                new Product { ProductID = 35, ProductName = "Steeleye Stout", Category = "Beverages", Unitprice = 18.0000M, UnitsinStock = 20 },
                new Product { ProductID = 36, ProductName = "Inlagd Sill", Category = "Seafood", Unitprice = 19.0000M, UnitsinStock = 112 },
                new Product { ProductID = 37, ProductName = "Gravad lax", Category = "Seafood", Unitprice = 26.0000M, UnitsinStock = 11 },
                new Product { ProductID = 38, ProductName = "Côte de Blaye", Category = "Beverages", Unitprice = 263.5000M, UnitsinStock = 17 },
                new Product { ProductID = 39, ProductName = "Chartreuse verte", Category = "Beverages", Unitprice = 18.0000M, UnitsinStock = 69 },
                new Product { ProductID = 40, ProductName = "Boston Crab Meat", Category = "Seafood", Unitprice = 18.4000M, UnitsinStock = 123 },
                new Product { ProductID = 41, ProductName = "Jack's New England Clam Chowder", Category = "Seafood", Unitprice = 9.6500M, UnitsinStock = 85 },
                new Product { ProductID = 42, ProductName = "Singaporean Hokkien Fried Mee", Category = "Grains/Cereals", Unitprice = 14.0000M, UnitsinStock = 26 },
                new Product { ProductID = 43, ProductName = "Ipoh Coffee", Category = "Beverages", Unitprice = 46.0000M, UnitsinStock = 17 },
                new Product { ProductID = 44, ProductName = "Gula Malacca", Category = "Condiments", Unitprice = 19.4500M, UnitsinStock = 27 },
                new Product { ProductID = 45, ProductName = "Rogede sild", Category = "Seafood", Unitprice = 9.5000M, UnitsinStock = 5 },
                new Product { ProductID = 46, ProductName = "Spegesild", Category = "Seafood", Unitprice = 12.0000M, UnitsinStock = 95 },
                new Product { ProductID = 47, ProductName = "Zaanse koeken", Category = "Confections", Unitprice = 9.5000M, UnitsinStock = 36 },
                new Product { ProductID = 48, ProductName = "Chocolade", Category = "Confections", Unitprice = 12.7500M, UnitsinStock = 15 },
                new Product { ProductID = 49, ProductName = "Maxilaku", Category = "Confections", Unitprice = 20.0000M, UnitsinStock = 10 },
                new Product { ProductID = 50, ProductName = "Valkoinen suklaa", Category = "Confections", Unitprice = 16.2500M, UnitsinStock = 65 },
                new Product { ProductID = 51, ProductName = "Manjimup Dried Apples", Category = "Produce", Unitprice = 53.0000M, UnitsinStock = 20 },
                new Product { ProductID = 52, ProductName = "Filo Mix", Category = "Grains/Cereals", Unitprice = 7.0000M, UnitsinStock = 38 },
                new Product { ProductID = 53, ProductName = "Perth Pasties", Category = "Meat/Poultry", Unitprice = 32.8000M, UnitsinStock = 0 },
                new Product { ProductID = 54, ProductName = "Tourtière", Category = "Meat/Poultry", Unitprice = 7.4500M, UnitsinStock = 21 },
                new Product { ProductID = 55, ProductName = "Pâté chinois", Category = "Meat/Poultry", Unitprice = 24.0000M, UnitsinStock = 115 },
                new Product { ProductID = 56, ProductName = "Gnocchi di nonna Alice", Category = "Grains/Cereals", Unitprice = 38.0000M, UnitsinStock = 21 },
                new Product { ProductID = 57, ProductName = "Ravioli Angelo", Category = "Grains/Cereals", Unitprice = 19.5000M, UnitsinStock = 36 },
                new Product { ProductID = 58, ProductName = "Escargots de Bourgogne", Category = "Seafood", Unitprice = 13.2500M, UnitsinStock = 62 },
                new Product { ProductID = 59, ProductName = "Raclette Courdavault", Category = "Dairy Products", Unitprice = 55.0000M, UnitsinStock = 79 },
                new Product { ProductID = 60, ProductName = "Camembert Pierrot", Category = "Dairy Products", Unitprice = 34.0000M, UnitsinStock = 19 },
                new Product { ProductID = 61, ProductName = "Sirop d'érable", Category = "Condiments", Unitprice = 28.5000M, UnitsinStock = 113 },
                new Product { ProductID = 62, ProductName = "Tarte au sucre", Category = "Confections", Unitprice = 49.3000M, UnitsinStock = 17 },
                new Product { ProductID = 63, ProductName = "Vegie-spread", Category = "Condiments", Unitprice = 43.9000M, UnitsinStock = 24 },
                new Product { ProductID = 64, ProductName = "Wimmers gute Semmelknödel", Category = "Grains/Cereals", Unitprice = 33.2500M, UnitsinStock = 22 },
                new Product { ProductID = 65, ProductName = "Louisiana Fiery Hot Pepper Sauce", Category = "Condiments", Unitprice = 21.0500M, UnitsinStock = 76 },
                new Product { ProductID = 66, ProductName = "Louisiana Hot Spiced Okra", Category = "Condiments", Unitprice = 17.0000M, UnitsinStock = 4 },
                new Product { ProductID = 67, ProductName = "Laughing Lumberjack Lager", Category = "Beverages", Unitprice = 14.0000M, UnitsinStock = 52 },
                new Product { ProductID = 68, ProductName = "Scottish Longbreads", Category = "Confections", Unitprice = 12.5000M, UnitsinStock = 6 },
                new Product { ProductID = 69, ProductName = "Gudbrandsdalsost", Category = "Dairy Products", Unitprice = 36.0000M, UnitsinStock = 26 },
                new Product { ProductID = 70, ProductName = "Outback Lager", Category = "Beverages", Unitprice = 15.0000M, UnitsinStock = 15 },
                new Product { ProductID = 71, ProductName = "Flotemysost", Category = "Dairy Products", Unitprice = 21.5000M, UnitsinStock = 26 },
                new Product { ProductID = 72, ProductName = "Mozzarella di Giovanni", Category = "Dairy Products", Unitprice = 34.8000M, UnitsinStock = 14 },
                new Product { ProductID = 73, ProductName = "Röd Kaviar", Category = "Seafood", Unitprice = 15.0000M, UnitsinStock = 101 },
                new Product { ProductID = 74, ProductName = "Longlife Tofu", Category = "Produce", Unitprice = 10.0000M, UnitsinStock = 4 },
                new Product { ProductID = 75, ProductName = "Rhönbräu Klosterbier", Category = "Beverages", Unitprice = 7.7500M, UnitsinStock = 125 },
                new Product { ProductID = 76, ProductName = "Lakkalikööri", Category = "Beverages", Unitprice = 18.0000M, UnitsinStock = 57 },
                new Product { ProductID = 77, ProductName = "Original Frankfurter grüne Soße", Category = "Condiments", Unitprice = 13.0000M, UnitsinStock = 32 }
                };


            //Customer/Order data read into memory from xml file using xlinq:

            CustomersList = (
                     from e in XDocument.Load("Customers.xml").
                               Root.Elements("customer")
                     select new Customer
                     {
                         CustomerID = (string)e.Element("id"),
                         CompanyName = (string)e.Element("name"),
                         Address = (string)e.Element("address"),
                         City = (string)e.Element("city"),
                         Region = (string)e.Element("region"),
                         PostalCode = (string)e.Element("postalcode"),
                         Country = (string)e.Element("country"),
                         Phone = (string)e.Element("phone"),
                         Fax = (string)e.Element("fax"),
                         Orders = (
                             from o in e.Elements("orders").Elements("order")
                             select new Order
                             {
                                 OrderID = (int)o.Element("id"),
                                 OrderDate = (DateTime)o.Element("orderdate"),
                                 Total = (decimal)o.Element("total")
                             })
                             .ToArray()
                     })
                     .ToList();
        }
    }
}
