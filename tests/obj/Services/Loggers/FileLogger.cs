using Itmo.ObjectOrientedProgramming.Lab3.Entites.Messages;
using System.Globalization;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Loggers;

public class FileLogger(string filePath) : ILogger
{
    public void Log(Message messageWithInfo)
    {
        string path = Path.Combine(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..")), filePath);
        File.AppendAllText(path, new string('-', 40) + Environment.NewLine);
        File.AppendAllText(path, messageWithInfo.Id.ToString() + Environment.NewLine);
        File.AppendAllText(path, messageWithInfo.RecievedDate.ToString(CultureInfo.InvariantCulture) + Environment.NewLine);
        File.AppendAllText(path, messageWithInfo.ImportantLevel.ToString() + Environment.NewLine);
        File.AppendAllText(path, messageWithInfo.Title + Environment.NewLine);
        File.AppendAllText(path, messageWithInfo.Body + Environment.NewLine);
        File.AppendAllText(path, new string('-', 40));
    }
}