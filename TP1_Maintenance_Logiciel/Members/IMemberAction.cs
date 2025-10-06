using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager 
{ 

        public interface IMemberAction
        {
            public Dictionary<int, Action> ActionsPossible();
            public Action Add { get; }
            public Action Display { get; }
            public Action Pay { get; }
            public Action RaiseComplaint { get; }
        }
    
}
