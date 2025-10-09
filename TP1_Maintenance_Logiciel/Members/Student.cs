using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using Util;

namespace SchoolManager
{
    public class Student : SchoolMember
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

        public static double averageGrade()
        {
            double avg = 0;
            foreach (Student student in Program.Students)
            {
                avg += student.Grade;
            }

            return avg / Program.Students.Count;
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
            string name = ConsoleHelper.AskQuestion("Name :");
            string adresse = ConsoleHelper.AskQuestion("Address :");
            int phone = ConsoleHelper.AskQuestionInt("Phone number :");
            Student newStudent = new Student(name,adresse,phone);
            newStudent.Grade = ConsoleHelper.AskQuestionInt("Enter grade: ");
            Program.Students.Add(newStudent);
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
