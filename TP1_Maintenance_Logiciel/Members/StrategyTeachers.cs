using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager
{
    internal class DisplayTeachers(List<Teacher> teachers) : IDisplayMembres
    {
        private readonly List<Teacher> _teachers = teachers;

        public void Display()
        {
            foreach (Teacher teacher in _teachers)
            {
                teacher.display();
            }
        }
    }
}
