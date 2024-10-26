namespace Domain.Users.ValueObjects;

public sealed class FirstName
{
    private FirstName(string value)
    {
        Value = value;
    }

    private FirstName() { }

    public static FirstName Create(string firstName)
    {
        return new FirstName(firstName);
    }

    public string Value { get; } = default!;
}
