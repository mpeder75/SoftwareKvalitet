using System;
using System.Collections.Generic;
using System.Text;

namespace Training.forloops
{
    public class Forloop
    {

        public double SumList(List<int> myList)
        {
            double result = 0;

            for(int i =0; i < myList.Count; i++)
            {
                result += myList[i];
            }

            return result;
        }


    }
}
