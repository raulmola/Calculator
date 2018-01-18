using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace CalculatorService.ServiceModel
{
    [Route("/calculator/mul/")]
    public class Multiply: IReturn<MultiplyResponse>
    {
        public int[] Factors { get; set; }
    }

    public class MultiplyResponse
    {
        public int Product { get; set; }
    }

}
