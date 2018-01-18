using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace CalculatorService.ServiceModel
{
    [Route("/calculator/div/")]
    public class Divide : IReturn<DivideResponse>
    {
        public int Dividend { get; set; }
        public int Divisor { get; set; }
    }

    public class DivideResponse
    {
        public int Quotient { get; set; }
        public int Reminder { get; set; }

    }

}
