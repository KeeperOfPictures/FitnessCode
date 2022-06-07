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

            Console.WriteLine("Welcome to FitnessCode app.");

            Console.WriteLine("Enter your username:");

            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write("Enter your Gender: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime("date of birth");
                double weight = ParseDouble("weight");
                double height = ParseDouble("height");

                userController.SetNewUserData(gender, birthDate);
            }

            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("E - Enter a meal");
                Console.WriteLine("A - Enter a exercise");
                Console.WriteLine("Q - Quit");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        
                        exerciseController.Add(exe.Activity, exe.Begin, exe.End);

                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} start: {item.Start.ToShortDateString()} end: {item.Finish.ToShortDateString()}");
                            Console.ReadLine();
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
            }

            Console.ReadLine();
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.WriteLine("Enter exercise name:");
            var name = Console.ReadLine();

            var energy = ParseDouble("calories consumption per minute");

            var begin = ParseDateTime("start of exercise");
            var end = ParseDateTime("end of exercise");

            var activity = new Activity(name, energy);
            return (begin, end, activity);
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

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write($"Enter {value} (dd.MM.yyyy (hh:mm)): ");
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
                    if(value <= 0)
                    {
                        throw new ArgumentException($"{name} cannot be less than or equal to 0.");
                    }
                    return value;
                }
                else
                {
                    Console.WriteLine($"Invalid {value} format.");
                }
            }
        }
    }
}