namespace SchoolManager
{
     public abstract class SchoolMember 
    {
        public string Name;
        public string Address;
        private int phone;

        public SchoolMember(string name = "", string address = "", int phone = 0)
        {
            Name = name;
            Address = address;
            this.phone = phone;
        }

        public int Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        public Dictionary<int, Action> ActionsPossible()
        {
            return new Dictionary<int, Action> { {1,Add }, {2,Display }, {3,Pay }, {4,RaiseComplaint},{5, Undo}, {6,Quit} }; 
        }
        public abstract Action Add { get; }
        public abstract Action Display { get; }
        public abstract Action Pay { get; }
        public abstract Action RaiseComplaint { get; }
        public Action Undo => () => 
        {
            Console.WriteLine("Work in progress");
        };
        public Action Quit => () =>
        {
            Console.WriteLine("Quit the App");
            Program.Flag = false;
        };
        public  void MakeChoice(int choice)
        {
            if (ActionsPossible().TryGetValue(choice, out var value))
            {
                ActionsPossible()[choice]?.Invoke();
                
            }
            

        }
    }
}
