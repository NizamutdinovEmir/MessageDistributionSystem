using Itmo.ObjectOrientedProgramming.Lab3.Entites.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Loggers;

public interface ILogger
{
    void Log(Message messageWithInfo);
}