using ServiceStack;
using CalculatorService.ServiceModel;
using ServiceStack.Logging;
using System.Text;
using Newtonsoft.Json;

namespace CalculatorService.ServiceInterface
{
    public class CalculatorServices : Service
    {
        protected const string TrackingIdKey = "X-Evi-Tracking-Id";
        public static ILog Log = LogManager.GetLogger(typeof(CalculatorServices));


        protected string RequestTrackingId
        {
            get
            {
                return base.Request != null ? base.Request.Headers[TrackingIdKey] : string.Empty;
            }
        }

        public AddResponse Any(Add request)
        {
            if (RequestTrackingId.IsNullOrEmpty() == false)
            {
                OperationItem operation = OperationItemFactory.Create(request);
                JournalSingleton.Instance.TrackOperation(RequestTrackingId, operation);
            }

            AddResponse response = Calculator.Sum(request);
            LogOperation("add", request, response);
            return response;
        }

        public SubstractResponse Any(Substract request)
        {
            if (RequestTrackingId.IsNullOrEmpty() == false)
            {
                OperationItem operation = OperationItemFactory.Create(request);
                JournalSingleton.Instance.TrackOperation(RequestTrackingId, operation);
            }

            SubstractResponse response = Calculator.Difference(request);
            LogOperation("sub", request, response);
            return response;
        }

        public MultiplyResponse Any(Multiply request)
        {
            if (RequestTrackingId.IsNullOrEmpty() == false)
            {
                OperationItem operation = OperationItemFactory.Create(request);
                JournalSingleton.Instance.TrackOperation(RequestTrackingId, operation);
            }

            MultiplyResponse response = Calculator.Multiply(request);
            LogOperation("mul", request, response);
            return response;
        }

        public DivideResponse Any(Divide request)
        {
            if (RequestTrackingId.IsNullOrEmpty() == false)
            {
                OperationItem operation = OperationItemFactory.Create(request);
                JournalSingleton.Instance.TrackOperation(RequestTrackingId, operation);
            }

            DivideResponse response = Calculator.Divide(request);
            LogOperation("div", request, response);
            return response;
        }

        public SquareRootResponse Any(SquareRoot request)
        {
            if (RequestTrackingId.IsNullOrEmpty() == false)
            {
                OperationItem operation = OperationItemFactory.Create(request);
                JournalSingleton.Instance.TrackOperation(RequestTrackingId, operation);
            }

            SquareRootResponse response = Calculator.SquareRoot(request);
            LogOperation("sqrt", request, response);
            return response;
        }

        public QueryResponse Any(Query request)
        {
            QueryResponse response = new QueryResponse { Operations = JournalSingleton.Instance.GetIdOperations(RequestTrackingId).ToArray() };
            LogOperation("sqrt", request, response);
            return response;
        }

        private void LogOperation(string operationDescription, object request, object response)
        {
            StringBuilder logInfo = new StringBuilder();

            logInfo.AppendFormat("Operation request {0}",operationDescription);
            logInfo.Append(JsonConvert.SerializeObject(request));
            logInfo.AppendFormat("Operation response {0}",operationDescription);
            logInfo.Append(JsonConvert.SerializeObject(response));

            Log.Info(logInfo);
        }



    }
}