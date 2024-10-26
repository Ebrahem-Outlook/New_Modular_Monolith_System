namespace Domain.Users.ValueObjects;

public sealed class Password
{
    private Password(string value)
    {
        Value = value;
    }

    private Password() { }

    public static Password Create(string password)
    {
        return new Password(password);  
    }

    public string Value { get; }
}
