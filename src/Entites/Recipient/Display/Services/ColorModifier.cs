using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entites.Recipient.Display.Services;

public class ColorModifier(Color color) : ITextModifier
{
    public string Modify(string text)
    {
        return Crayon.Output.Rgb(color.R, color.G, color.B).Text(text);
    }
}