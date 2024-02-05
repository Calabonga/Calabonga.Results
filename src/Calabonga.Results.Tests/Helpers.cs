namespace Calabonga.Results.Tests;

[Serializable]
public class CustomException : Exception
{
    public CustomException(string message) : base(message)
    {

    }
}

[Serializable]
public class InnerCustomException : Exception { }

public class Person
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }
}