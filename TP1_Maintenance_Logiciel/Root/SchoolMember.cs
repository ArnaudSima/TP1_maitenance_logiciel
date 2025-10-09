using TP1_Maintenance_Logiciel.Helper;

namespace SchoolManager
{
     public abstract class SchoolMember 
    {
        public string Name;
        public string Address;
        public int Phone { get; set; }

        public SchoolMember(string name = "", string address = "", int phone = 0)
        {
            Name = name;
            Address = address;
            Phone = phone;
        }


        public Dictionary<int, Action> ActionsPossible()
        {
            return new Dictionary<int, Action> { {1,Add }, {2,Display }, {3,Pay }, {4,RaiseComplaint},{7, Undo} }; 
        }
        public abstract Action Add { get; }
        public abstract Action Display { get; }
        public abstract Action Pay { get; }
        public abstract Action RaiseComplaint { get; }
        public Action Undo = UndoManager.Undo();
        public  bool MakeChoice(int choice)
        {
            if (ActionsPossible().TryGetValue(choice, out var value))
            {
                ActionsPossible()[choice]?.Invoke();
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
