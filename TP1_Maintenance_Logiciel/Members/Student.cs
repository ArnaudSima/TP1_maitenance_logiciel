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

        public void Display()
        {
            foreach (Student student in Program.Students)
            {
                Console.WriteLine(student.ToString());
            }
            
        }

        public static double averageGrade(List<Student> students)
        {
            double avg = 0;
            foreach (Student student in students)
            {
                avg += student.Grade;
            }
            
            return avg / students.Count;
        }

        public void Add()
        {
            SchoolMember member = Util.ConsoleHelper.AcceptAttributes();
            Student newStudent = new Student(member.Name, member.Address, member.Phone);
            newStudent.Grade = Util.ConsoleHelper.AskQuestionInt("Enter grade: ");
            Program.Students.Add(newStudent);
        }

        public void Pay()
        {
           Console.WriteLine("A student cannot receive a pay");
        }

        public void RaiseComplaint()
        {
           Console.WriteLine("Students cannot receive complaints,adress the receptionnist");
        }
        public string ToString()
        {
            return $"Name: {Name}, Address: {Address}, Phone: {Phone}, Grade: {Grade}";
        }
        public static async Task ShowPerformance()
        {
            double average = await Task.Run(() => Student.averageGrade(Program.Students));
            Console.WriteLine($"The student average performance is: {average}");
        }
    }
}
