using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace SchoolManager
{
    public class Student : SchoolMember, IMemberAction
    {
        public int Grade{ get; set; }
        public double AverageGrade { get; set; }

        public Student(string name = "", string address = "", int phoneNum = 0, int grade = 0)
        {
            Name = name;
            Address = address;
            Phone = phoneNum;
            Grade = grade;
        }

        public Action Display => () =>
        {
            foreach (Student student in Program.Students)
            {
                Console.WriteLine(student.ToString());
            }

        };

        public static double averageGrade()
        {
            double avg = 0;
            foreach (Student student in Program.Students)
            {
                avg += student.Grade;
            }
            
            return avg / Program.Students.Count;
        }

        public Action Add => () =>
        {

            SchoolMember member = Util.ConsoleHelper.AcceptAttributes();
            Student newStudent = new Student(member.Name, member.Address, member.Phone);
            newStudent.Grade = Util.ConsoleHelper.AskQuestionInt("Enter grade: ");
            Program.Students.Add(newStudent);
        };

        public Action Pay => () =>
        {

            Console.WriteLine("A student cannot receive a pay");
        };

        public Action RaiseComplaint => () => 
        {
           Console.WriteLine("Students cannot receive complaints,adress the receptionnist");
        };
        public string ToString()
        {
            return $"Name: {Name}, Address: {Address}, Phone: {Phone}, Grade: {Grade}";
        }
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
        public static async Task ShowPerformance()
        {
            //double average = await Task.Run(() => Student.ShowPerformance(Average));
            //Console.WriteLine($"The student average performance is: {average}");
        }
    }
}
