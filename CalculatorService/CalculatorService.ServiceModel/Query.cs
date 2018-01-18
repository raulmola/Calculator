using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;

namespace CalculatorService.ServiceModel
{
    [Route("/calculator/query/")]
    public class Query:IReturn<QueryResponse>
    {
        public string Id { get; set; }
    }

    public class QueryResponse
    {
        public OperationItem[] Operations { get; set; }
    }

}
