using System;
using Util;

namespace SchoolManager
{
    public class Teacher : SchoolMember
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

        public override Action Display => () =>
        {
            foreach (Teacher teacher in Program.Teachers)
            {
                Console.WriteLine(teacher.ToString());
            }
        };

        public override Action Pay => () =>  
        {
            Util.NetworkDelay.PayEntity("Teacher", Name, ref balance, income);
        };

        public override Action Add => () =>
        {

            string name = ConsoleHelper.AskQuestion("Name :");
            string adresse = ConsoleHelper.AskQuestion("Address :");
            int phone = ConsoleHelper.AskQuestionInt("Phone number :");
            Teacher newTeacher = new Teacher(name, adresse, phone);
            newTeacher.Subject = Util.ConsoleHelper.AskQuestion("Enter subject: ");

            Program.Teachers.Add(newTeacher);
        };

        public override Action RaiseComplaint => () =>
        {
            Console.WriteLine("Teachers cannot receive complaints,adress the receptionnist");
        };

        public string ToString()
        {
            return $"Name: {Name}, Address: {Address}, Phone: {Phone}, Subject: {Subject}";
        }

    }
}
