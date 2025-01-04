using Itmo.ObjectOrientedProgramming.Lab3.Entites.Messages;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entites.Recipient;

public class User : IRecipient
{
    public string Name { get; private set; }

    public Guid Id { get; private set; }

    public Collection<Message> Messages { get; private set; } = [];

    public User(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
    }

    public void ReceiveMessage(Message message)
    {
        if (Messages.Contains(message))
        {
            throw new InvalidOperationException("Message already exists.");
        }

        Messages.Add(message);
    }

    public void MarkMessageAsRead(Guid messageId)
    {
        foreach (Message message in Messages)
        {
            if (message.Id == messageId)
            {
                message.MarkAsRead();
                return;
            }
        }

        throw new KeyNotFoundException($"Message with ID {messageId} not found.");
    }

    public bool MarkMessage(Guid messageId)
    {
        foreach (Message message in Messages)
        {
            if (message.Id == messageId)
            {
                return message.IsRead;
            }
        }

        throw new KeyNotFoundException($"Message with ID {messageId} not found");
    }
}