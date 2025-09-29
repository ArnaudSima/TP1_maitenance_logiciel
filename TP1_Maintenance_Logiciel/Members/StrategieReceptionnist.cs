using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager
{
    internal class DisplayReceptionist(Receptionist _receptionist) : IDisplayMembres
    {

        public void Display()
        {
            _receptionist.display();

        }
    }
    

    
}
