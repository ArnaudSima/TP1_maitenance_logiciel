using System;

namespace SchoolManager
{
    public class Teacher : SchoolMember, IMemberAction
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

        public Action Display => () =>
        {
            foreach (Teacher teacher in Program.Teachers)
            {
                Console.WriteLine(teacher.ToString());
            }
        };

        public Action Pay => () =>  
        {
            Util.NetworkDelay.PayEntity("Teacher", Name, ref balance, income);
        };

        public Action Add => () =>
        {

            SchoolMember member = Util.ConsoleHelper.AcceptAttributes();
            Teacher newTeacher = new Teacher(member.Name, member.Address, member.Phone);
            newTeacher.Subject = Util.ConsoleHelper.AskQuestion("Enter subject: ");

            Program.Teachers.Add(newTeacher);
        };

        public Action RaiseComplaint => () =>
        {
            Console.WriteLine("Teachers cannot receive complaints,adress the receptionnist");
        };
        public Dictionary<int, Action> ActionsPossible()
        {
            return new Dictionary<int, Action>()
            {
                { 1, Add },
                { 2, Display },
                { 3, Pay },
                { 4, RaiseComplaint }
            };
        }
        public string ToString()
        {
            return $"Name: {Name}, Address: {Address}, Phone: {Phone}, Subject: {Subject}";
        }

    }
}
