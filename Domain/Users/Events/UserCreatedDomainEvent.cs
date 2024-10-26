using Domain.Core.Events;

namespace Domain.Users.Events;

public sealed record UserCreatedDomainEvent(User User) : DomainEvent();
