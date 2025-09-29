using SchoolManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Maintenance_Logiciel.Members
{
    internal class DisplayPrincipal(Principal principal) : IDisplayMembres
    {
        public Principal Principal { get; set; } = principal;

        public void Display()
        {
            Principal.display();
        }
    }
}
