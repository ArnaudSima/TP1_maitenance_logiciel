using SchoolManager;
using System.Text;

namespace Util
{
    public class ConsoleHelper
    {
        static public string AskQuestion(string question)
        {
            Console.Write(question);
            return Console.ReadLine();
        }

        enum SchoolMemberType
        {
            TypePrincipal = 1,
            TypeTeacher,
            TypeStudent,
            TypeReceptionist
        }
        static public int AskQuestionInt(string question)
        {
            Console.Write(question);
            bool state = int.TryParse(Console.ReadLine(), out int result);
            while (!state)
            {
                Console.Write("Invalid input. Please try again: ");
                state = int.TryParse(Console.ReadLine(), out result);
            }

            return result;
        }

        public static int AcceptChoices()
        {
            bool state = false;
            var result = 0;
            while (!state)
            {
                result = AskQuestionInt("\n1. Add\n2. display\n3. Pay\n4. Raise Complaint\n5. Student Performance\n6. Quit\n7. Undo\nPlease enter the action type: ");
                if(result <= 0 || result > 7)
                {
                    Console.WriteLine("Invalid input. Please try again: ");
                }
                else
                {
                    state = true;
                }
            }
            return result;
        }

        public static int AcceptMemberType()
        {
            int x = AskQuestionInt("\n1. Principal\n2. Teacher\n3. Student\n4. Receptionist\nPlease enter the member type: ");
            return Enum.IsDefined(typeof(SchoolMemberType), x) ? x : -1;
        }
        
    }
}
