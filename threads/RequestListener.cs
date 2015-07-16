using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace IASS_Test
{
    class RequestListener
    {   
        EventWaitHandle _doneSignal;
        EventWaitHandle _waitProcessRequest;

        public RequestListener(EventWaitHandle doneSignal, EventWaitHandle waitProcessRequest)
        {
            //@@@@@Debug message:
            //Console.WriteLine("This is requestListener.cs: request listener is constructed.");
   
            this._doneSignal = doneSignal;
            this._waitProcessRequest = waitProcessRequest;
        }

        //main mehtod of this class (for threading)
        public void MainMethod()
        {
            Request newRequest = null;
            Object thisLock = new Object();

            //@@@@@Debug message:
            //Console.WriteLine("This is requestListener.cs: requestListener thread started.");

            //@@@@@Debug message:
            //Console.WriteLine("This is requestListener.cs: start initialization.");
            //initilization
            // when initialization finished, set doneEvent
            //@@@@@Debug message:
            //Console.WriteLine("This is requestListener.cs: set doneEvent[0] to say initialization finished.");

            _doneSignal.Set();
            Thread.Sleep(1000);

            _doneSignal.WaitOne();
         
            //while the program is not terminated
            while (!Program.isProgramExit)
            {
                //@@@@@Debug message:
                //Console.WriteLine("This is requestListener.cs: while the program is not terminated.");

                //wait for new reuqest
                newRequest = WaitForNewRequest();

                //@@@@@Debug message:
                //Console.WriteLine("This is requestListener.cs: \n"+
                //                  "requestID ={0}\n"+
                //                  "request MCstring ={1}",newRequest.GetRequestUID(),newRequest.GetMCstring());


                //add new request to request process queue
                lock(thisLock){
                    AddNewJobToQueue(newRequest);
                }

                //@@@@@Debug message:
                //Console.WriteLine("This is requestListener.cs: a new request aded in queue");
                //foreach (var queueItem in Program.requestProcessQueue)
                //{
                    //@@@@@Debug message:
                    //Console.WriteLine("This is requestListener.cs: queue item: {0}",queueItem.GetRequestUID());
                //}

                if (Program.requestHandlerThread.ThreadState != ThreadState.Running)
                {
                    //@@@@@Debug message:
                    Console.WriteLine("This is requestListener.cs: handler is sleeping, I want to wake it up");                    
                    //wake up requestHandler to process new request
                    _waitProcessRequest.Set();
                }
                else
                {
                    //@@@@@Debug message:
                    Console.WriteLine("This is requestListener.cs: handler is running");       
                    //do nothing and keep wait the next one.
                }
            }

            //@@@@@Debug message:
            //Console.WriteLine("This is requestListener.cs: requestListener thread terminated.");
        }
        public Request WaitForNewRequest()
        {
            //@@@@@Debug message:
            //Console.WriteLine("This is requestListener.cs,waitForNewRequest method: Pleast input request\n");
            //#####Use hint:
            Console.WriteLine("waiting for request input:");

            Request newRequest = null;

            //wait for new request
            //version 1 :7/16, use readline to make assumed input
            string tempNewRequest;
            tempNewRequest = Console.ReadLine();

            //@@@@@Debug message:
            //Console.WriteLine("This is requestListener.cs,waitForNewRequest method :{0}",tempNewRequest);
            //#####Use hint:
            Console.WriteLine("received request:{0}", tempNewRequest);

            //version 1 :7/16, Sample rerquest
            newRequest = new Request(tempNewRequest, "", false, false);

            return newRequest;
        }
        public void AddNewJobToQueue(Request newRequest)
        {
            //add new request to request process queue
            Program.requestProcessQueue.Enqueue(newRequest);
        }
    }
}
