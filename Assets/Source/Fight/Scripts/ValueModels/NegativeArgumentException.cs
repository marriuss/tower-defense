using System;

public class NegativeArgumentException : Exception
{
    private const string ExceptionMessage = "Argument cannot be negative.";

    public NegativeArgumentException() : base(ExceptionMessage) { }
}