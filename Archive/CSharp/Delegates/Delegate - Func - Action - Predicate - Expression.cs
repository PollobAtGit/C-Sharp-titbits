using System;

// POI: Expressions are in a seperate namespace. Not in System.Linq. Rather in System.Linq.Expressions
using System.Linq.Expressions;

// TODO: What are common usages of ExpressionTree?
// MI: Expression Trees are not delegates but it can be used to generate a delegate

internal static class Solution
{
    internal static void Main()
    {

        // POI: Action doesn't return anything simply does a job
        Action<int> print = x => Console.WriteLine(x + 10);

        // POI: Return type of Predicate is boolean. Used for quering about data
        Predicate<int> isGreaterThanFive = x => x > 5;

        // POI: Func returns a value
        // POI: Using another delegate (Predicate) inside this delegate (Func)
        Func<int, int, bool> isAdditionGreaterThanFive = (x, y) => isGreaterThanFive(x + y);

        Console.WriteLine(isGreaterThanFive(int.Parse(Console.ReadLine())));
        print(int.Parse(Console.ReadLine()));
        Console.WriteLine(isAdditionGreaterThanFive(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())));

        var paramOne = int.Parse(Console.ReadLine());
        var paramTwo = int.Parse(Console.ReadLine());

        // POI: Expression tree is not a delegate
        BinaryExpression addOne = Expression.MakeBinary
        (
            ExpressionType.Add,
            Expression.Constant(paramOne),
            Expression.Constant(paramTwo)
        );

        BinaryExpression addTwo = Expression.MakeBinary
        (

            // TODO: When to use ExpressionType?
            ExpressionType.Add,

            // POI: Expression.Constant is a static method that returns a Expression
            Expression.Constant(paramOne),

            // POI: Expression.Constant is a static method that returns a Expression
            // POI: Expression.Constant returns a ConstantExpression
            Expression.Constant(paramTwo)
        );

        BinaryExpression multiply = Expression.MakeBinary
        (
            // TODO: What are the available Expression types?
            // TODO: ExpressionType is an enumeration
            ExpressionType.Multiply,

            // POI: addOne is a BinaryExpression which itself is an Expression
            addOne,

            // POI: addTwo is a BinaryExpression which itself is an Expression
            addTwo
        );

        // POI: Compile() generates the Expression Tree but to evaluate it we invoke that method (!) or Expression Tree
        Console.WriteLine(Expression.Lambda<Func<int>>(multiply).Compile()());

        Console.WriteLine(multiply.Left);
        Console.WriteLine(multiply.Right);

        // POI: NodeType returns a ExpressionType which is simply a Enum
        Console.WriteLine(multiply.NodeType);
    }
}

