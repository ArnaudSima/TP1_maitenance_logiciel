using System;
using Util;

namespace SchoolManager
{
    public class Teacher : SchoolMember
    {
        public string Subject { get; set; }
        public int Balance { get; set; }

        public Teacher(string name, string address, int phoneNum, string subject = "")
        {
            Name = name;
            Address = address;
            Phone = phoneNum;
            Subject = subject;
            Balance = 0;
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
            NetworkDelay.SimulateNetworkDelay();
            Balance += MembersSalary.TeacherSalary;
            Console.WriteLine($"Paid Principal : {Name}. Total Balance: {Balance}");
        };

        public override Action Add => () =>
        {

            string name = ConsoleHelper.AskQuestion("Name :");
            string adresse = ConsoleHelper.AskQuestion("Address :");
            int phone = ConsoleHelper.AskQuestionInt("Phone number :");
            Teacher newTeacher = new Teacher(name, adresse, phone);
            newTeacher.Subject = ConsoleHelper.AskQuestion("Enter subject: ");
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
