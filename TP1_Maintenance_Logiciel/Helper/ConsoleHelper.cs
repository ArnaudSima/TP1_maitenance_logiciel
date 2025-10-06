using SchoolManager;

namespace Util
{
    public class ConsoleHelper
    {
        static public string AskQuestion(string question)
        {
            System.Console.Write(question);
            return System.Console.ReadLine();
        }
        enum SchoolMemberType
        {
            typePrincipal = 1,
            typeTeacher,
            typeStudent,
            typeReceptionist
        }
        static public int AskQuestionInt(string question)
        {
            System.Console.Write(question);
            bool state = int.TryParse(System.Console.ReadLine(), out int result);
            while (!state)
            {
                System.Console.Write("Invalid input. Please try again: ");
                state = int.TryParse(System.Console.ReadLine(), out result);
            }

            return result;
        }
        public static bool MakeChoice(int choice, IMemberAction member)
        {
            member.ActionsPossible()[choice]?.Invoke();
            return false;
            //if (choice == 1)
            //{
            //    member.Add();
            //    return true;
            //}
            //else if (choice == 2)
            //{
            //    member.Display();
            //    return true;
            //}
            //else if (choice == 3)
            //{
            //    member.Pay();
            //    return true;
            //}
            //else if (choice == 4)
            //{
            //    member.RaiseComplaint();
            //    return true;
            //}
            //else if(choice == 5)
            //{
            //    Console.WriteLine("Work in progress...");
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }
        public static int AcceptChoices()
        {
            return AskQuestionInt("\n1. Add\n2. display\n3. Pay\n4. Raise Complaint\n5. Student Performance\nPlease enter the action type: ");
        }

        public static int AcceptMemberType()
        {
            int x = AskQuestionInt("\n1. Principal\n2. Teacher\n3. Student\n4. Receptionist\nPlease enter the member type: ");
            return Enum.IsDefined(typeof(SchoolMemberType), x) ? x : -1;
        }
        public static SchoolMember AcceptAttributes()
        {
            SchoolMember member = new SchoolMember();
            member.Name = AskQuestion("Enter name: ");
            member.Address = AskQuestion("Enter address: ");
            member.Phone = AskQuestionInt("Enter phone number: ");

            return member;
        }
    }
}
