namespace Itmo.ObjectOrientedProgramming.Lab3.Entites.Messages.Builders;

public interface IMessageBuilder
{
    IMessageBuilder WithTittle(string title);

    IMessageBuilder WithBody(string body);

    IMessageBuilder SetImportantLevel(ImportantLevel importantLevel);

    Message Build();
}