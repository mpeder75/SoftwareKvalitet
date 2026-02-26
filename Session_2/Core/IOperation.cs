using System;
using System.Collections.Generic;
using System.Text;

namespace Session_2_Lommeregner.Core
{
    public interface IOperation
    {
        string Symbol { get; }
        double Execute(double a, double b);
    }
}
