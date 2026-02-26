using System;
using System.Collections.Generic;
using System.Text;

namespace Session_2_Lommeregner.Core;

public class CalculatorEngine
{
    public string Display { get; private set; } = "0";
    private readonly Calculator _calculator;
    private string _currentOperator;
    private double _currentValue;
    private bool _isNewNumber = true;
    private double _storedValue;

    public CalculatorEngine(Calculator calculator)
    {
        _calculator = calculator;
    }

    public void EnterNumber(string number)
    {
        if (_isNewNumber)
        {
            Display = number;
            _isNewNumber = false;
        }
        else
        {
            Display += number;
        }
    }

    public void SetOperator(string op)
    {
        _storedValue = double.Parse(Display);
        _currentOperator = op;
        _isNewNumber = true;
    }

    public void Calculate()
    {
        _currentValue = double.Parse(Display);
        var result = _calculator.Calculate(_currentOperator, _storedValue, _currentValue);

        Display = result.ToString();
        _isNewNumber = true;
    }

    public void Clear()
    {
        Display = "0";
        _storedValue = 0;
        _currentValue = 0;
        _currentOperator = null;
        _isNewNumber = true;
    }
}