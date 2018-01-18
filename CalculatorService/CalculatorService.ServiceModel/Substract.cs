using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace CalculatorService.ServiceModel
{
    public class Substract : IReturn<SubstractResponse>
    {
        public int Minuend { get; set; }
        public int Substrahend { get; set; }
    }

    public class SubstractResponse
    {
        public int Difference { get; set; }
    }
}
