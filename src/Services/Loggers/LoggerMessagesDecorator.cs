using Itmo.ObjectOrientedProgramming.Lab3.Entites.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entites.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Loggers;

public class LoggerMessagesDecorator : IRecipient
{
    private readonly IRecipient _recipient;

    private readonly ILogger _logger;

    public LoggerMessagesDecorator(IRecipient recipient, ILogger logger)
    {
        _recipient = recipient;
        _logger = logger;
    }

    public void ReceiveMessage(Message message)
    {
        _recipient.ReceiveMessage(message);
        _logger.Log(message);
    }
}