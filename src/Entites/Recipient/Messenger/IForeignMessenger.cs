namespace Itmo.ObjectOrientedProgramming.Lab3.Entites.Recipient.Messenger;

public interface IForeignMessenger
{
    void SendMessage(string notification, string text);
}