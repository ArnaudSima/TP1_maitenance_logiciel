using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TP1_Maintenance_Logiciel.Members;

namespace SchoolManager
{
    public class Program
    {
        static public List<Student> Students = new List<Student>();
        static public List<Teacher> Teachers = new List<Teacher>();
        static public Principal Principal = new Principal();
        static public Receptionist Receptionist = new Receptionist();
        static public Dictionary<int, IMemberAction> StrategiesMembers = new Dictionary<int, IMemberAction>();
        enum SchoolMemberType
        {
            typePrincipal = 1,
            typeTeacher,
            typeStudent,
            typeReceptionist
        }

        public static SchoolMember AcceptAttributes()
        {
            SchoolMember member = new SchoolMember();
            member.Name = Util.Console.AskQuestion("Enter name: ");
            member.Address = Util.Console.AskQuestion("Enter address: ");
            member.Phone = Util.Console.AskQuestionInt("Enter phone number: ");

            return member;
        }

        private static int AcceptChoices()
        {
            return Util.Console.AskQuestionInt("\n1. Add\n2. display\n3. Pay\n4. Raise Complaint\n5. Student Performance\nPlease enter the member type: ");
        }

        public static int AcceptMemberType()
        {
            int x = Util.Console.AskQuestionInt("\n1. Principal\n2. Teacher\n3. Student\n4. Receptionist\nPlease enter the member type: ");
            return Enum.IsDefined(typeof(SchoolMemberType), x) ? x : -1;
        }

        public static void AddPrincpal()
        {
            SchoolMember member = AcceptAttributes();
            Principal.Name = member.Name;
            Principal.Address = member.Address;
            Principal.Phone = member.Phone;
        }

        private static void addStudent()
        {
            SchoolMember member = AcceptAttributes();
            Student newStudent = new Student(member.Name, member.Address, member.Phone);
            newStudent.Grade = Util.Console.AskQuestionInt("Enter grade: ");

            Students.Add(newStudent);
        }

        private static void addTeacher()
        {
            SchoolMember member = AcceptAttributes();
            Teacher newTeacher = new Teacher(member.Name, member.Address, member.Phone);
            newTeacher.Subject = Util.Console.AskQuestion("Enter subject: ");

            Teachers.Add(newTeacher);
        }

        public static void Add()
        {
            Console.WriteLine("\nPlease note that the Principal/Receptionist details cannot be added or modified now.");
            int memberType = AcceptMemberType();

            switch (memberType)
            {
                case 2:
                    addTeacher();
                    break;
                case 3:
                    addStudent();
                    break;
                default:
                    Console.WriteLine("Invalid input. Terminating operation.");
                    break;
            }
        }

       

        public static void Pay()
        {
            Console.WriteLine("\nPlease note that the students cannot be paid.");
            int memberType = AcceptMemberType();

            Console.WriteLine("\nPayments in progress...");
            

            Console.WriteLine("Payments completed.\n");
        }

        public static void RaiseComplaint()
        {
            Receptionist.HandleComplaint();
        }

        private static void handleComplaintRaised(object sender, Complaint complaint)
        {
            Console.WriteLine("\nThis is a confirmation that we received your complaint. The details are as follows:");
            Console.WriteLine($"---------\nComplaint Time: {complaint.ComplaintTime.ToLongDateString()}, {complaint.ComplaintTime.ToLongTimeString()}");
            Console.WriteLine($"Complaint Raised: {complaint.ComplaintRaised}\n---------");
        }

        private static async Task showPerformance()
        {
            double average = await Task.Run(() => Student.averageGrade(Students));
            Console.WriteLine($"The student average performance is: {average}");
        }

        private static void addData()
        {
            Receptionist = new Receptionist("Receptionist", "address", 123);
            Receptionist.ComplaintRaised += handleComplaintRaised;

            Principal = new Principal("Principal", "address", 123);

            for (int i = 0; i < 10; i++)
            {
                Students.Add(new Student(i.ToString(), i.ToString(), i, i));
                Teachers.Add(new Teacher(i.ToString(), i.ToString(), i));
            }
        }

        public static async Task Main(string[] args)
        {
            // Just for manual testing purposes.
            addData();

            Console.WriteLine("-------------- Welcome ---------------\n");

            //Console.WriteLine("Please enter the Princpals information.");
            //AddPrincpal();

            bool flag = true;
            while (flag)
            {

                StrategiesMembers = new Dictionary<int, IMemberAction> { {1, new Student()}, {2, new Teacher()},{3 ,new Principal()},{4, new Receptionist()} };
                int choiceAction = AcceptChoices();

                int choiceMember = AcceptMemberType();

                if (StrategiesMembers.TryGetValue(choiceMember, out var action))
                {
                    flag = SchoolMember.MakeChoice(choiceAction, StrategiesMembers[choiceMember]);
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
