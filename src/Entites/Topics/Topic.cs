using Itmo.ObjectOrientedProgramming.Lab3.Entites.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entites.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entites.Topics;

public class Topic
{
    public string Name { get; private set; }

    public IReadOnlyCollection<IRecipient> Addresses { get; private set; }

    public Topic(string name, IReadOnlyCollection<IRecipient> addresses)
    {
        Name = name;
        Addresses = addresses;
    }

    public void SendMessage(Message message)
    {
        foreach (IRecipient recipient in Addresses)
        {
            recipient.ReceiveMessage(message);
        }
    }
}