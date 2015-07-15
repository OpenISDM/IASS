using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace IASS_Test
{
    class RequestHandler
    {
        EventWaitHandle _doneSignal;
        EventWaitHandle _waitProcessRequest;

        public RequestHandler(EventWaitHandle doneSignal, EventWaitHandle waitProcessRequest)
        {
            this._doneSignal = doneSignal;
            this._waitProcessRequest = waitProcessRequest;
        }

        //main mehtod of this class (for threading)
        public void MainMethod()
        {
            Request _currentRequest = null;
            MonitoredCondition _processedMonitoredCondtion = null;
            string pointerToMC = "";

            //while the program is not terminated
            while (!Program.isProgramExit)
            {
                //if the requestProcessQueue is empty, the thread sleeps
                if (Program.requestProcessQueue.Count == 0)
                {
                    //use event wait handle to 
                    _waitProcessRequest.WaitOne();
                }
                else
                {
                    //process requests until the queue become empty
                    while (Program.requestProcessQueue.Count != 0)
                    {
                        //get the first item from request process queue
                        _currentRequest = GetRequestFromQueue();
                        //Parse the MC from the request
                        _processedMonitoredCondtion = ParseMC(_currentRequest.GetMCstring());

                        //Add processed monitored condition to MCList
                        //check if the MC has already existed: if it is,return pointer of MC; if it is not, add to MCList and return tha pointer of MC
                        pointerToMC = AddToMCList(_processedMonitoredCondtion);
                        //update the request with MC pointer
                        //Add request to request list.
                        AddToRequestList(pointerToMC, _currentRequest);

                        //schedule next update time for used monitored objects
                        //update timer table, and sort timer table by next update time
                        updateTimerTable(_processedMonitoredCondtion);
                        

                    }
                }
            }
        }
        public Request GetRequestFromQueue()
        {
            Request currentRequest = null;
            currentRequest = Program.requestProcessQueue.Dequeue();
            return currentRequest;
        }
        public MonitoredCondition ParseMC(string MCstring)
        {
            MonitoredCondition processedMonitoredCondtion = null;
            //devide MC string to List of MEs
            //verify MEs
            //if verification success return a processedMonitoredCondition, else returns null;
            return processedMonitoredCondtion;
        }
        public string AddToMCList(MonitoredCondition processedMonitoredCondtion)
        {
            return processedMonitoredCondtion.GetMCID();
        }
        public void AddToRequestList(string pointerToMC, Request acceptedRequest)
        {
            //update the request with the pointer of MC, add the request to request list
        }
        public void updateTimerTable(MonitoredCondition processedMonitoredCondtion)
        {
            List<MonitoredObject> usedMonitoredObject = processedMonitoredCondtion.GetMOList();
            foreach (MonitoredObject tempMonitoredObject in usedMonitoredObject)
            {
                //schedule monitored object
                //Add to timer table
            }
        }
    }
}
