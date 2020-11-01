using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PhoneBook
{
    public class App
    {
        private static ConsoleInput console = new ConsoleInput();
        private static IRecordManager recordManager = new RecordManager();
        private static CommandExecutor commandExecutor = new CommandExecutor(recordManager, console);


        public static void Main(string[] args)
        {
            Prepare();
            start();
        }

        public static void start()
        {
            Console.Clear();

            while (true)
            {
               

                string input = console.ReadLine("phonebook").Trim();

                if (input.Equals("exit"))
                {
                    Console.WriteLine("See you soon <3");
                    return;
                }

                if (input.Equals(""))
                    continue;

                try
                {
                    commandExecutor.Execute(input);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid command");
                }
            }
        }

        public static void Prepare()
        {
            Console.WriteLine("Hello!");
            Console.WriteLine("This is your Phone Book!");
            Console.WriteLine("'help' to get more information :)");
            Console.Write("\nPress enter to continue");
            Console.ReadKey();
        }
    }
}
