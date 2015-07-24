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
        EventWaitHandle doneSignal;
        EventWaitHandle waitProcessRequest;

        public RequestHandler(EventWaitHandle doneSignal, EventWaitHandle waitProcessRequest)
        {
            //@@@@@Debug message:
            //Console.WriteLine("This is requestHandler.cs: request handler is constructed.");

            this.doneSignal = doneSignal;
            this.waitProcessRequest = waitProcessRequest;
        }

        //main mehtod of this class (for threading)
        public void MainMethod()
        {
            Request currentRequest = null;
            MonitoredCondition processedMonitoredCondtion = null;
            string pointerToMC = "";

            //@@@@@Debug message:
            //Console.WriteLine("This is requestHandler.cs: requestListener thread started.");

            //@@@@@Debug message:
            //Console.WriteLine("This is requestHandler.cs: start initialization.");
            //initilization
            // when initialization finished, set doneEvent
            //@@@@@Debug message:
            //Console.WriteLine("This is requestHandler.cs: set doneEvent[1] to say initialization finished.");

            doneSignal.Set();
            Thread.Sleep(1000);
            doneSignal.WaitOne();

            

            //while the program is not terminated
            while (!Program.isProgramExit)
            {
                //@@@@@Debug message:
                //Console.WriteLine("This is requestHandler.cs: while the program is not terminated.");

                //if the requestProcessQueue is empty, the thread sleeps
                if (Program.requestProcessQueue.Count == 0)
                {
                    //use event wait handle to 
                    //@@@@@Debug message:
                    //Console.WriteLine("This is requestHandler.cs: block, because the queue is empty");
                    waitProcessRequest.WaitOne();
                }
                else
                {
                    //process requests until the queue become empty
                    while (Program.requestProcessQueue.Count != 0)
                    {
                        //get the first item from request process queue
                        currentRequest = GetRequestFromQueue();
                        //Parse the MC from the request

                        processedMonitoredCondtion = ParseMC(currentRequest.GetMCstring());
                        //@@@@@Debug message:
                        Console.WriteLine("***This is requestHandler.cs: reqest {0} is parsed", currentRequest.GetRequestUID());


                        //Add processed monitored condition to MCList
                        //check if the MC has already existed: if it is,return pointer of MC; if it is not, add to MCList and return tha pointer of MC
                        pointerToMC = AddToMCList(processedMonitoredCondtion);
                        //@@@@@Debug message:
                        Console.WriteLine("***This is requestHandler.cs: the MC is {0}", pointerToMC);
                        //update the request with MC pointer
                        //Add request to request list.

                        AddToRequestList(pointerToMC, currentRequest);

                        pointerToMC = AddToMCList(processedMonitoredCondtion);

/*
                        //schedule next update time for used monitored objects
                        //update timer table, and sort timer table by next update time
                        updateTimerTable(processedMonitoredCondtion);
*/                      

                    }
                }

            }
            //@@@@@Debug message:
            //Console.WriteLine("This is requestHandler.cs: requestHandler thread terminated.");
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
            
            //7/16 version1: stop processing time, to check queue
            timeStop(5000.00);
            //7/16 version1: sample monitoredCondition
            processedMonitoredCondtion = new MonitoredCondition(null,null);
            processedMonitoredCondtion.SetMCID(MCstring+"__");

            //devide MC string to List of MEs
            //verify MEs
            //if verification success return a processedMonitoredCondition, else returns null;
            return processedMonitoredCondtion;
        }
        public string AddToMCList(MonitoredCondition processedMonitoredCondtion)
        {
            Program.AddToMCList(processedMonitoredCondtion);
            return processedMonitoredCondtion.GetMCID();
        }
        public void AddToRequestList(string pointerToMC, Request acceptedRequest)
        {
            //update the request with the pointer of MC, add the request to request list
            Program.AddToRequestList(acceptedRequest);
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
        //7/16 version 1: test code
        public void timeStop(double pauseTime){
            DateTime timeStart = DateTime.Now;
            DateTime timeEnd = DateTime.Now;
            double timeDiff = ((TimeSpan)(timeEnd - timeStart)).TotalMilliseconds;

            while(timeDiff < pauseTime) {
                timeEnd = DateTime.Now;
                timeDiff = ((TimeSpan)(timeEnd - timeStart)).TotalMilliseconds;
            }

        }
    }
}
