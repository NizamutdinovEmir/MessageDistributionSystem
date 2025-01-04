namespace Itmo.ObjectOrientedProgramming.Lab3.Entites.Messages;

public class Message
{
    public string Title { get; private set; }

    public string Body { get; private set; }

    public ImportantLevel ImportantLevel { get; private set; }

    public Guid Id { get; }

    public bool IsRead { get; private set; }

    public DateTime RecievedDate { get; private set; }

    public Message(string title, string body, ImportantLevel importantLevel, bool isRead = false)
    {
        Title = title;
        Body = body;
        ImportantLevel = importantLevel;
        Id = Guid.NewGuid();
        IsRead = isRead;
        RecievedDate = DateTime.Now;
    }

    public string FormatToString()
    {
        return Title + '\n' + Body;
    }

    public void MarkAsRead()
    {
        if (IsRead)
        {
            throw new InvalidOperationException("Message is already read.");
        }

        IsRead = true;
    }
}