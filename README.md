# TP1_maitenance_logiciel
## Table des matières
### Issue  Principal/Program
Correction du codesmell GodClass :
```C#
    public class Program
    {
        static public List<Student> Students = new List<Student>();
        static public List<Teacher> Teachers = new List<Teacher>();
        static public Principal Principal = new Principal();
        static public Receptionist Receptionist = new Receptionist();
        static public Dictionary<int, IMemberAction> StrategiesMembers = new Dictionary<int, IMemberAction>();


        //J'ai enleve le codesmell godclass en repartissant les methodes dans differentes classes
        private static void AddData()
        {
            Receptionist = new Receptionist("Receptionist", "address", 123);

            Principal = new Principal("Principal", "address", 123);

            for (int i = 0; i < 10; i++)
            {
                Students.Add(new Student(i.ToString(), i.ToString(), i, i));
                Teachers.Add(new Teacher(i.ToString(), i.ToString(), i));
            }
            StrategiesMembers = new Dictionary<int, IMemberAction> { { 1, new Principal() }, { 2, new Teacher() }, { 3,  new Student()}, { 4, new Receptionist() } };

        }

        public static async Task Main(string[] args)
        {
            // Just for manual testing purposes.
            AddData();
            Console.WriteLine("-------------- Welcome ---------------\n");
            bool flag = true;
            while (flag)
            {

                int choiceAction = Util.ConsoleHelper.AcceptChoices();
                if (choiceAction > 5)
                {
                    flag = false;
                    break;
                }
                int choiceMember = Util.ConsoleHelper.AcceptMemberType();

                if (StrategiesMembers.TryGetValue(choiceMember, out var action))
                {
                    flag = Util.ConsoleHelper.MakeChoice(choiceAction, StrategiesMembers[choiceMember]);
                }
                else
                {
                    flag = false;
                }
            }

            Console.WriteLine("\n-------------- Bye --------------");
        }
    }
```
Correction du codesmell Switch statement :
```C#
    //J'ai remplace le switch statement par un strategy pattern
    StrategiesMembers = new Dictionary<int, IMemberAction> { { 1, new Principal() }, { 2, new Teacher() }, { 3,  new Student()}, { 4, new Receptionist() } };

}

public static async Task Main(string[] args)
{
    // Just for manual testing purposes.
    AddData();
    Console.WriteLine("-------------- Welcome ---------------\n");
    bool flag = true;
    while (flag)
    {

        int choiceAction = Util.ConsoleHelper.AcceptChoices();
        if (choiceAction > 5)
        {
            flag = false;
            break;
        }
        int choiceMember = Util.ConsoleHelper.AcceptMemberType();

        if (StrategiesMembers.TryGetValue(choiceMember, out var action))
        {
            flag = Util.ConsoleHelper.MakeChoice(choiceAction, StrategiesMembers[choiceMember]);
        }
        else
        {
            flag = false;
        }
    }
```
Correction du codesmell du issue Fix-switch-case-des-sous-actions-#16
```C#
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
            return new Dictionary<int, Action> { {1,Add }, {2,Display }, {3,Pay }, {4,RaiseComplaint},{5, Undo} }; 
        }
        public abstract Action Add { get; }
        public abstract Action Display { get; }
        public abstract Action Pay { get; }
        public abstract Action RaiseComplaint { get; }
        public Action Undo => () => 
        {
            Console.WriteLine("Work in progress");
        };
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
```

```C#
        public override Action Pay => () =>
        {
            NetworkDelay.SimulateNetworkDelay();
            Balance += MembersSalary.PrincipalSalary;
            Console.WriteLine($"Paid Principal : {Name}. Total Balance: {Balance}");
        };
```



