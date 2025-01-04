using Itmo.ObjectOrientedProgramming.Lab3.Entites.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Entites.Messages.Builders;
using Itmo.ObjectOrientedProgramming.Lab3.Entites.Recipient;
using Itmo.ObjectOrientedProgramming.Lab3.Entites.Recipient.Messenger;
using Itmo.ObjectOrientedProgramming.Lab3.Services.FilterMessage;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Loggers;
using Moq;
using Xunit;

namespace Lab3.Tests;

public class TestCases
{
    [Fact]
    public void MessageForUser_CheckShouldBeUnreaded()
    {
        // Arrange
        var user = new User("Emir");
        Message message = new MessageBuilder().
            WithTittle("Test")
           .WithBody("Hello!")
            .SetImportantLevel(ImportantLevel.Low)
            .Build();

        // Act
        user.ReceiveMessage(message);

        // Assert
        Assert.False(user.MarkMessage(message.Id));
    }

    [Fact]
    public void MessageForUser_CheckShouldBeRead()
    {
        // Arrange
        var user = new User("Emir");
        Message message = new MessageBuilder()
            .WithTittle("Test")
           .WithBody("Hello!")
            .SetImportantLevel(ImportantLevel.Low)
            .Build();

        // Act
        user.ReceiveMessage(message);
        user.MarkMessageAsRead(message.Id);

        // Assert
        Assert.True(user.MarkMessage(message.Id));
    }

    [Fact]
    public void MessageForUser_CheckIfMessageAlreadyRead_TryToRead()
    {
        // Arrange
        var user = new User("Emir");
        Message message = new MessageBuilder()
            .WithTittle("Test")
            .WithBody("Hello!")
            .SetImportantLevel(ImportantLevel.Low)
            .Build();

        // Act
        user.ReceiveMessage(message);
        user.MarkMessageAsRead(message.Id);

        // Assert
        Assert.Throws<InvalidOperationException>(() => user.MarkMessageAsRead(message.Id));
    }

    [Fact]
    public void MessageForUserWithFilter()
    {
        // Arrange
        Message message = new MessageBuilder()
            .WithTittle("Test")
            .WithBody("Hello!")
            .SetImportantLevel(ImportantLevel.Low)
            .Build();
        var recipientMock = new Mock<IRecipient>();
        var messageFilter = new MessageImportanceLevelFilter(ImportantLevel.High, recipientMock.Object);

        // Act
        messageFilter.ReceiveMessage(message);

        // Assert
        recipientMock.Verify(r => r.ReceiveMessage(message), Times.Never());
    }

    [Fact]
    public void LoggerMessageWithMock()
    {
        // Arrange
        var recipientMock = new Mock<IRecipient>();
        var loggerMock = new Mock<ILogger>();
        var loggerMessagesDecorator = new LoggerMessagesDecorator(recipientMock.Object, loggerMock.Object);
        Message message = new MessageBuilder()
            .WithTittle("Test")
            .WithBody("Hello!")
            .SetImportantLevel(ImportantLevel.Low)
            .Build();

        // Act
        loggerMessagesDecorator.ReceiveMessage(message);

        // Assert
        recipientMock.Verify(r => r.ReceiveMessage(message), Times.Once);
        loggerMock.Verify(l => l.Log(message), Times.Once);
    }

    [Fact]
    public void MessageForMessengerWithMock()
    {
        // Arrange
        Message message = new MessageBuilder()
            .WithTittle("Test")
            .WithBody("Hello!")
            .SetImportantLevel(ImportantLevel.Low)
            .Build();
        var messengerMock = new Mock<IForeignMessenger>();
        var messengerAdapter = new ForeignMessengerAdapter(messengerMock.Object);

        // Act
        messengerAdapter.ReceiveMessage(message);

        // Assert
        messengerMock.Verify(m => m.SendMessage("New message", message.FormatToString()), Times.Once);
    }

    [Fact]

    public void Send2MessagesWithFilters()
    {
        // Arrange
        Message message = new MessageBuilder()
            .WithTittle("Test")
            .WithBody("Hello!")
            .SetImportantLevel(ImportantLevel.Low)
            .Build();

        Message message2 = new MessageBuilder()
            .WithTittle("Test")
            .WithBody("Hello!")
            .SetImportantLevel(ImportantLevel.Medium)
            .Build();

        var recipientMock = new Mock<IRecipient>();
        var messageFilter = new MessageImportanceLevelFilter(ImportantLevel.Medium, recipientMock.Object);

        // Act
        messageFilter.ReceiveMessage(message);
        messageFilter.ReceiveMessage(message2);

        // Assert
        recipientMock.Verify(r => r.ReceiveMessage(message), Times.Never);
        recipientMock.Verify(r => r.ReceiveMessage(message2), Times.Once);
    }
}