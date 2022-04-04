using Microsoft.EntityFrameworkCore;
using System;
using System.Text.RegularExpressions;

namespace InventoryManagementSystem
{
    class Program
    {
        public static string username = null;

        static void Main(string[] args)
        {
            Homepage();
        }
        public static void Homepage()
        {
            Console.WriteLine("\n\t\t\t\tInventory Management System\n" +
                   "\n\tWe handle the process by which you track your goods throughout your entire supply chain, from purchasing to production to end sales. It governs how you approach inventory management for your business." +
                   "\nThank you visiting us. Please login into our system to enjoy our facilities. \n------------------------------------------------------------------------------------------------------------------------\n");
            string password = "";

            Console.Write("Enter Username: ");
            username = Console.ReadLine();
            //string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username) || 
            while (!Regex.IsMatch(username, @"^[a-zA-Z]+$"))
            {

                Console.Write("Please enter username:  ");
                username = Console.ReadLine();

            }


            if (AdminOperations.isUsernameAvailable(username) == 1)
            {
                Console.Write("Enter Password: ");
                password = Console.ReadLine();
                while (string.IsNullOrEmpty(password))
                {
                    Console.Write("Please enter password: ");
                    password = Console.ReadLine();

                }
                if (AdminOperations.isValidated(password) == 1)
                {
                    Console.WriteLine("\nYou are logged in successfully. We are redirecting you to our menu. Just a moment");
                    Console.ReadKey();

                    Console.Clear();
                    login();
                }
                else
                {
                    Console.WriteLine("Password does not match. Please check with admin.");
                }


            }
            else
            {
                Console.WriteLine("User Does not exist in our system. Please register yourself with admin.");
            }

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

        }
        public static void login()
        {
                switch (AdminOperations.loggedIn)
                {
                    case 1:
                        {
                            AdminOperations.AdminMenu();
                            break;
                        }

                    case 2:
                        {
                            UserOperations.UserMenu();

                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Wrong choice entered. Please try again. ");
                            break;
                        }
                
            }
        }

    }
    class MyDebContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server =SUPRIYAKOL-VD\SQL2017; Database=IMSystemDb; User ID=sa; Password=cybage@123456;");
        }
        public virtual DbSet<USERS> USERS { get; set; }

        public virtual DbSet<PRODUCT_CATEGORIES> PRODUCT_CATEGORIES { get; set; }

        public virtual DbSet<PRODUCTS> PRODUCTS { get; set; }
        public virtual DbSet<ROLE> ROLES { get; }


    }
    


}
