using Itmo.ObjectOrientedProgramming.Lab3.Entites.Messages;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entites.Recipient.Display;

public class DisplayRecipient : IRecipient
{
    private readonly DisplayDriver _driver;

    public Color Color { get; private set; }

    public DisplayRecipient(DisplayDriver driver, Color color)
    {
        _driver = driver;
        Color = color;
    }

    public void ReceiveMessage(Message message)
    {
        _driver.Clear();
        _driver.DisplayText(message.FormatToString(), Color);
        _driver.WriteToFile(message.FormatToString(), "MessageText");
    }
}