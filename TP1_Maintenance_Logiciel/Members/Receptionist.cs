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

        public Receptionist(int? income = null)
        {
            Income = income ?? MembersSalary.ReceptionnistSalary;
            Balance = 0;
        }

        public Receptionist(string name, string address, int phoneNum, int? income = null)
        {
            Name = name;
            Address = address;
            Phone = phoneNum;
            Income = income ?? MembersSalary.ReceptionnistSalary;
            Balance = 0;
        }
        public Receptionist()
        {

        }

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
            Complaint complaint = new Complaint();
            complaint.ComplaintTime = DateTime.Now;
            complaint.ComplaintRaised = ConsoleHelper.AskQuestion("Please enter your Complaint: ");
            Console.WriteLine("\nThis is a confirmation that we received your complaint. The details are as follows:");
            Console.WriteLine($"---------\nComplaint Time: {complaint.ComplaintTime.ToLongDateString()}, {complaint.ComplaintTime.ToLongTimeString()}");
            Console.WriteLine($"Complaint Raised: {complaint.ComplaintRaised}\n---------");
            Program.Flag = true;
        };
        public override Action Add => () =>
        {

            UndoEntry entry = new UndoEntry();
            entry.Undo = () =>
            {
                Program.Receptionist = new Receptionist(Program.Receptionist.Name, Program.Receptionist.Address, Program.Receptionist.Phone);
            };
            entry.Description = $"Reverting to the receptionnist : {ToString()}";
            UndoManager.Push(entry);
            Console.WriteLine("Please enter the Receptionist information.");
            Program.Receptionist.Name = ConsoleHelper.AskQuestion("Enter name: ");
            Program.Receptionist.Address = ConsoleHelper.AskQuestion("Enter Address: ");
            Program.Receptionist.Phone = Int32.Parse(ConsoleHelper.AskQuestion("Enter Phone: "));
            Program.Flag = true;
        };


        public override string ToString()
        {
            return $"Name: {Name}, Address: {Address}, Phone: {Phone}, Income: ${Income}, Balance : ${Balance}";
        }
    }
}
