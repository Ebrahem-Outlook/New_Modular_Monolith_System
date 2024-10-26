namespace Domain.Users.ValueObjects;

public sealed class Email
{
    private Email(string value)
    {
        Value = value;
    }

    private Email() { }

    public static Email Create(string email)
    {
        return new Email(email);    
    }

    public string Value { get; } = default!;
}
