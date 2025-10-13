using System;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;
using TP1_Maintenance_Logiciel.Helper;
using TP1_Maintenance_Logiciel.Members;
using Util;

namespace SchoolManager
{
    public class Principal : SchoolMember
    {
        public int Income { get; set; }
        public int Balance { get; set; }

        public Principal(int? income = null)
        {
            Income = income ?? MembersSalary.PrincipalSalary;
            Balance = 0;
        }

        public Principal(string name, string address, int phoneNum)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Warning: The name cannot be empty");
                name = "default name";
            }
            if (string.IsNullOrEmpty(address) || string.IsNullOrWhiteSpace(address))
            {
                Console.WriteLine("Warning: The address cannot be empty");
                address = "default address";
            }
            string phoneInput = phoneNum.ToString();
            int phoneTest;
            if (phoneNum <= 0 || phoneNum.ToString().Length < 8 || !int.TryParse(phoneInput, out phoneTest))
            {
                Console.WriteLine("Warning: The phone number cannot be empty, equal to zero or longer then 8 characters");
                phoneNum = 0;
            }
   
            Name = name;
            Address = address;
            Phone = phoneNum;
            Balance = 0;
        }

        public override Action Display => () =>
        {
            Console.WriteLine(Program.Principal.ToString());
            Program.Flag = true;
        };

        public override Action Pay => () =>
        {
            NetworkDelay.SimulateNetworkDelay();
            Program.Principal.Balance += MembersSalary.PrincipalSalary;
            Console.WriteLine($"Paid Principal : {Program.Principal.Name}. Total Balance: {Program.Principal.Balance}");
            UndoEntry entry = new UndoEntry();
            entry.Undo = () =>
            {
                Program.Principal.Balance -= MembersSalary.PrincipalSalary;
            };
            entry.Description = $"Billing the principal : {ToString()} ";
            UndoManager.Push(entry);
            Program.Flag = true;
        };

        public override Action Add => () =>
        {
            string nameTest, addressTest, phoneTest = "";
            bool entrerValide = true;
            UndoEntry entry = new UndoEntry();
            entry.Undo = () =>
            {
                Program.Principal = new Principal(Program.Principal.Name, Program.Principal.Address, Program.Principal.Phone);
            };
            entry.Description = $"Removing the principal : {ToString()}";
            UndoManager.Push(entry);
            Console.WriteLine("Please enter the Principals information.");
            
            //tester le nom
            nameTest = ConsoleHelper.AskQuestion("Enter name: ");
            if (string.IsNullOrEmpty(nameTest) || string.IsNullOrWhiteSpace(nameTest))
            {
                Console.WriteLine("Warning: The name cannot be empty");
                entrerValide = false;
            }
            while (!entrerValide)
            {
                nameTest = ConsoleHelper.AskQuestion("Enter name: ");
                if (string.IsNullOrEmpty(nameTest) || string.IsNullOrWhiteSpace(nameTest))
                {
                    Console.WriteLine("Warning: The name cannot be empty");
                }
                else
                {
                    entrerValide = true;
                }
            }

            //tester l'address
            addressTest = ConsoleHelper.AskQuestion("Enter Address: ");
            if (string.IsNullOrEmpty(addressTest) || string.IsNullOrWhiteSpace(addressTest))
            {
                Console.WriteLine("Warning: The address cannot be empty");
                entrerValide = false;
            }
            while (!entrerValide)
            {
                addressTest = ConsoleHelper.AskQuestion("Enter Address: ");
                if (string.IsNullOrEmpty(addressTest) || string.IsNullOrWhiteSpace(addressTest))
                {
                    Console.WriteLine("Warning: The address cannot be empty");
                }
                else
                {
                    entrerValide = true;
                }
            }

            //tester le numero de telephone
            entrerValide = false;
            int phoneInput;
            while (!entrerValide)
            {
                phoneTest = ConsoleHelper.AskQuestion("Enter Phone: ");

                if (string.IsNullOrWhiteSpace(phoneTest))
                {
                    Console.WriteLine("Warning: The phone number cannot be empty.");
                    continue;
                }

                if (!int.TryParse(phoneTest, out phoneInput))
                {
                    Console.WriteLine("Warning: The phone number must contain only numbers.");
                    continue;
                }

                if (phoneInput == 0)
                {
                    Console.WriteLine("Warning: The phone number cannot be zero.");
                    continue;
                }

                entrerValide = true;
            }

            //création du principal
            Program.Principal.Name = nameTest;
            Program.Principal.Address = addressTest;
            Program.Principal.Phone = int.Parse(phoneTest);
            Program.Flag = true;
        };

        public override Action RaiseComplaint => () =>
        {

            Console.WriteLine("If you have a complaint please adress the receptionnist");
            Program.Flag = true;
        };
        public override string ToString()
        {
            return $"Name: {Name}, Address: {Address}, Phone: {Phone}, Balance: {Balance}";
        }

       
    }
}
