using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SchoolManager
{
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

            Console.WriteLine("\n-------------- Bye --------------");
        }
    }
}
