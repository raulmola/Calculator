using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorService.ServiceModel;

namespace CalculatorService.ServiceInterface
{
    internal static class OperationItemFactory
    {
        internal static OperationItem Create(Add addRequest)
        {
            string joinedAddends = String.Join<int>("+", addRequest.Addends);

            OperationItem operationItem = new OperationItem();
            operationItem.Operation = "Sum";
            operationItem.Calculation = String.Format("{0}={1}", joinedAddends, Calculator.Sum(addRequest).Sum);
            operationItem.Date = String.Concat(DateTime.Now.ToUniversalTime().ToString("s"), "Z");

            return operationItem;

        }

        internal static OperationItem Create(Substract subRequest)
        {
            string formattedDifference = String.Format("{0}-{1}", subRequest.Minuend, subRequest.Substrahend);

            OperationItem operationItem = new OperationItem();
            operationItem.Operation = "Difference";
            operationItem.Calculation = String.Format("{0}={1}", formattedDifference, Calculator.Difference(subRequest).Difference);
            operationItem.Date = String.Concat(DateTime.Now.ToUniversalTime().ToString("s"), "Z");

            return operationItem;
        }

        internal static OperationItem Create(Multiply mulRequest)
        {
            string joinedFactors = String.Join<int>("*", mulRequest.Factors);

            OperationItem operationItem = new OperationItem();
            operationItem.Operation = "Product";
            operationItem.Calculation = String.Format("{0}={1}", joinedFactors, Calculator.Multiply(mulRequest).Product);
            operationItem.Date = String.Concat(DateTime.Now.ToUniversalTime().ToString("s"), "Z");

            return operationItem;
        }

        internal static OperationItem Create(Divide divRequest)
        {
            DivideResponse divisionResponse = Calculator.Divide(divRequest);

            string formattedQuotient = String.Format("{0}/{1}", divRequest.Dividend, divRequest.Divisor);
            string formattedReminder = String.Format("{0}%{1}", divRequest.Dividend, divRequest.Divisor);

            OperationItem operationItem = new OperationItem();
            operationItem.Operation = "Division";
            operationItem.Calculation = String.Format("{0}={1} {2}={3}", formattedQuotient, divisionResponse.Quotient, formattedReminder, divisionResponse.Reminder);
            operationItem.Date = String.Concat(DateTime.Now.ToUniversalTime().ToString("s"), "Z");

            return operationItem;

        }

        internal static OperationItem Create(SquareRoot sqrtRequest)
        {
            SquareRootResponse sqrtResponse = Calculator.SquareRoot(sqrtRequest);

            OperationItem operationItem = new OperationItem();
            operationItem.Operation = "Square Root";
            operationItem.Calculation = String.Format("sqrt({0})={1}",sqrtRequest.Number, sqrtResponse.Square);
            operationItem.Date = String.Concat(DateTime.Now.ToUniversalTime().ToString("s"), "Z");

            return operationItem;
        }
    }
}
