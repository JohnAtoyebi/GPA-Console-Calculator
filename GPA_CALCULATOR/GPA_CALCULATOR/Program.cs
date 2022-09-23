using System;

namespace GPA_CALCULATOR
{
    internal class Program
    {   
        public static void WelcomeInfo()
        {
            Console.WriteLine();
            Console.WriteLine("WELCOME TO ATOYEBI JOHN'S CONSOLE GPA CALCULATOR");
            Console.WriteLine("-----------------I'm a DecaDev-----------------");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
        static void Main(string[] args)
        {
            WelcomeInfo();

            UserInterface userInterface = new UserInterface();

            Console.WriteLine("Type help to show options");
            Console.Write(">");
            string inputLine = Console.ReadLine().Trim();

            while (!inputLine.Equals("") && !inputLine.Equals("exit"))
            {
                if (inputLine.ToLower().Equals("add"))
                {
                    userInterface.StartUpDisplay();
                }
                else if (inputLine.ToLower().Equals("print"))
                {
                    userInterface.DisplayResult();
                }
                else if (inputLine.ToLower().Equals("help"))
                {
                    userInterface.Help();
                }

                else
                {
                    Console.WriteLine("Command not recognised, type help to see all options");
                }

                Console.Write(">");

                inputLine = Console.ReadLine();

                Console.Clear();
            }
        }
    }
    
}
