using System;
using System.Diagnostics;
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

        public Principal(int income = MembersSalary.PrincipalSalary)
        {
            Income = income;
            Balance = 0;
        }

        public Principal(string name, string address, int phoneNum)
        {
            Name = name;
            Address = address;
            Phone = phoneNum;
            Balance = 0;
        }
       
        public override Action Display => () => 
        {
            Console.WriteLine(Program.Principal.ToString());
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
            UndoManager.Push(entry);
        };

        public override Action Add => () =>
        {
            UndoEntry entry = new UndoEntry();
            entry.Undo = () =>
            {
                Program.Principal = new Principal(Program.Principal.Name, Program.Principal.Address, Program.Principal.Phone);
            };
            UndoManager.Push(entry);
            Console.WriteLine("Please enter the Principals information.");
            Program.Principal.Name = ConsoleHelper.AskQuestion("Enter name: ");
            Program.Principal.Address = ConsoleHelper.AskQuestion("Enter Address: ");
            Program.Principal.Phone = Int32.Parse(ConsoleHelper.AskQuestion("Enter Phone: "));
           
        };

        public override Action RaiseComplaint => () =>
        {

            Console.WriteLine("If you have a complaint please adress the receptionnist");
        };
        public string ToString()
        {
            return $"Name: {Name}, Address: {Address}, Phone: {Phone}, Balance: {Balance}";
        }

       
    }
}
