using System;
using System.Collections.Generic;
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
        private int income;
        private int balance;
        public event EventHandler<Complaint> ComplaintRaised;

        public Receptionist(int income = 10000) 
        {
            this.income = income;
            balance = 0;
        }

        public Receptionist(string name, string address, int phoneNum, int income = MembersSalary.ReceptionnistSalary)
        {
            Name = name;
            Address = address;
            Phone = phoneNum;
            this.income = income;
            balance = 0;
        }
        public Receptionist()
        {

        }

        public void Display()
        {
            Console.WriteLine("Name: {0}, Address: {1}, Phone: {2}", Name, Address, Phone);
        }

        public void Pay()
        {
            Util.NetworkDelay.PayEntity("Receptionist", Name, ref balance, income);
        }

        public void HandleComplaint()
        {
            Complaint complaint = new Complaint();
            complaint.ComplaintTime = DateTime.Now;
            complaint.ComplaintRaised = Util.Console.AskQuestion("Please enter your Complaint: ");

            ComplaintRaised?.Invoke(this, complaint);
        }

        public void Add()
        {
            Console.WriteLine("There can only be one receptionnist!");
        }

        public void RaiseComplaint()
        {
            throw new NotImplementedException();
        }

        public bool MakeChoice()
        {
            throw new NotImplementedException();
        }
    }
}
