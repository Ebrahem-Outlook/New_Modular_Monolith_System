using Domain.Core.BaseType;
using Domain.Users.Events;
using Domain.Users.ValueObjects;

namespace Domain.Users;

public sealed class User : AggregateRoot
{
    private User(FirstName firstName, LastName lastName, Email email, Password password)
        : base(Guid.NewGuid())
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    private User() : base() { }

    public FirstName FirstName { get; private set; } = default!;
    public LastName LastName { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public Password Password { get; private set; } = default!;

    public static User Create(FirstName firstName, LastName lastName, Email email, Password password)
    {
        User user = new User(firstName, lastName, email, password);

        // Raise Event.
        user.RaiseDomainEvent(new UserCreatedDomainEvent(user));

        return user;
    }

    public void Update(string firstName, string lastName, string email, string password)
    {
        FirstName = FirstName.Create(firstName);
        LastName = LastName.Create(lastName);
        Email = Email.Create(email);
        Password = Password.Create(password);

        // Raise Event.
        RaiseDomainEvent(new UserUpdatedDomainEvent(this));
    }
}
