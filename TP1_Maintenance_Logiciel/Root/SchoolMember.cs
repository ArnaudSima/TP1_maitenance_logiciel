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
            return new Dictionary<int, Action> {{1,Add},{2,Display},{3,Pay},{4,RaiseComplaint},{5,StudentPerformance},{6,Quit},{7,Undo}}; 
        }
        public abstract Action Add { get; }
        public abstract Action Display { get; }
        public abstract Action Pay { get; }
        public abstract Action RaiseComplaint { get; }
        public Action StudentPerformance = () => 
        {
            double avg = 0;
            foreach (Student student in Program.Students)
            {
                avg += student.Grade;
            }
            
            Console.WriteLine($"This is the current student performance : \n{avg / Program.Students.Count}");
            Program.Flag = true;
        };
        public Action Quit = () => { 
            Program.Flag = false;
        };
        public Action Undo = () => UndoManager.Undo();
        public  void MakeChoice(int choice)
        {
                ActionsPossible()[choice]?.Invoke();
        }
    }
}
