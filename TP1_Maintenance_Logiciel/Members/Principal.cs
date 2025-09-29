using System;

namespace SchoolManager
{
    public class Principal : SchoolMember, IPayroll
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
            Console.WriteLine("Name: {0}, Address: {1}, Phone: {2}", Name, Address, Phone);
        }

        public void Pay()
        {
            //Util.NetworkDelay.PayEntity("Principal", Name, ref Balance, Income);
        }
    }
}
