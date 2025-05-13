namespace OneOfDemo;

public class StringOrNumber(OneOf<string, int, double> value) : OneOfBase<string, int, double>(value)
{
    public static implicit operator StringOrNumber(string value) => new (value);
    public static implicit operator StringOrNumber(int value) => new (value);
    public static implicit operator StringOrNumber(double value) => new (value);

    public (bool isNumber, int number) GetNumberAsInt() =>
        Match(
            s => (int.TryParse(s, out var n), n),
            i => (true, i),
            d => (true, Convert.ToInt32(d))
        );

}