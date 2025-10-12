using System;
using TP1_Maintenance_Logiciel.Helper;
using TP1_Maintenance_Logiciel.Members;
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
            for (int i = 0;  i < Program.Teachers.Count; i++)
            {
                Program.Teachers[i].Balance += MembersSalary.TeacherSalary;
            }
            Display?.Invoke();
            UndoEntry entry = new UndoEntry();
            entry.Undo = () =>
            {
                for (int i = 0; i < Program.Teachers.Count; i++)
                {
                    Program.Teachers[i].Balance -= MembersSalary.TeacherSalary;
                }
            };
            entry.Description = "Billing every teacher";
            UndoManager.Push(entry);
        };

        public override Action Add => () =>
        {

            string name = ConsoleHelper.AskQuestion("Name :");
            string adresse = ConsoleHelper.AskQuestion("Address :");
            int phone = ConsoleHelper.AskQuestionInt("Phone number :");
            Teacher newTeacher = new Teacher(name, adresse, phone);
            newTeacher.Subject = ConsoleHelper.AskQuestion("Enter subject: ");
            Program.Teachers.Add(newTeacher);
            UndoEntry entry = new UndoEntry();
            entry.Undo = () =>
            {
                Program.Teachers.Remove(newTeacher);
            };
            entry.Description = $"Removing the teacher {newTeacher.ToString}";
            UndoManager.Push(entry);
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
