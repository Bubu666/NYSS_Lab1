using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace PhoneBook
{
    public class CommandExecutor
    {
        private IRecordManager recordManager;
        private ConsoleInput console;

        public CommandExecutor(IRecordManager recordManager, ConsoleInput console)
        {
            this.recordManager = recordManager;
            this.console = console;
        }

        public void Execute(string command)
        {
            switch (command)
            {
                case "create":
                    CommandCreate();
                    break;

                case "remove":
                    CommandRemove();
                    break;

                case "edit":
                    CommandEdit();
                    break;

                case "records":
                    CommandRecords();
                    break;

                case "records_full":
                    CommandRecordsFull();
                    break;

                case "clear_console":
                    Console.Clear();
                    break;

                case "help":
                    CommandHelp();
                    break;

                default:
                    throw new ArgumentException();
            }
        }

        public void CommandCreate()
        {
            Console.WriteLine();
            Console.WriteLine("==============================");
            Console.WriteLine("====== Record creating =======");
            Console.WriteLine("==============================");
            Console.WriteLine();
            Console.WriteLine("You will need to enter information about record");
            Console.WriteLine();
            if (console.ReadYesOrNo("Do you want to continue?"))
            {
                Console.WriteLine();
                Record record = console.ReadRecord();
                recordManager.AddRecord(record);
                Console.WriteLine($"Record created (id = {record.Id})");
            }
            else
            {
                Console.WriteLine("Operation canceled");
            }
        }

        public void CommandRecordsFull()
        {
            recordManager.GetAllRecords().ForEach(r => r.PrintFullInfo());
        }

        public void CommandEdit()
        {
            int id = (int) console.ReadLong("id:");
            Record record = recordManager.GetRecordByIdOrNull(id);
            if (record != null)
            {
                record.PrintFullInfo();
                while (true)
                {
                    Console.WriteLine("Enter number of field to edit ('0' to stop editing)");
                    Console.WriteLine();
                    Console.WriteLine("1. Lastname");
                    Console.WriteLine("2. Firstname");
                    Console.WriteLine("3. Patronymic");
                    Console.WriteLine("4. Phone number");
                    Console.WriteLine("5. Country");
                    Console.WriteLine("6. Birth date");
                    Console.WriteLine("7. Organization");
                    Console.WriteLine("8. Position");
                    Console.WriteLine("9. Other notes");
                    Console.WriteLine();

                    int field;
                    while (true)
                    {
                        field = (int) console.ReadLong("field:");
                        if (field < 0 || field > 9)
                        {
                            Console.WriteLine("Invalid number");
                            Console.WriteLine("Try again");
                        }
                        else
                        {
                            break;
                        }
                    }

                    if (field == 0)
                    {
                        record.PrintFullInfo();
                        Console.WriteLine("Changes saved");
                        Console.WriteLine();
                        return;
                    }

                    switch (field)
                    {
                        case 1:
                            record.LastName = console.ReadNotEmptyString("Last name:");
                            break;

                        case 2:
                            record.FirstName = console.ReadNotEmptyString("First name:");
                            break;

                        case 3:
                            record.Patronymic = console.ReadStringOrNullIfEmpty("Patronymic (optional):");
                            break;

                        case 4:
                            record.PhoneNumber = console.ReadPhoneNumber("Phone number:");
                            break;

                        case 5:
                            record.Country = console.ReadNotEmptyString("Country:");
                            break;

                        case 6:
                            record.BirthDate = console.ReadDateTimeOrEmpty("Birth date (dd.MM.yyyy) (optional)");
                            break;

                        case 7:
                            record.Organization = console.ReadStringOrNullIfEmpty("Organization (optional):");
                            break;

                        case 8:
                            record.Position = console.ReadStringOrNullIfEmpty("Position (optional):");
                            break;

                        case 9:
                            record.OtherNotes = console.ReadStringOrNullIfEmpty("Other notes (optional):");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Record not found :(");
            }
        }

        public void CommandRecords()
        {
            recordManager.GetAllRecords().ForEach(r => r.PrintShortInfo());
        }

        public void CommandRemove()
        {
            int id = (int) console.ReadLong("id:");
            if (recordManager.RemoveRecordById(id))
            {
                Console.WriteLine("Record removed :)");
            }
            else
            {
                Console.WriteLine("Invalid id -_-");
            }
        }

        public void CommandHelp()
        {
            Console.WriteLine();
            Console.WriteLine("==============================");
            Console.WriteLine("============ Help ============");
            Console.WriteLine("==============================");
            Console.WriteLine();
            Console.WriteLine("create : create new phone record");
            Console.WriteLine("remove : remove record by id");
            Console.WriteLine("edit : edit record");
            Console.WriteLine("help : print information about commands");
            Console.WriteLine("records : print short info about records");
            Console.WriteLine("records_full : print full info about records");
            Console.WriteLine("clear_console : clear console");
            Console.WriteLine("exit : exit the application");
            Console.WriteLine();
        }
    }
}