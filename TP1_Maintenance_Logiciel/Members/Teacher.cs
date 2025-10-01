using System;

namespace SchoolManager
{
    public class Teacher : SchoolMember, IPayroll, IMemberAction
    {
        public string Subject;
        private int income;
        private int balance;

        public Teacher(string name, string address, int phoneNum, string subject = "", int income = MembersSalary.TeacherSalary)
        {
            Name = name;
            Address = address;
            Phone = phoneNum;
            Subject = subject;
            this.income = income;
            balance = 0;
        }
        public Teacher() { }

        public void Display()
        {
            foreach (Teacher teacher in Program.Teachers)
            {
                Console.WriteLine(teacher.ToString());
            }
        }

        public void Pay()
        {
            Util.NetworkDelay.PayEntity("Teacher", Name, ref balance, income);
        }

        public void Add()
        {
            throw new NotImplementedException();
        }

        public void RaiseComplaint()
        {
            throw new NotImplementedException();
        }
        public string toString()
        {
            return $"Name: {Name}, Address: {Address}, Phone: {Phone}, Subject: {Subject}";
        }

    }
}
