using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorService.ServiceModel;

namespace CalculatorService.ServiceInterface
{
    internal static class Calculator
    {

        public static AddResponse Sum(Add addRequest)
        {
            AddResponse addResponse = new AddResponse { Sum = 0 };

            foreach (int addend in addRequest.Addends)
                addResponse.Sum += addend;

            return addResponse;
        }

        public static SubstractResponse Difference(Substract subRequest)
        {
            return new SubstractResponse { Difference = subRequest.Minuend -subRequest.Substrahend };
        }

        public static MultiplyResponse Multiply(Multiply mulRequest)
        {
            MultiplyResponse mulResponse = new MultiplyResponse {  Product= 1 };

            foreach (int factor in mulRequest.Factors)
                mulResponse.Product *= factor;

            return mulResponse;
        }

        public static DivideResponse Divide(Divide divRequest)
        {
            DivideResponse divResponse = new DivideResponse();

            divResponse.Quotient = (int)divRequest.Dividend / divRequest.Divisor;
            divResponse.Reminder = divRequest.Dividend % divRequest.Divisor;


            return divResponse;
        }

        internal static SquareRootResponse SquareRoot(SquareRoot sqrtRequest)
        {
            SquareRootResponse sqrtResponse = new SquareRootResponse();

            sqrtResponse.Square = (int)Math.Sqrt(sqrtRequest.Number);

            return sqrtResponse;
        }
    }
}
