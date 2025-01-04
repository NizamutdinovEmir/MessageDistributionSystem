using Itmo.ObjectOrientedProgramming.Lab3.Entites.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entites.Recipient;

public interface IRecipient
{
    void ReceiveMessage(Message message);
}