using Itmo.ObjectOrientedProgramming.Lab3.Entites.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entites.Recipient;

public class GroupRecipient : IRecipient
{
    public IReadOnlyCollection<IRecipient> Addresses { get; private set; }

    public GroupRecipient(IReadOnlyCollection<IRecipient> addresses)
    {
        Addresses = addresses;
    }

    public void ReceiveMessage(Message message)
    {
        foreach (IRecipient recipient in Addresses)
        {
            recipient.ReceiveMessage(message);
        }
    }
}