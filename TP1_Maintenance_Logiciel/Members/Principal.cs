using System;

namespace SchoolManager
{
    public class Principal : SchoolMember, IPayroll, IMemberAction
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
           Program.Principal.Display();
        }

        public void Pay()
        {
            //Util.NetworkDelay.PayEntity("Principal", Name, ref Balance, Income);
        }

        public void Add()
        {
            Console.WriteLine("There can be only one Principal!");
        }

        public void RaiseComplaint()
        {
            Console.WriteLine("If you have a complaint please adress the receptionnist");
        }
    }
}
