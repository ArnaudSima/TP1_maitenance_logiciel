using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Maintenance_Logiciel.Members
{
    public class UndoEntry
    {
        public string Option { get; set; }

        public Action Undo = () => { };

    }
}
