//global usings
global using System;
global using static System.Console;
global using Env = System.Environment;
using System.Runtime.CompilerServices;


// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
object obj1 = new Person
{
    FirstName = "Kathleen",
    LastName = "Dollard",
    Address = new Address { City = "Seattle" }
};

if (obj1 is Person { Address: { City: "Seattle" } })
    Console.WriteLine("Seattle");


if (obj1 is Person { Address.City: "Seattle" }) // Extended property pattern
    Console.WriteLine("Seattle");

//CallerArgumentExpression attribute diagnostics
try
{
    Validate(100 < 5);
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

static void Validate(bool condition, [CallerArgumentExpression("condition")] string? message = null)
{
    if (!condition)
    {
        throw new InvalidOperationException($"Argument failed validation: <{message}>");
    }
}

public readonly record struct Person
{
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public Address Address { get; init; }
}
public struct Address
{
    public string City { get; init; } = "<unknown>";
}
//generic attribute
public class GenericAttribute<T> : Attribute { }
