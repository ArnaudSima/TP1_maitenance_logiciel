using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager
{
    internal class DisplayStudents : IDisplayMembres
    {
        private readonly List<Student> _students;
        public DisplayStudents(List<Student> students) 
        {
            _students = students;
        }
        public void Display()
        {
            foreach (Student student in _students)
            {
                student.display();
            }

        }
    }
}
