using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Xml;
using System.IO;

namespace shops
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputcity;
            string inputshop;
            string answer = "K";

            Console.WriteLine("Hello! First enter names - city and shop.");
            Console.WriteLine("If file with grades exists - you can add new grades (press Y)");
            Console.WriteLine("If you answer (N) - you will see statistics calculated from file");
            Console.WriteLine();

            Console.WriteLine("Enter city:");
            inputcity = Console.ReadLine();
            Console.WriteLine("Enter name of shop:");
            inputshop = Console.ReadLine();

            var shop = new SavedShop(inputshop, inputcity);
            shop.GradeAdded += OnGradeAdded;
            shop.GradeAddedBelow3 += OnGradeAddedBelow3;

            if (!File.Exists($"{inputshop}_{inputcity}.txt"))
            {
                answer = "Y";
            }

            while (answer != "Y" && answer != "N")
            {
                Console.WriteLine("Do you want to add new grades? Y/N");
                answer = Console.ReadLine();
            }

            if (answer == "Y")
            {
                EnterGrade(shop);
            }

            var stat = shop.GetStatistics();

            Console.WriteLine($"Grades for shop {shop.Name}, {shop.City}");
            Console.WriteLine($"Highest grade = {stat.High}");
            Console.WriteLine($"Lowest grade  = {stat.Low}");
            Console.WriteLine($"Average grade = {Math.Round(stat.Average, 3)}");
            Console.WriteLine($"Letter grade  = {stat.Letter}");
        }

        private static void EnterGrade(IShop shop)
        {
            while (true)
            {
                Console.WriteLine($"Enter grade for {shop.Name}, {shop.City}. Only 0-5 are allowed. Enter 'q' to finish");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    shop.AddGrade(grade);
                }

                catch (FormatException ex)
                {
                    Console.WriteLine("Enter value 0-5 or q to quit");
                    Console.WriteLine(ex.Message);
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                finally
                {
                    Console.WriteLine("Grade checked");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs args)
        {
            Console.WriteLine($"Grade was checked - event");
        }

        static void OnGradeAddedBelow3(object sender, EventArgs args)
        {
            Console.WriteLine($"Oh no, so poor grade");
        }
    }
}