namespace FintessCode.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the FitnessCode App.");

            Console.WriteLine("Enter username");

            var name = Console.ReadLine();

            var userController = new BL.Controller.UserController(name);
            if (userController.IsNewUser)
            {
                Console.Write("Enter gender: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                double weight = ParseDouble("weight");
                double height = ParseDouble("height");

                userController.SetNewUserData(gender, birthDate);
            }

            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
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
                Console.WriteLine($"Enter {name}: ");
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