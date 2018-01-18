using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace CalculatorService.ServiceModel
{
    [Route("/calculator/sqrt/")]
    public class SquareRoot:IReturn<SquareRootResponse>
    {
        public int Number { get; set; } 
    }
    public class SquareRootResponse
    {
        public int Square { get; set; }

    }
}
