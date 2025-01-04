using Itmo.ObjectOrientedProgramming.Lab3.Entites.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Loggers;

public class ConsoleLogger : ILogger
{
    public void Log(Message messageWithInfo)
    {
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("Id: " + messageWithInfo.Id);
        Console.WriteLine("Date: " + messageWithInfo.RecievedDate);
        Console.WriteLine("Important Level: " + messageWithInfo.ImportantLevel);
        Console.WriteLine("Title: " + messageWithInfo.Title);
        Console.WriteLine("Body: " + messageWithInfo.Body);
        Console.WriteLine(new string('-', 40));
    }
}