namespace FintessCode.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the FitnessCode App.");

            Console.WriteLine("Enter username");

            var name = Console.ReadLine();

            Console.WriteLine("Enter gender");
            var gender = Console.ReadLine();

            Console.WriteLine("Enter date of birth");
            var birthDate =DateTime.Parse(Console.ReadLine()); // TODO: Rewrite

            Console.WriteLine("Enter weight");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter height");
            var height = double.Parse(Console.ReadLine());

            var userController = new BL.Controller.UserController(name, gender, birthDate, weight, height);
            userController.Save();
        }
    }
}