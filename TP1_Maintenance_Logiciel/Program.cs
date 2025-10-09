using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Threading.Tasks;
namespace SchoolManager
{
    public class Program
    {
        static public bool Flag;
        static public List<Student> Students = new List<Student>();
        static public List<Teacher> Teachers = new List<Teacher>();
        static public Principal Principal = new Principal();
        static public Receptionist Receptionist = new Receptionist();
        static public Dictionary<int, SchoolMember> StrategiesMembers = new Dictionary<int, SchoolMember>();
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
          

        }

        public static async Task Main(string[] args)
        {
            //J'ai remplace le switch statement par un strategy pattern 
            StrategiesMembers = new Dictionary<int, SchoolMember> { { 1, new Principal() }, { 2, new Teacher() }, { 3, new Student() }, { 4, new Receptionist() } };
            // Just for manual testing purposes.
            AddData();
            Console.WriteLine("-------------- Welcome ---------------\n");
            Flag = true;
            while (Flag)
            {
                int choiceAction = Util.ConsoleHelper.AcceptChoices();
                // if (choiceAction > 6)
                // {
                //     Flag = false;
                //     break;
                // }
                
                int choiceMember = Util.ConsoleHelper.AcceptMemberType();

                if (StrategiesMembers.TryGetValue(choiceMember, out var action))
                {
                    StrategiesMembers[choiceMember].MakeChoice(choiceAction);
                }
                
            }

            Console.WriteLine("\n-------------- Bye --------------");
        }
    }
}
