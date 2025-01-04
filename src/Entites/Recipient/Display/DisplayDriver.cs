using Itmo.ObjectOrientedProgramming.Lab3.Entites.Recipient.Display.Services;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entites.Recipient.Display;

public class DisplayDriver
{
    public void Clear()
    {
        Console.Clear();
    }

    public void DisplayText(string text, Color color)
    {
        Console.WriteLine(new ColorModifier(color).Modify(text));
    }

    public void WriteToFile(string text, string fileName)
    {
        string path = Path.Combine(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..")), fileName);
        File.AppendAllText(path, text + Environment.NewLine);
    }
}