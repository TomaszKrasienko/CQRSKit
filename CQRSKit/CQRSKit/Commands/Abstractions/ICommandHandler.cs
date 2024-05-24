using System.Threading;
using System.Threading.Tasks;

namespace CQRSKit.Commands.Abstractions;

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    Task HandleAsync(ICommand command, CancellationToken cancellationToken = default);
}