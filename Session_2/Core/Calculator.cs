namespace Session_2_Lommeregner.Core;

public class Calculator
{
    private readonly Dictionary<string, IOperation> _operations;

    public Calculator(IEnumerable<IOperation> operations)
    {
        _operations = operations.ToDictionary(o => o.Symbol);
    }

    public double Calculate(string symbol, double a, double b)
    {
        return _operations[symbol].Execute(a, b);
    }
}