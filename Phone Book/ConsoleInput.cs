using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PhoneBook
{
    public class ConsoleInput
    {
        public Record ReadRecord()
        {
            return new Record
            {
                LastName = ReadNotEmptyString("Last name:"),
                FirstName = ReadNotEmptyString("First name:"),
                Patronymic = ReadStringOrNullIfEmpty("Patronymic (optional):"),
                PhoneNumber = ReadPhoneNumber("Phone number:"),
                Country = ReadNotEmptyString("Country:"),
                BirthDate = ReadDateTimeOrEmpty("Birth date (dd.MM.yyyy) (optional)"),
                Organization = ReadStringOrNullIfEmpty("Organization (optional):"),
                Position = ReadStringOrNullIfEmpty("Position (optional):"),
                OtherNotes = ReadStringOrNullIfEmpty("Other notes (optional):")
            };
        }

        public string ReadNotEmptyString(string message)
        {
            Console.WriteLine(message);

            while (true)
            {
                var input = ReadLine();

                if (input.Equals(""))
                {
                    Console.WriteLine("String must not be empty");
                    Console.WriteLine("Try again :)");
                    continue;
                }

                return input;
            }
        }

        public string ReadStringOrNullIfEmpty(string message)
        {
            Console.WriteLine(message);
            var input = ReadLine();
            return input.Equals("") ? null : input;
        }

        public long ReadLong(string message)
        {
            Console.WriteLine(message);

            while (true)
            {
                var input = ReadLine();

                try
                {
                    return long.Parse(input);
                }
                catch (Exception)
                {
                    Console.WriteLine("This is not number ^_^");
                    Console.WriteLine("Try again");
                }
            }
        }

        public DateTime ReadDateTimeOrEmpty(string message)
        {
            Console.WriteLine(message);

            while (true)
            {
                var input = ReadLine();

                if (input.Equals(""))
                {
                    return DateTime.MinValue;
                }

                DateTime date;
                if (DateTime.TryParse(input, out date))
                {
                    return date;
                }
                else
                {
                    Console.WriteLine("Invalid date format");
                    Console.WriteLine("Try again");
                }
            }
        }

        public long ReadPhoneNumber(string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("format: 88005553535");
            while (true)
            {
                var input = ReadLine();
                if (Regex.IsMatch(input, "^\\d{11}$"))
                {
                    return long.Parse(input);
                }

                Console.WriteLine("Invalid format");
                Console.WriteLine("Try again");
            }
        }

        public bool ReadYesOrNo(string message)
        {
            Console.WriteLine(message);

            while (true)
            {
                Console.WriteLine("Enter (y/n)");
                var input = ReadLine()?.Trim();

                switch (input)
                {
                    case "y":
                    case "yes":
                        return true;

                    case "n":
                    case "no":
                        return false;

                    default:
                        Console.WriteLine("Invalid format \\/*-*\\/");
                        Console.WriteLine("Try again");
                        break;
                }
            }
        }

        public string ReadLine(string message)
        {
            Console.Write(message);
            return ReadLine();
        }

        public string ReadLine()
        {
            Console.Write("> ");
            return Console.ReadLine();
        }
    }
}