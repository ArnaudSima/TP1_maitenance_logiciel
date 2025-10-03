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

    public class Receptionist : SchoolMember, IPayroll, IMemberAction
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

        public void Display()
        {
            Console.WriteLine(Program.Receptionist.ToString());
        }

        public void Pay()
        {
            Util.NetworkDelay.PayEntity("Receptionist", Name, ref Balance, Income);
        }

        public void HandleComplaint()
        {
            Complaint complaint = new Complaint();
            complaint.ComplaintTime = DateTime.Now;
            complaint.ComplaintRaised = Util.ConsoleHelper.AskQuestion("Please enter your Complaint: ");
            HandleComplaintRaised(complaint);
        }
        private  void HandleComplaintRaised(Complaint complaint)
        {
            Console.WriteLine("\nThis is a confirmation that we received your complaint. The details are as follows:");
            Console.WriteLine($"---------\nComplaint Time: {complaint.ComplaintTime.ToLongDateString()}, {complaint.ComplaintTime.ToLongTimeString()}");
            Console.WriteLine($"Complaint Raised: {complaint.ComplaintRaised}\n---------");
        }
        public void Add()
        {
            Console.WriteLine("There can only be one receptionnist!");
        }

        public void RaiseComplaint()
        {
            HandleComplaint();
        }

        private string ToString()
        {
            return $"Name: {Name}, Address: {Address}, Phone: {Phone}, Income: ${Income}, Balance : ${Balance}";
        }

    }
}
