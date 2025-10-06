using System;
using System.Diagnostics;

namespace SchoolManager
{
    public class Principal : SchoolMember, IMemberAction
    {
        public int Income { get; set; }
        public int Balance { get; set; }

        public Principal(int income = MembersSalary.PrincipalSalary)
        {
            Income = income;
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
       
        public void Display()
        {
            Console.WriteLine(Program.Principal.ToString());
        }

        public Action Pay => () =>
        {

            //Util.NetworkDelay.PayEntity("Principal", Name, ref Balance, Income);
        };

        public Action Add => () =>
        {
            Console.WriteLine("Please enter the Princpals information.");
            SchoolMember member = Util.ConsoleHelper.AcceptAttributes();
            Program.Principal.Name = member.Name;
            Program.Principal.Address = member.Address;
            Program.Principal.Phone = member.Phone;
        };

        public Action RaiseComplaint => () =>
        {

            Console.WriteLine("If you have a complaint please adress the receptionnist");
        };
        public string ToString()
        {
            return $"Name: {Name}, Address: {Address}, Phone: {Phone}, Balance: {Balance}";
        }
    }
}
