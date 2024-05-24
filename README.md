## CQRSKit

### What is CQRSKit?
The CQRS Tools library is designed to support the implementation of the CQRS (Command Query Responsibility Segregation) approach in .NET applications. It provides the necessary structure and tools for managing commands and queries and their appropriate processing and validation.

### Key Features

- **ICommand:**
An interface defining commands that change the application's state. A command contains all the necessary data to perform a specific operation.
IQuery:
- **IQuery<T>:**
An interface defining queries that retrieve data without changing the application's state. A query contains all the necessary data to search or process information.
ICqrsDispatcher:
- **ICqrsDispatcher:**
An interface that manages the distribution of commands and queries to appropriate handlers. The dispatcher provides a central point through which all commands and queries pass, enabling easy monitoring and logging.
- **Validation:**
Support for validating commands and queries before processing them. The library allows defining validation rules that can be applied automatically before performing operations.

## Use Example
#### ICommand
```csharp
public sealed record CreateUserCommand(Guid Id, string FullName) : ICommand;
```
```csharp
internal sealed class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
{
    public Task HandleAsync(CreateUserCommand command, CancellationToken cancellationToken = default)
    {
        [...]
    }
}
```
#### IQuery
```csharp
public sealed record GetUserQuery(Guid Id) : IQuery<UserDto>;
```
```csharp
internal sealed class GetUserQueryHandler : IQueryHandler<GetUserQuery, UserDto>
{
    public Task<UserDto> HandleAsync(GetUserQuery query, CancellationToken cancellationToken = default)
    {
        [...]
    }
}
```
