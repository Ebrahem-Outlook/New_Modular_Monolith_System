using Domain.Core.Events;

namespace Domain.Users.Events;

public sealed record UserUpdatedDomainEvent(User User) : DomainEvent();
