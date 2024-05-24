namespace CQRSKit.Commands.Abstractions;

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    Task HandleAsync(ICommand command, CancellationToken cancellationToken = default);
}