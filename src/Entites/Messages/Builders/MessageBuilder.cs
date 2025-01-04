namespace Itmo.ObjectOrientedProgramming.Lab3.Entites.Messages.Builders;

public class MessageBuilder : IMessageBuilder
{
    private string? _title;
    private string? _body;
    private ImportantLevel _importantLevel;

    public IMessageBuilder WithTittle(string title)
    {
        _title = title;
        return this;
    }

    public IMessageBuilder WithBody(string body)
    {
        _body = body;
        return this;
    }

    public IMessageBuilder SetImportantLevel(ImportantLevel importantLevel)
    {
        _importantLevel = importantLevel;
        return this;
    }

    public Message Build()
    {
        return new Message(
            _title ?? throw new ArgumentNullException(nameof(_title)),
            _body ?? throw new ArgumentNullException(nameof(_body)),
            _importantLevel);
    }
}