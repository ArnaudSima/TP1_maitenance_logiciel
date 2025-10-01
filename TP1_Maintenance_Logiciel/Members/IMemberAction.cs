using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager 
{ 
    public interface IMemberAction
    {
        public void Add();

        public void Display();


        public void Pay();

        public void RaiseComplaint();
    }
}
