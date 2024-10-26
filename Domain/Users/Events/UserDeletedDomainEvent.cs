using Domain.Core.Events;

namespace Domain.Users.Events;

public sealed record UserDeletedDomainEvent(User User) : DomainEvent();
