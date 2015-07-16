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
            this._doneSignal = doneSignal;
            this._waitProcessRequest = waitProcessRequest;
        }

        //main mehtod of this class (for threading)
        public void MainMethod()
        {
            Request newRequest = null;
            Object thisLock = new Object();
            
            //while the program is not terminated
            while (!Program.isProgramExit)
            {
                //wait for new reuqest
                newRequest = waitForNewRequest();
                //add new request to request process queue
                lock(thisLock){
                    AddNewJobToQueue(newRequest);
                }
                

                if (Program.requestHandlerThread.ThreadState != ThreadState.Running)
                {
                    //wake up requestHandler to process new request
                    _waitProcessRequest.Set();
                }
                else
                {
                    //do nothing and keep wait the next one.
                }
            }
        }
        public Request waitForNewRequest()
        {
            Request newRequest = null;
            //wait for new request
            return newRequest;
        }
        public void AddNewJobToQueue(Request newRequest)
        {
            //add new request to request process queue
            Program.requestProcessQueue.Enqueue(newRequest);
        }
    }
}
