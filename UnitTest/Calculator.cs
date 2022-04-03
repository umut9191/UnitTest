using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class Calculator
    {
        private ICalculatorService _calculatorService;
        public Calculator(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }
        public int add(int a , int b)
        {
            //https://calculator.com/add/2/3 örneğin ortalama 5 sn sürer 
            //if (a==0 || b==0)
            //{
            //    return 0;
            //}
            ////return a + b; 
            return _calculatorService.add(a,b);
        }

        public int multip(int a, int b)
        {
            return _calculatorService.multip(a, b);
        }
    }
}
