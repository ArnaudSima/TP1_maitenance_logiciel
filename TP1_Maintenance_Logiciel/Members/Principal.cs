using System;
using System.Diagnostics;
using System.Xml.Linq;
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

        public Principal(string name, string address, int phoneNum, int income = 50000)
        {
            Name = name;
            Address = address;
            Phone = phoneNum;
            Income = income;
            Balance = 0;
        }

        public override Action Display => () =>
        {
            Console.WriteLine(Program.Principal.ToString());
        };

        public override Action Pay => () =>
        {
            NetworkDelay.SimulateNetworkDelay();
            Balance += MembersSalary.PrincipalSalary;
            Console.WriteLine($"Paid Principal : {Name}. Total Balance: {Balance}");
        };

        public override Action Add => () =>
        {
            Console.WriteLine("Please enter the Princpals information.");
            Program.Principal.Name = ConsoleHelper.AskQuestion("Enter name: ");
            Program.Principal.Address = ConsoleHelper.AskQuestion("Enter Address: ");
            Program.Principal.Phone = Int32.Parse(ConsoleHelper.AskQuestion("Enter Phone: "));
        };

        public override Action RaiseComplaint => () =>
        {

            Console.WriteLine("If you have a complaint please adress the receptionnist");
        };
        public override string ToString()
        {
            return $"Name: {Name}, Address: {Address}, Phone: {Phone}, Balance: {Balance}";
        }
    }
}
