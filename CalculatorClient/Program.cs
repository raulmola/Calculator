using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack;
using CalculatorService.ServiceModel;
using Newtonsoft.Json;

namespace CalculatorClient
{
    class Program
    {
        protected const string TrackingIdKey = "X-Evi-Tracking-Id";
        private static JsonHttpClient client;
        static void Main(string[] args)
        {
            var calculatorServiceBaseURI = args.Length>0 ? args[0] : "http://localhost:8088";

            client = new JsonHttpClient(calculatorServiceBaseURI);

            string requestedOperation = String.Empty;

            while (true)
            {
                requestedOperation = GetOperation();
                if (requestedOperation.Equals("exit"))
                    break;

                string requestTrackingId = GetRequestTrackId();

                string formattedResponse = GetJsonFormattedResponse(requestedOperation, requestTrackingId);

                Console.WriteLine("Operation result for {0} is :", requestedOperation);
                Console.WriteLine(formattedResponse);

            }


            Console.WriteLine("Press any to exit client");
            Console.ReadKey();
            Console.WriteLine("Bye!");
        }

        private static string GetJsonFormattedResponse(string requestedOperation, string requestTrackingId)
        {
            string formattedResponse="";

            if (requestTrackingId.IsEmpty() == false)
                client.AddHeader(TrackingIdKey, requestTrackingId);

            switch (requestedOperation)
            {
                case "add":
                    var addRequest = RequestCreator.CreateAddRequest();
                    var addResponse = client.Post<AddResponse>(addRequest);
                    formattedResponse = JsonConvert.SerializeObject(addResponse);
                    break;

                case "sub":
                    var subRequest = RequestCreator.CreateSubRequest();
                    var subResponse = client.Post<SubstractResponse>(subRequest);
                    formattedResponse = JsonConvert.SerializeObject(subResponse );
                    break;

                case "mul":
                    var mulRequest = RequestCreator.CreateMultiplyRequest();
                    var mulResponse = client.Post<MultiplyResponse>(mulRequest);
                    formattedResponse = JsonConvert.SerializeObject(mulResponse);
                    break;

                case "div":
                    var divRequest = RequestCreator.CreateDivideRequest();
                    var divResponse = client.Post<DivideResponse>(divRequest);
                    formattedResponse = JsonConvert.SerializeObject(divResponse);
                    break;

                case "sqrt":
                    var sqrtRequest = RequestCreator.CreateSquareRootRequest();
                    var sqrtResponse = client.Post<SquareRootResponse>(sqrtRequest);
                    formattedResponse = JsonConvert.SerializeObject(sqrtResponse);
                    break;

                case "query":
                    var queryRequest = RequestCreator.CreateQueryRequest(requestTrackingId);
                    var queryResponse = client.Post<QueryResponse>(queryRequest);
                    formattedResponse = JsonConvert.SerializeObject(queryResponse);
                    break;

                default:
                    formattedResponse = String.Format("No response because requested operation ({0}) is unknown",requestedOperation) ;
                    break;
                

            }

            return formattedResponse;
        }

        private static string GetOperation()
        {
            Console.WriteLine("Enter one of the supported operations add/sub/mul/div/sqrt/query :");
            return Console.ReadLine();

        }

        private static string GetRequestTrackId()
        {
            Console.WriteLine("Enter a tracking id for operation (or leave empty empty):");
            return Console.ReadLine().Trim();

        }

    }
}
