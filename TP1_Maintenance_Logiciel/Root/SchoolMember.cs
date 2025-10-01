namespace SchoolManager
{
    public class SchoolMember 
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

        public static bool MakeChoice(int choice,IMemberAction member)
        {
            if (choice == 1)
            {
                member.Display();
                return true;
            }
            else if (choice == 2)
            {
                member.Add();
                return true;
            }else if(choice == 3)
            {
                member.Pay();
                return true;
            }else if(choice == 4)
            {
                member.RaiseComplaint();
                return true;
            }
            else
            {
                return true;
            }
        }
       
    }
}
