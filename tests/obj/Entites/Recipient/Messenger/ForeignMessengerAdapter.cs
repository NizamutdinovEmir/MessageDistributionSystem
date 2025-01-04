using Itmo.ObjectOrientedProgramming.Lab3.Entites.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entites.Recipient.Messenger;

public class ForeignMessengerAdapter : IRecipient
{
    private readonly IForeignMessenger _foreignMessenger;

    public ForeignMessengerAdapter(IForeignMessenger foreignMessenger)
    {
        this._foreignMessenger = foreignMessenger;
    }

    public void ReceiveMessage(Message message)
    {
        _foreignMessenger.SendMessage("New message", message.FormatToString());
    }
}