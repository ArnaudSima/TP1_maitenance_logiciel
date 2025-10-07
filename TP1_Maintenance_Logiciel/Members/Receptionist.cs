using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager
{
    public class Complaint : EventArgs
    {
        public DateTime ComplaintTime { get; set; }
        public string ComplaintRaised { get; set; }
    }

    public class Receptionist : SchoolMember
    {
        private int Income;
        private int Balance;
        public event EventHandler<Complaint> ComplaintRaised;

        public Receptionist(int income = 10000) 
        {
            Income = income;
            Balance = 0;
        }

        public Receptionist(string name, string address, int phoneNum, int income = MembersSalary.ReceptionnistSalary)
        {
            Name = name;
            Address = address;
            Phone = phoneNum;
            Income = income;
            Balance = 0;
        }
        public Receptionist()
        {

        }

        public override Action Display => () =>
        {

            Console.WriteLine(Program.Receptionist.ToString());
        };

        public override Action Pay => () =>
        {

            //Util.NetworkDelay.PayEntity("Receptionist", Name, ref Balance, Income);
        };

        public override Action RaiseComplaint => () =>
        {

            Complaint complaint = new Complaint();
            complaint.ComplaintTime = DateTime.Now;
            complaint.ComplaintRaised = Util.ConsoleHelper.AskQuestion("Please enter your Complaint: ");
            Console.WriteLine("\nThis is a confirmation that we received your complaint. The details are as follows:");
            Console.WriteLine($"---------\nComplaint Time: {complaint.ComplaintTime.ToLongDateString()}, {complaint.ComplaintTime.ToLongTimeString()}");
            Console.WriteLine($"Complaint Raised: {complaint.ComplaintRaised}\n---------");
        };
        public override Action Add => () =>
        {

            Console.WriteLine("There can only be one receptionnist!");
        };


        private string ToString()
        {
            return $"Name: {Name}, Address: {Address}, Phone: {Phone}, Income: ${Income}, Balance : ${Balance}";
        }

        public Dictionary<int, Action> ActionsPossible(out bool flag)
        {
            flag = false;
            Dictionary<int,Action> dictionary =  new Dictionary<int, Action>() 
            { 
                { 1, Add },
                { 2, Display },
                { 3, Pay },
                { 4, RaiseComplaint } 
            };
            return dictionary;
        }
    }
}
