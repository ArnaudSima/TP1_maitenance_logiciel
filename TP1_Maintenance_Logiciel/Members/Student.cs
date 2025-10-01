using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;

namespace SchoolManager
{
    public class Student : SchoolMember
    {
        private int grade;
        public int Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public Student(string name = "", string address = "", int phoneNum = 0, int grade = 0)
        {
            Name = name;
            Address = address;
            Phone = phoneNum;
            this.grade = grade;
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
            throw new NotImplementedException();
        }

        public void Pay()
        {
            throw new NotImplementedException();
        }

        public void RaiseComplaint()
        {
            throw new NotImplementedException();
        }
        public string toString()
        {
            return $"Name: {Name}, Address: {Address}, Phone: {Phone}, Grade: {Grade}";
        }
    }
}
