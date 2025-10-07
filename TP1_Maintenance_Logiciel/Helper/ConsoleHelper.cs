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
        public static bool MakeChoice(int choice, SchoolMember member)
        {
            if(member.ActionsPossible().TryGetValue(choice, out var value))
            {
                member.ActionsPossible()[choice]?.Invoke();
                return true;
            }
            else
            {
                return false;
            }

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
        
    }
}
