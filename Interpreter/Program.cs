using Interpreter;

var expressions = new List<RomanExpression>()
{
    new RomanHundredExpression(),
    new RomanTenExpression(),
    new RomanOneExpression()
};
int input = 975;
var context = new RomanContext(input);

foreach (var expression in expressions)
    expression.Interpret(context);

Console.WriteLine($"Translating Arabic numeral to Roman numeral: {input} = {context.Output}");
Console.ReadKey();