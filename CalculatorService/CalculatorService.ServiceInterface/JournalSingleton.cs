using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorService.ServiceModel;

namespace CalculatorService.ServiceInterface
{
    public sealed class JournalSingleton
    {
        private static volatile JournalSingleton instance;
        private static volatile Dictionary<string, List<OperationItem>> operationsByTrackId;
        private static object syncRoot = new Object();

        private JournalSingleton() { }

        public static JournalSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new JournalSingleton();
                            operationsByTrackId = new Dictionary<string, List<OperationItem>>();
                        }
                    }
                }

                return instance;
            }
        }

        public void TrackOperation(string requestTrackId, OperationItem operationItem)
        {
            lock (syncRoot)
            {
                List<OperationItem> currentTrackIdOperations;


                if (JournalSingleton.operationsByTrackId.ContainsKey(requestTrackId) == false)
                    JournalSingleton.operationsByTrackId[requestTrackId] = new List<OperationItem>();

                currentTrackIdOperations = JournalSingleton.operationsByTrackId[requestTrackId];

                currentTrackIdOperations.Add(operationItem);

            }
        }

        public List<OperationItem> GetIdOperations(string requestTrackId)
        {
            List<OperationItem> currentTrackIdOperations;
            lock (syncRoot)
            {
                currentTrackIdOperations = JournalSingleton.operationsByTrackId[requestTrackId];

                if (JournalSingleton.operationsByTrackId.ContainsKey(requestTrackId) == false)
                    currentTrackIdOperations = new List<OperationItem>();
                else
                    currentTrackIdOperations = JournalSingleton.operationsByTrackId[requestTrackId].Select(x => x).ToList<OperationItem>();
            }

            return currentTrackIdOperations;
        }
    }
}
