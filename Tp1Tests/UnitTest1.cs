namespace Tp1Tests;
using SchoolManager;

public class UnitTest1
{
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
        string phone = "514";
        string grade = "40";

        int choiceAddStudent = 3;
        int choiceAction = 1;

        string simulatedInput = $"{name}\n{address}\n{phone}\n{grade}";
        var originalIn = Console.In;
        Console.SetIn(new StringReader(simulatedInput));
        bool result = Program.StrategiesMembers[choiceAddStudent].MakeChoice(choiceAction);
        
        
        Assert.True(result);

        Assert.Single(Program.Students);
        
        var student = Program.Students[0];
        Assert.Equal(name, student.Name);
        Assert.Equal(address, student.Address);
        Assert.Equal(int.Parse(phone), student.Phone);
        Assert.Equal(int.Parse(grade), student.Grade);
        Console.SetIn(originalIn);
    }

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
        string phone = "687";
        string subject = "French";

        int choiceAddTeacher = 2;
        int choiceAction = 1;

        string simulatedInput = $"{name}\n{address}\n{phone}\n{subject}";
        var originalIn = Console.In;
        Console.SetIn(new StringReader(simulatedInput));
        bool result = Program.StrategiesMembers[choiceAddTeacher].MakeChoice(choiceAction);


        Assert.True(result);

        Assert.Single(Program.Teachers);

        var teacher = Program.Teachers[0];
        Assert.Equal(name, teacher.Name);
        Assert.Equal(address, teacher.Address);
        Assert.Equal(int.Parse(phone), teacher.Phone);
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
        string phone = "782";

        int choiceAddPrincipal = 1;
        int choiceAction = 1;

        string simulatedInput = $"{name}\n{address}\n{phone}";
        var originalIn = Console.In;
        Console.SetIn(new StringReader(simulatedInput));
        bool result = Program.StrategiesMembers[choiceAddPrincipal].MakeChoice(choiceAction);


        Assert.True(result);

        var principal = Program.Principal;
        Assert.Equal(name, principal.Name);
        Assert.Equal(address, principal.Address);
        Assert.Equal(int.Parse(phone), principal.Phone);
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
        string phone = "712";

        int choiceAddPrincipal = 4;
        int choiceAction = 1;

        /*string simulatedInput = $"{name}\n{address}\n{phone}";
        var originalIn = Console.In;
        Console.SetIn(new StringReader(simulatedInput));
        bool result = Program.StrategiesMembers[choiceAddPrincipal].MakeChoice(choiceAction);
        
        
        Assert.True(result);

        var receptionist = Program.Receptionist;
        Assert.Equal(name, receptionist.Name);
        Assert.Equal(address, receptionist.Address);
        Assert.Equal(int.Parse(phone), receptionist.Phone);
        Console.SetIn(originalIn);*/
    }
}
