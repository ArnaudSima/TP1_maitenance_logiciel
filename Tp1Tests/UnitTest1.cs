namespace Tp1Tests;
using SchoolManager;

public class UnitTest1
{
    //Test d'entré dans la console
    [Fact]
    public void AcceptMemberType_DeStudent_WithConsoleTyping()
    {
        Program.StrategiesMembers = new Dictionary<int, SchoolMember> {
            { 1, new Principal() },
            { 2, new Teacher() },
            { 3, new Student() },
            { 4, new Receptionist() } };

        Program.Students.Clear();

        string name = "Alice";
        string address = "101 avenue du Nord";
        int phone = 514;
        int grade = 40;

        int choiceAddStudent = 3;
        int choiceAction = 1;

        string simulatedInput = $"{name}\n{address}\n{phone}\n{grade}";
        var originalIn = Console.In;
        Console.SetIn(new StringReader(simulatedInput));
        Program.StrategiesMembers[choiceAddStudent].MakeChoice(choiceAction);


        Assert.Single(Program.Students);

        var student = Program.Students[0];
        Assert.Equal(name, student.Name);
        Assert.Equal(address, student.Address);
        Assert.Equal(phone, student.Phone);
        Assert.Equal(grade, student.Grade);
        Console.SetIn(originalIn);
    }

    //test si c'est faux

    [Fact]
    public void AcceptMemberType_DeTeacher_WithConsoleTyping()
    {
        Program.StrategiesMembers = new Dictionary<int, SchoolMember> {
            { 1, new Principal() },
            { 2, new Teacher() },
            { 3, new Student() },
            { 4, new Receptionist() } };

        Program.Teachers.Clear();

        string name = "Frank";
        string address = "5105 avenue est";
        int phone = 687;
        string subject = "French";

        int choiceAddTeacher = 2;
        int choiceAction = 1;

        string simulatedInput = $"{name}\n{address}\n{phone}\n{subject}";
        var originalIn = Console.In;
        Console.SetIn(new StringReader(simulatedInput));
        Program.StrategiesMembers[choiceAddTeacher].MakeChoice(choiceAction);


        Assert.Single(Program.Teachers);

        var teacher = Program.Teachers[0];
        Assert.Equal(name, teacher.Name);
        Assert.Equal(address, teacher.Address);
        Assert.Equal(phone, teacher.Phone);
        Assert.Equal(subject, teacher.Subject);
        Console.SetIn(originalIn);
    }

    [Fact]
    public void AcceptMemberType_DePrincipal_WithConsoleTyping()
    {
        Program.StrategiesMembers = new Dictionary<int, SchoolMember> {
            { 1, new Principal() },
            { 2, new Teacher() },
            { 3, new Student() },
            { 4, new Receptionist() } };

        string name = "Arnaud";
        string address = "12 Sherbrooke";
        int phone = 782;

        int choiceAddPrincipal = 1;
        int choiceAction = 1;

        string simulatedInput = $"{name}\n{address}\n{phone}";
        var originalIn = Console.In;
        Console.SetIn(new StringReader(simulatedInput));
        Program.StrategiesMembers[choiceAddPrincipal].MakeChoice(choiceAction);


        var principal = Program.Principal;
        Assert.Equal(name, principal.Name);
        Assert.Equal(address, principal.Address);
        Assert.Equal(phone, principal.Phone);
        Console.SetIn(originalIn);
    }

    [Fact]
    public void AcceptMemberType_DeReceptionist_WithConsoleTyping()
    {
        Program.StrategiesMembers = new Dictionary<int, SchoolMember> {
            { 1, new Principal() },
            { 2, new Teacher() },
            { 3, new Student() },
            { 4, new Receptionist() } };

        string name = "Béattrice";
        string address = "100 Levancour";
        int phone = 712;

        int choiceAddPrincipal = 4;
        int choiceAction = 1;

        string simulatedInput = $"{name}\n{address}\n{phone}";
        var originalIn = Console.In;
        Console.SetIn(new StringReader(simulatedInput));
        Program.StrategiesMembers[choiceAddPrincipal].MakeChoice(choiceAction);


        var receptionist = Program.Receptionist;
        Assert.Equal(name, receptionist.Name);
        Assert.Equal(address, receptionist.Address);
        Assert.Equal(phone, receptionist.Phone);
        Console.SetIn(originalIn);
    }

    //Test de logique 
    [Fact]
    public void RaiseIncome_DeTeacher()
    {
        Program.StrategiesMembers = new Dictionary<int, SchoolMember> {
            { 1, new Principal() },
            { 2, new Teacher() },
            { 3, new Student() },
            { 4, new Receptionist() } };

        Program.Teachers.Add(new Teacher("", "", 0));
        var teacher = Program.Teachers[0];

        int balanceAttendu = 25000;

        int choiceAction = 3;
        int choicePayTeacher = 2;

        Program.StrategiesMembers[choicePayTeacher].MakeChoice(choiceAction);
        int balanceTest = teacher.Balance;

        Assert.Equal(balanceTest, balanceAttendu);
    }

    [Fact]
    public void RaiseIncome_DePrincipal()
    {
        Program.StrategiesMembers = new Dictionary<int, SchoolMember> {
            { 1, new Principal() },
            { 2, new Teacher() },
            { 3, new Student() },
            { 4, new Receptionist() } };

        Program.Principal = new Principal("Principal", "address", 123);
        var principal = Program.Principal;

        int balanceAttendu = 50000;

        int choiceAction = 3;
        int choicePayPrincipal = 1;

        Program.StrategiesMembers[choicePayPrincipal].MakeChoice(choiceAction);
        int balanceTest = principal.Balance;

        Assert.Equal(balanceTest, balanceAttendu);
    }
    
    [Fact]
    public void RaiseIncome_DeReceptionist()
    {
        Program.StrategiesMembers = new Dictionary<int, SchoolMember> {
            { 1, new Principal() },
            { 2, new Teacher() },
            { 3, new Student() },
            { 4, new Receptionist() } };

        Program.Receptionist = new Receptionist("Receptionist", "address", 123);
        var receptionist = Program.Receptionist;

        int balanceAttendu = 10000;

        int choiceAction = 3;
        int choicePayReceptionist = 4;

        Program.StrategiesMembers[choicePayReceptionist].MakeChoice(choiceAction);
        int balanceTest = receptionist.Balance;

        Assert.Equal(balanceTest, balanceAttendu);
    }
}
