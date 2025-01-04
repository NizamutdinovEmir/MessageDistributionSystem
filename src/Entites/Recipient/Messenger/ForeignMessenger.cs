namespace Itmo.ObjectOrientedProgramming.Lab3.Entites.Recipient.Messenger;

public class ForeignMessenger : IForeignMessenger
{
    public void SendMessage(string notification, string text)
    {
        Console.WriteLine("Messenger" + "\n" + notification + ":" + "\n" + text);
    }
}