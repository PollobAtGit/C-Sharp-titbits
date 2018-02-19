
// General Formula: a^2 + b^2 = c^2
//Babylonians Formula: Given value 'c' (where c >= 2), Height: 2 * c & Base: c * (c - 1)

class Tuple
{
    public int Length { get; set; }
    public int Height { get; set; }
    public int Hypotenuse { get; set; }

    //POI: Second bracket ({/}) is being escaped because string interpolation is being used in which case second brace
    //is a defined character/keyword
    public override string ToString() => $"{{ Length: {Length}, Height: {Height}, Hypotenuse: {Hypotenuse} }}\n";

    //POI: If '@' is used to make the string a verbatim string, '\n' will be interpreted literally not as a new line character
    //public override string ToString() => $@"{{ Length: {Length}, Height: {Height}, Hypotenuse: {Hypotenuse} }}\n";
}

//POI: Range is generating a sequence (IEnumerable<int>) of 'c'
//POI: Performing T[] => U[]
var triples = Enumerable.Range(2, 10).Select(c => new
{
    Length = 2 * c
    , Height = c * c - 1
    , Hypotenuse = c * c + 1
});

var tuples = Enumerable.Range(2, 10).Select(c => new Tuple
{
    Length = 2 * c
    , Height = c * c - 1
    , Hypotenuse = c * c + 1
});

//POI: Interesting! ToString() on anonymous object directly evaluates the property key & property value as JSON object
Console.WriteLine(string.Join(", ", triples));

Console.WriteLine();

//POI: But string.Join doesn't do the same (evaluating as JSON object string) while working with a Custom defined object
//In that case ToString() has to be overridden
Console.WriteLine(string.Join(", ", tuples));