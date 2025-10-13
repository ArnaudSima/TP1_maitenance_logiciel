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

        public Teacher(string name, string address, int phoneNum, string subject = "sexologie")
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
            Program.Flag = true;
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
            Program.Flag = true;
        };

        public override Action Add => () =>
        {
             string nameTest, addressTest, phoneTest = "", subjectTest;
            bool entrerValide = true;
             //tester le nom
            nameTest = ConsoleHelper.AskQuestion("Enter name: ");
            if (string.IsNullOrEmpty(nameTest) || string.IsNullOrWhiteSpace(nameTest))
            {
                Console.WriteLine("Warning: The name cannot be empty");
                entrerValide = false;
            }
            while (!entrerValide)
            {
                nameTest = ConsoleHelper.AskQuestion("Enter name: ");
                if (string.IsNullOrEmpty(nameTest) || string.IsNullOrWhiteSpace(nameTest))
                {
                    Console.WriteLine("Warning: The name cannot be empty");
                }
                else
                {
                    entrerValide = true;
                }
            }

            //tester l'address
            addressTest = ConsoleHelper.AskQuestion("Enter Address: ");
            if (string.IsNullOrEmpty(addressTest) || string.IsNullOrWhiteSpace(addressTest))
            {
                Console.WriteLine("Warning: The address cannot be empty");
                entrerValide = false;
            }
            while (!entrerValide)
            {
                addressTest = ConsoleHelper.AskQuestion("Enter Address: ");
                if (string.IsNullOrEmpty(addressTest) || string.IsNullOrWhiteSpace(addressTest))
                {
                    Console.WriteLine("Warning: The address cannot be empty");
                }
                else
                {
                    entrerValide = true;
                }
            }

            //tester le numero de telephone
            entrerValide = false;
            int phoneInput;
            while (!entrerValide)
            {
                phoneTest = ConsoleHelper.AskQuestion("Enter Phone: ");
                if (!int.TryParse(phoneTest, out phoneInput))
                {
                    Console.WriteLine("Warning: The phone number must have only number. ");

                }
                else if (phoneInput == 0 || string.IsNullOrWhiteSpace(phoneTest) || string.IsNullOrEmpty(phoneTest))
                {
                    Console.WriteLine("Warning: The phone number cannot be equal to zero or empty ");
                    entrerValide = false;
                }
                else
                {
                    entrerValide = true;
                }
            }
            Teacher newTeacher = new Teacher(nameTest, addressTest, int.Parse(phoneTest));
            //tester le subject
            subjectTest = ConsoleHelper.AskQuestion("Enter subject: ");
            if (string.IsNullOrEmpty(subjectTest) || string.IsNullOrWhiteSpace(subjectTest))
            {
                Console.WriteLine("Warning: The subject cannot be empty");
                entrerValide = false;
            }
            while (!entrerValide)
            {
                subjectTest = ConsoleHelper.AskQuestion("Enter subject: ");
                if (string.IsNullOrEmpty(subjectTest) || string.IsNullOrWhiteSpace(subjectTest))
                {
                    Console.WriteLine("Warning: The subject cannot be empty");
                }
                else
                {
                    entrerValide = true;
                }
            }
            newTeacher.Subject =subjectTest;
            Program.Teachers.Add(newTeacher);
            UndoEntry entry = new UndoEntry();
            entry.Undo = () =>
            {
                Program.Teachers.Remove(newTeacher);
            };
            entry.Description = $"Removing the teacher {newTeacher.ToString()}";
            UndoManager.Push(entry);
            Program.Flag = true;
        };

        public override Action RaiseComplaint => () =>
        {
            Console.WriteLine("Teachers cannot receive complaints,adress the receptionnist");
            Program.Flag = true;
        };

        public string ToString()
        {
            return $"Name: {Name}, Address: {Address}, Phone: {Phone}, Subject: {Subject}, Balance: {Balance}";
        }

    }
}
