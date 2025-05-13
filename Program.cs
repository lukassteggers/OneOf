// Variable, Methods & OneOf.Types

OneOf<string, int, double> stringOrNumberVar = "OneOf-Demo-Value";

OneOf<Yes, No> IsNumber(OneOf<string, int, double> value)
{
    OneOf<Yes, No> result = new OneOf<Yes, No>();
    value.Switch(
        s => result = new No(),
        i => result = new Yes(),
        d => result = new Yes()
        );
    
    return result;
}

// .Match()
Console.WriteLine("Demo OneOf.Match():\n");
var result = stringOrNumberVar.Match<string>(
    s => s,
    i => i.ToString(),
    d => d.ToString(CultureInfo.CurrentCulture)
);

Console.WriteLine(result);
    
Console.WriteLine("-----------------------------------------------------------------------------------------");

// .Switch()
Console.WriteLine("Demo OneOf.Switch():\n");
IsNumber(stringOrNumberVar).Switch(
    yes => Console.WriteLine("Value is not a number"),
    no => Console.WriteLine($"Value is a number")
);

Console.WriteLine("-----------------------------------------------------------------------------------------");

// .TryPickX()
Console.WriteLine("Demo OneOf.TryPickX():\n");
stringOrNumberVar.TryPickT1(out int number, out OneOf<string, double> remainder);
Console.WriteLine(number);
Console.WriteLine(remainder);

Console.WriteLine("-----------------------------------------------------------------------------------------");

Console.WriteLine("Demo OneOf.IsT<T>()/ OneOf.AsT<T>():\n");
if (stringOrNumberVar.IsT0)
{
    Console.WriteLine(stringOrNumberVar.AsT0);
}

// OneOfBase
StringOrNumber stringOrNumber = 42;
stringOrNumber.Switch(
    s => Console.WriteLine($"Variable with OneOf-Base-Type: {s}"),
    i => Console.WriteLine($"Variable with OneOf-Base-Type: {i}"),
    d => Console.WriteLine($"Variable with OneOf-Base-Type: {d}")
);

Console.WriteLine(stringOrNumber.GetNumberAsInt().number);


