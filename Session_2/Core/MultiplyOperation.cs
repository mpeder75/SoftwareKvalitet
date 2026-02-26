using System;
using System.Collections.Generic;
using System.Text;

namespace Session_2_Lommeregner.Core;

public class MultiplyOperation : IOperation
{
    public string Symbol => "×";

    public double Execute(double a, double b)
    {
        return a * b;
    }
}