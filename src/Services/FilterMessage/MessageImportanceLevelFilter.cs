using Itmo.ObjectOrientedProgramming.Lab3.Entites.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entites.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.FilterMessage;

public class MessageImportanceLevelFilter : IRecipient
{
    private readonly ImportantLevel _importantLevel;

    private readonly IRecipient _recipient;

    public MessageImportanceLevelFilter(ImportantLevel importantLevel, IRecipient recipient)
    {
        _importantLevel = importantLevel;
        _recipient = recipient;
    }

    public void ReceiveMessage(Message message)
    {
        if (_importantLevel == message.ImportantLevel)
        {
            _recipient.ReceiveMessage(message);
        }
    }
}