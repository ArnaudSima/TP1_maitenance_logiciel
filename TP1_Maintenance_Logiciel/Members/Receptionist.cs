using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP1_Maintenance_Logiciel.Helper;
using TP1_Maintenance_Logiciel.Members;
using Util;

namespace SchoolManager
{
    public class Complaint : EventArgs
    {
        public DateTime ComplaintTime { get; set; }
        public string ComplaintRaised { get; set; }
    }

    public class Receptionist : SchoolMember
    {
        private int Income { get; set; }
        public int Balance { get; set; }
        public event EventHandler<Complaint> ComplaintRaised;

        public Receptionist(int income = 10000)
        {
            if(income <=0) {
                Console.WriteLine("Warning: The income cannot be negative or equal to zero");
                income = 0;
            }
            Income = income;
            Balance = 0;
        }

        public Receptionist(string name, string address, int phoneNum, int income = MembersSalary.ReceptionnistSalary)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Warning: The name cannot be empty");
                name = "default name";
            }
            if (string.IsNullOrWhiteSpace(address) || string.IsNullOrEmpty(address))
            {
                Console.WriteLine("Warning: The address cannot be empty");
                address = "default address";
            }
            string phoneInput = phoneNum.ToString();
            int phoneTest;
            if (!int.TryParse(phoneInput, out phoneTest) || phoneTest == 0)
            {
                Console.WriteLine("Warning: The number must only have number");
                phoneNum = 0;
            }
            string incomeInput = phoneNum.ToString();
            int incomeTest;
             if(!int.TryParse(incomeInput, out incomeTest) || incomeTest <= 0)
            {
                Console.WriteLine("Warning: The number must only have number or cannot be negative");
                income = 0;
            }
            Name = name;
            Address = address;
            Phone = phoneNum;
            Income = income;
            Balance = 0;
        }
        public Receptionist(){}
        

        public override Action Display => () =>
        {
            Console.WriteLine(Program.Receptionist.ToString());
        };

        public override Action Pay => () =>
        {

            NetworkDelay.SimulateNetworkDelay();
            Balance += MembersSalary.ReceptionnistSalary;
            Console.WriteLine($"Paid Principal : {Name}. Total Balance: {Balance}");
            UndoEntry entry = new UndoEntry();
            entry.Undo = () =>
            {
                Program.Receptionist.Balance -= MembersSalary.ReceptionnistSalary;
            };
            entry.Description = $"Billing the receptionnist : {ToString}";
            UndoManager.Push(entry);
            Program.Flag = true;
        };

        public override Action RaiseComplaint => () =>
        {
            string complaintTest = "";
            bool state = false;
            Complaint complaint = new Complaint();
            complaint.ComplaintTime = DateTime.Now;
            while (!state)
            {
                complaintTest = ConsoleHelper.AskQuestion("Please enter your Complaint: ");
                if (string.IsNullOrEmpty(complaintTest) || string.IsNullOrWhiteSpace(complaintTest)){
                    Console.WriteLine("Warning: The complain cannot be empty");
                }
                else
                {
                    state = true;
                }
            }
            //complaint.ComplaintRaised = ConsoleHelper.AskQuestion("Please enter your Complaint: ");
            Console.WriteLine("\nThis is a confirmation that we received your complaint. The details are as follows:");
            Console.WriteLine($"---------\nComplaint Time: {complaint.ComplaintTime.ToLongDateString()}, {complaint.ComplaintTime.ToLongTimeString()}");
            Console.WriteLine($"Complaint Raised: {complaint.ComplaintRaised}\n---------");
            Program.Flag = true;
        };
        public override Action Add => () =>
        {
            string nameTest, addressTest, phoneTest = "";
            bool entrerValide = true;
            
            UndoEntry entry = new UndoEntry();
            entry.Undo = () =>
            {
                Program.Receptionist = new Receptionist(Program.Receptionist.Name, Program.Receptionist.Address, Program.Receptionist.Phone);
            };
            entry.Description = $"Reverting to the receptionnist : {ToString()}";
            UndoManager.Push(entry);
            Console.WriteLine("Please enter the Receptionist information.");
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
                if (!int.TryParse(phoneTest, out phoneInput))
                {
                    Console.WriteLine("Warning: The phone number must have only number. ");

                }
                else if (phoneInput == 0 || string.IsNullOrWhiteSpace(phoneTest) || string.IsNullOrEmpty(phoneTest))
                {
                    Console.WriteLine("Warning: The phone number cannot be equal to zero or empty ");
                    entrerValide = false;
                }
                else
                {
                    entrerValide = true;
                }
            }
            Program.Receptionist.Name = nameTest;
            Program.Receptionist.Address = addressTest;
            Program.Receptionist.Phone = int.Parse(phoneTest);
            Program.Flag = true;
        };


        private string ToString()
        {
            return $"Name: {Name}, Address: {Address}, Phone: {Phone}, Income: ${Income}, Balance : ${Balance}";
        }
    }
}
