﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
    class UserOperations
    {
        
        static int user_choice=1;
        public static string alphaPattern = "^[A-Za-z]";
        public static string alphaNumPattern = "^[A-Za-z0-9]";
        public static string allPattern = "^.*$";

   
        static string numPattern = "[0-9]{1,100}";
        
        public static Regex numRegex = new Regex(numPattern);


     

        public static void getProductUserAccess(int productAccess)
        {
            var ctx = new MyDebContext();
           using (var inventory = new MyDebContext())
                {
                    foreach (var findProductData in inventory.PRODUCTS.ToList())
                    {
                        if (findProductData.Product_Category_ID == productAccess)
                        {
                            var findProductName = ctx.PRODUCT_CATEGORIES.First(x => x.Product_Category_ID == Convert.ToInt32(findProductData.Product_Category_ID));
                        Console.WriteLine("-------------------------------------------");

                        Console.WriteLine("Category Name: " + findProductName.Product_Name);
                            Console.WriteLine("Product Name: " + findProductData.SubProduct_Name);
                            Console.WriteLine("Description: " + findProductData.Description);
                            Console.WriteLine("Current Storage: " + findProductData.Current_Storage);
                            Console.WriteLine("Sold: " + findProductData.Sold);
                            Console.WriteLine("Remaining Quantity: " + findProductData.Remaining_Quantity);
                            Console.WriteLine("Unit Price: " + findProductData.Unit_Price);
                            Console.WriteLine("Total Selling Amount: " + findProductData.Total_Selling_Amount);
                            Console.WriteLine("Last Modified On: " + findProductData.ModifiedOn);
                        

                    }
                    else
                    {
                        Console.WriteLine("No product assigned to you for now.");
                        Console.ReadKey();
                    }
                   

                    }
        
                }
                
            
        }
                public static void updateProductData()
        {
            var ctx = new MyDebContext();
            while (user_choice != 0)
            {
                Console.Clear();
                Console.WriteLine("----------------------------------------\nWhat operation do you wish to perform?\n" +
                    "1. Update Price\n" +
                    "2. Update Current Storage\n" +
                    "3. Update Sold\n" +
                    "0. Return\n" +
                    "----------------------------------------");
                user_choice = Convert.ToInt32(Console.ReadLine());
                switch (user_choice)
                {
                    case 1:
                        {
                            int productId = 0;
                            Console.WriteLine("Enter product ID: ");
                            try
                            {
                                productId = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error: " + e.Message);
                                Console.ReadKey();
                                return;
                            }
                            if (AdminOperations.isProductIDAvailable(productId) == 1)
                                {
                                    Console.WriteLine("Product does not exist");
                                    Console.ReadKey();
                                    return;
                                }
                                var find = ctx.PRODUCTS.First(x => x.Products_ID == productId);
                                Console.WriteLine("Enter new Price: ");
                            try
                            {
                                find.Unit_Price = Convert.ToDecimal(Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error: " + e.Message);
                                Console.ReadKey();
                                return;
                            }
                            find.Total_Selling_Amount = find.Sold * find.Unit_Price;
                                find.ModifiedBy = Program.username;
                                if (ctx.SaveChanges() > 0)
                                {

                                    Console.WriteLine("Result-> Product Updated");
                                }
                                else
                                {
                                    Console.WriteLine("Result-> Product not Updated. Please check data");
                                }
                            
                        
                                Console.ReadKey();
                            
                            
                            break;
                        }
                    case 2:
                        {
                            int productId = 0,newStorage=0;
                            Console.WriteLine("Enter product ID: ");
                            try
                            {
                                productId = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error: " + e.Message);
                                Console.ReadKey();
                                return;
                            }
                            if (AdminOperations.isProductIDAvailable(productId) == 1)
                            {
                                Console.WriteLine("Product does not exist");
                                Console.ReadKey();
                                return;
                            }
                            var find = ctx.PRODUCTS.First(x => x.Products_ID == productId);
                            Console.WriteLine("Enter new storage count: ");
                            try
                            {
                                newStorage = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error: " + e.Message);
                                Console.ReadKey();
                                return;
                            }
                            find.Current_Storage = find.Current_Storage + newStorage;
                            find.Remaining_Quantity =find.Current_Storage-find.Sold;
                            find.ModifiedBy = Program.username;

                            if (ctx.SaveChanges() > 0)
                            {

                                Console.WriteLine("Result-> Product Updated");
                            }
                            else
                            {
                                Console.WriteLine("Result-> Product not Updated. Please check data");
                            }
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            int productId = 0,newSoldCount=0;
                            Console.WriteLine("Enter product ID: ");
                            try
                            {
                                productId = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error: " + e.Message);
                                Console.ReadKey();
                                return;
                            }
                            if (AdminOperations.isProductIDAvailable(productId) == 1)
                            {
                                Console.WriteLine("Product does not exist");
                                Console.ReadKey();
                                return;
                            }
                            var find = ctx.PRODUCTS.First(x => x.Products_ID == productId);
                            Console.WriteLine("Enter sold count: ");
                            try
                            {
                                newSoldCount = Convert.ToInt32(Console.ReadLine());
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error: " + e.Message);
                                Console.ReadKey();
                                return;
                            }
                            find.Sold = find.Sold + newSoldCount;
                            find.Remaining_Quantity = find.Current_Storage - find.Sold;
                            find.Total_Selling_Amount = find.Sold * find.Unit_Price;
                            find.ModifiedBy = Program.username;

                            if (ctx.SaveChanges() > 0)
                            {

                                Console.WriteLine("Result-> Product Updated");
                            }
                            else
                            {
                                Console.WriteLine("Result-> Product not Updated. Please check data");
                            }
                            Console.ReadKey();
                            break;
                        }
                    case 0:
                        {
                            Console.Clear();
                            Program.login();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter correct choice");
                            break;
                        }
                }
            }
        }
                    
        
       
        public static void UserMenu()
        {
            var ctx = new MyDebContext();
        
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\tLogged in as User\n");
                Console.WriteLine("----------------------------------------\nWhat operation do you wish to perform?\n" +
                    "1. Get product Data\n" +
                    "2. Update\n" +
                    "0. Logout\n----------------------------------------");
                try
                {
                    user_choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                    Console.ReadKey();
                    return;
                }
                switch (user_choice)
                {
                    case 1:
                        {
                           
                            var findUserData = ctx.USERS.First(x => x.User_Name ==Program.username );
                            
                            getProductUserAccess(findUserData.Product_Access);
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            updateProductData();                            
                            break;
                        }
                   
                    case 0:
                        {
                            Console.Write("Are you sure you want to logout? (y/n)");
                            if ("y" == Console.ReadLine().ToLower())
                            {
                                AdminOperations.loggedIn = 0;
                                Program.username = "";
                                Console.Clear();
                                Program.Homepage();
                                //System.Environment.Exit(0);
                            }
                            else
                            {
                                Console.WriteLine("Please enter y or no.");
                                Console.ReadKey();
                                continue;
                            }
                            
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter correct choice");
                            break;
                        }
                }
            }

        }
    }
}
