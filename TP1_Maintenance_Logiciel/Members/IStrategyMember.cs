using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager
{
    public  interface IDisplayMembres
    {
        public void MakeChoice();
        public void Principal();
        public void Student();
        public void Teacher();
        public void Receptionnist();
    }
}
