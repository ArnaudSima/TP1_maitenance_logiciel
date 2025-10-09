namespace Tp1Tests;
using SchoolManager;

public class UnitTest1
{
    [Fact]
    public void AcceptMemberType_DeStudent_WithConsoleTyping()
    {
        string name = "Alice";
        string address = "101 avenue du Nord";
        string phone = "514";
        string grade = "40";
        int choiceAddStudent = 4;
        int choiceAction = 1;

        string simulatedInput = $"{name}\n{address}\n{phone}\n{grade}";
        var originalIn = Console.In;
        Console.SetIn(new StringReader(simulatedInput));
        
        bool result = StrategiesMembers[choiceAddStudent].MakeChoice(choiceAction);

        var student = Program.Students[0];
        Assert.Equal(true, result);
        Assert.Equal("Alice", student.Name);
        Assert.Equal("101 avenue du Nord", student.Address);
        Assert.Equal(514, student.Phone);
        Assert.Equal(85, student.Grade);
        Console.SetIn(originalIn);
    }
}
