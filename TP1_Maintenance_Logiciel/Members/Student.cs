using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using TP1_Maintenance_Logiciel.Helper;
using TP1_Maintenance_Logiciel.Members;
using Util;

namespace SchoolManager
{
    public class Student : SchoolMember
    {
        public int Grade{ get; set; }
        public Student(string name = "", string address = "", int phoneNum = 0, int grade = 0)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Warning: The name cannot be empty");
                name = "default name";
            }

            if (string.IsNullOrEmpty(address) || string.IsNullOrWhiteSpace(address))
            {
                Console.WriteLine("Warning: The address cannot be empty");
                address = "default address";
            }

            string phoneInput = phoneNum.ToString();
            int phoneTest;
            if (phoneNum <= 0 || phoneNum.ToString().Length < 8 || !int.TryParse(phoneInput, out phoneTest))
            {
                Console.WriteLine("Warning: The phone number cannot be empty, equal to zero or longer then 8 characters");
                phoneNum = 0;
            }

            string gradeInput = grade.ToString();
            int gradeTest;
            if (!int.TryParse(gradeInput, out gradeTest))
            {
                Console.WriteLine("Warning: The grade can only have number");
                grade = 0;
            } else if(grade < 0 || grade > 100 )
            {
                Console.WriteLine("Warning: The grade cannot be below zero or over 100");
                grade = 0;
            }
            
            Name = name;
            Address = address;
            Phone = phoneNum;
            Grade = grade;
        }



        public override Action Display => () =>
        {
            foreach (Student student in Program.Students)
            {
                Console.WriteLine(student.ToString());
            }

        };

        public override Action Add => () =>
        {
            string nameTest, addressTest, phoneTest, gradeTest;
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
            phoneTest = ConsoleHelper.AskQuestion("Enter Phone: ");
            int phoneInput;
            if (!int.TryParse(phoneTest, out phoneInput) )
            {
                Console.WriteLine("Warning: The phone number must have only number. ");
                
            }else if (phoneInput == 0 || string.IsNullOrWhiteSpace(phoneTest) || string.IsNullOrEmpty(phoneTest))
            {
                Console.WriteLine("Warning: The phone number cannot be equal to zero or empty ");
                entrerValide = false;
            }
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
            Student newStudent = new Student(nameTest, addressTest, int.Parse(phoneTest));

            //tester la grade
            gradeTest = ConsoleHelper.AskQuestion("Enter Phone: ");
            int gradeInput;
            if (!int.TryParse(gradeTest, out gradeInput) )
            {
                Console.WriteLine("Warning: The phone number must have only number. ");
                
            }else if (gradeInput < 0 || gradeInput > 100 ||string.IsNullOrWhiteSpace(gradeTest) || string.IsNullOrEmpty(gradeTest))
            {
                Console.WriteLine("Warning: The phone number cannot be equal to zero or empty ");
                entrerValide = false;
            }
            while (!entrerValide)
            {
                gradeTest = ConsoleHelper.AskQuestion("Enter Phone: ");
                if (!int.TryParse(gradeTest, out gradeInput))
                {
                    Console.WriteLine("Warning: The phone number must have only number. ");

                }
                else if (gradeInput == 0 || string.IsNullOrWhiteSpace(gradeTest) || string.IsNullOrEmpty(gradeTest))
                {
                    Console.WriteLine("Warning: The phone number cannot be equal to zero or empty ");
                    entrerValide = false;
                }
                else
                {
                    entrerValide = true;
                }
            }
            newStudent.Grade = int.Parse(gradeTest);
            Program.Students.Add(newStudent);
            UndoEntry entry = new UndoEntry();
            entry.Undo = () =>
            {
               Program.Students.Remove(newStudent);
            };
            entry.Description = $"Removing the student : {newStudent.ToString()}";
            UndoManager.Push(entry);
        };

        public override Action Pay => () =>
        {

            Console.WriteLine("A student cannot receive a pay");
        };

        public override Action RaiseComplaint => () => 
        {
           Console.WriteLine("Students cannot receive complaints,adress the receptionnist");
        };
        public string ToString()
        {
            return $"Name: {Name}, Address: {Address}, Phone: {Phone}, Grade: {Grade}";
        }
        public static async Task ShowPerformance()
        {
            //double average = await Task.Run(() => Student.ShowPerformance(Average));
            //Console.WriteLine($"The student average performance is: {average}");
        }
    }
}
