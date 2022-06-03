using FintessCode.BL.Controller;
using FintessCode.BL.Model;
using System.Globalization;
using System.Resources;

namespace FintessCode.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            var resourceManager = new ResourceManager("FintessCode.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello",culture));

            Console.WriteLine(resourceManager.GetString("EnterName",culture));

            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write(resourceManager.GetString("EnterGender",culture));
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                double weight = ParseDouble("weight");
                double height = ParseDouble("height");

                userController.SetNewUserData(gender, birthDate);
            }

            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("What do you want to do?");
            Console.WriteLine("E - Enter a meal");
            var key = Console.ReadKey();
            Console.WriteLine();

            if(key.Key == ConsoleKey.E)
            {
               var foods = EnterEating();
               eatingController.Add(foods.Food, foods.Weight);

                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }

            Console.ReadLine();
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Enter product name: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("calories");
            var prot = ParseDouble("proteins");
            var fats = ParseDouble("fats");
            var carbs = ParseDouble("carbohydrates");

            var weight = ParseDouble("serving weight");
            var product = new Food(food,calories,prot,fats,carbs);

            return (product, weight);
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Enter date of birth (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid date of birth format.");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Enter {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Invalid date of birth format.");
                }
            }
        }
    }
}