namespace Domain.Users.ValueObjects;

public sealed class LastName
{
    private LastName(string value)
    {
        Value = value;
    }

    private LastName() { }

    public static LastName Create(string lastName)
    {
        return new LastName(lastName);
    }

    public string Value { get; } = default!;
}
