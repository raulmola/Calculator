using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace CalculatorService.ServiceModel
{
    [Route("/calculator/add/")]
    public class Add:IReturn<AddResponse>
    {
        public int[] Addends { get; set; }
    }

    public class AddResponse
    {
        public int Sum { get; set; }
    }
}
