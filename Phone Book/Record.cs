using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook
{
    public class Record
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public long PhoneNumber { get; set; }
        public string Country { get; set; }
        public DateTime BirthDate { get; set; } = DateTime.MinValue;
        public string Organization { get; set; }
        public string Position { get; set; }
        public string OtherNotes { get; set; }

        public int Id { get; }

        private static int recordCount = 0;

        public Record()
        {
            this.Id = ++recordCount;
        }

        public void PrintFullInfo()
        {
            Console.WriteLine();
            Console.WriteLine("====================");
            Console.WriteLine($"record id    : {Id}");
            Console.WriteLine($"Lastname     : {LastName}");
            Console.WriteLine($"Firstname    : {FirstName}");
            Console.WriteLine($"Patronymic   : {Patronymic}");
            Console.WriteLine($"Phone number : {PhoneNumber}");
            Console.WriteLine($"Country      : {Country}");
            if (BirthDate != DateTime.MinValue)
            {
                Console.WriteLine($"Birth date   : {BirthDate:dd.MM.yyyy}");
            }
            else
            {
                Console.WriteLine("Birth date   : ");
            }
            
            Console.WriteLine($"Organization : {Organization}");
            Console.WriteLine($"Position     : {Position}");
            Console.WriteLine($"Other Notes  : {OtherNotes}");
            Console.WriteLine("====================");
            Console.WriteLine();
        }

        public void PrintShortInfo()
        {
            Console.WriteLine();
            Console.WriteLine("====================");
            Console.WriteLine($"record id    : {Id}");
            Console.WriteLine($"Lastname     : {LastName}");
            Console.WriteLine($"Firstname    : {FirstName}");
            Console.WriteLine($"Phone number : {PhoneNumber}");
            Console.WriteLine("====================");
            Console.WriteLine();
        }
    }
}