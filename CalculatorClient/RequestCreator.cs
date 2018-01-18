using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorService.ServiceModel;

namespace CalculatorClient
{
    internal class RequestCreator
    {
        internal static Add CreateAddRequest()
        {
            List<int> addends = new List<int>();
            while(true)
            {
                Console.WriteLine("Enter addend (integer value or empty to finish) :");
                string valueAsString = Console.ReadLine();

                if (string.IsNullOrEmpty(valueAsString))
                    break;


                int value=0;
                if(int.TryParse(valueAsString, out value) ==true)
                {
                    addends.Add(value);
                }
                
            }

            Add add = new Add();
            add.Addends = addends.ToArray();

            return add;
        }

        internal static Substract CreateSubRequest()
        {
            string minuend = "";
            int minuendNumber;

            while (int.TryParse(minuend,out minuendNumber) == false)
            {
                Console.WriteLine("Please enter minuend :");
                minuend = Console.ReadLine();
                int.TryParse(minuend, out minuendNumber);
            }

            string substrahend = "";
            int substrahendNumber;

            while (int.TryParse(substrahend, out substrahendNumber) == false)
            {
                Console.WriteLine("Please enter substrahend :");
                substrahend = Console.ReadLine();
                int.TryParse(substrahend, out substrahendNumber);
            }

            Substract subRequest = new Substract();
            subRequest.Minuend = minuendNumber;
            subRequest.Substrahend = substrahendNumber;

            return subRequest;

        }

        public static Query CreateQueryRequest(string requestTrackId)
        {
            return new Query { Id = requestTrackId };
        }

        internal static object CreateMultiplyRequest()
        {
            List<int> factors = new List<int>();
            while (true)
            {
                Console.WriteLine("Enter factor (integer value or empty to finish) :");
                string valueAsString = Console.ReadLine();

                if (string.IsNullOrEmpty(valueAsString))
                    break;


                int value = 0;
                if (int.TryParse(valueAsString, out value) == true)
                {
                    factors.Add(value);
                }
            }

            Multiply mul = new Multiply();
            mul.Factors = factors.ToArray();

            return mul;
        }

        internal static object CreateDivideRequest()
        {

            string dividend = "";
            int dividendNumber;

            while (int.TryParse(dividend, out dividendNumber) == false)
            {
                Console.WriteLine("Please enter dividend :");
                dividend = Console.ReadLine();
                int.TryParse(dividend, out dividendNumber);
            }

            string divisor = "";
            int divisorNumber;

            while (int.TryParse(divisor, out divisorNumber) == false)
            {
                Console.WriteLine("Please enter divisor :");
                divisor = Console.ReadLine();
                int.TryParse(divisor, out divisorNumber);
            }

            Divide divRequest = new Divide();
            divRequest.Dividend = dividendNumber;
            divRequest.Divisor = divisorNumber;

            return divRequest;

        }

        internal static SquareRoot CreateSquareRootRequest()
        {
            string square = "";
            int squareNumber;

            while (int.TryParse(square, out squareNumber) == false)
            {
                Console.WriteLine("Please enter number :");
                square = Console.ReadLine();
                int.TryParse(square, out squareNumber);
            }

            SquareRoot sqrt = new SquareRoot();
            sqrt.Number = squareNumber;

            return sqrt;
        }

    }
}
