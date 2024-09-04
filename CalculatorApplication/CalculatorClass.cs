using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApplication
{
    internal class CalculatorClass
    {
        // Step 4 delegate
        public delegate double Information(double arg1, double arg2);

  
        public event Information CalculateEvent
        {
            add
            {
                Console.WriteLine("Added the Delegate");
               
                _calculateEvent += value;
            }
            remove
            {
                Console.WriteLine("Removed the Delegate");
               
                _calculateEvent -= value;
            }
        }

        private Information _calculateEvent;

        // Step 6
        public double GetSum(double num1, double num2)
        {
            return num1 + num2;
        }

        public double GetDifference(double num1, double num2)
        {
            return num1 - num2;
        }

        public double GetProduct(double num1, double num2)
        {
            return num1 * num2;
        }

        public double GetQuotient(double num1, double num2)
        {
            
            if (num2 == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero");
            }
            return num1 / num2;
        }

        // Step 12
        public double PerformCalculation(double arg1, double arg2)
        {
            if (_calculateEvent != null)
            {
                return _calculateEvent(arg1, arg2);
            }
            throw new InvalidOperationException("No calculation method is set.");
        }
    }
}