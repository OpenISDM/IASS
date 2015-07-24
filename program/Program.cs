using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace IASS_Test
{
    class Program
    {
        public static string IASSLogPath = "IASS.log";
        public static bool isProgramExit = false;

        public static Queue<Request> requestProcessQueue;
        public static Thread requestListenerThread;
        public static Thread requestHandlerThread;
        public static Thread schedulerThread;
 
 

        static void Main(string[] args)
        {
            /*
             * Allocate memory for global structures and queues:
             * Monitored object dictionary, Monitored condition list,
             * notification information, next update time table, and request process queue.
             */
            Dictionary<string, MonitoredObject> MODictionary; //<MOID, MonitoredObject class>
            List<MonitoredCondition> MCList; //<MonitoredCondtion class>
            List<Notification> notificationList;//<Notificaiton class>
            List<KeyValuePair<string, int>> timerTable; //<MOID, timestamp of next update time>
            List<Request> requestList;

            /*
             * Error Handling:
             * if memory allocation fails.
             */

            //Check log files to see whether it is the first time to set up IASS.
            if (!File.Exists(IASSLogPath))
            {
                //no log means IASS has not previous records
            }
            else
            {
                //IASS has previous records
                //for each data structure, load previous records: Request, MonitoredObject, MonitoredCondition,Notificaiton

                /*
                 * Error Handling:
                 * if record files cannot be found.
                 */

            }

            //create event wait handlers for thread communication
            EventWaitHandle[] _doneEvent = new EventWaitHandle[3];
            for (var numberOfWaitHandle = 0; numberOfWaitHandle < 3; numberOfWaitHandle++)
            {
                _doneEvent[numberOfWaitHandle] = new EventWaitHandle(false, EventResetMode.AutoReset);
            }
            EventWaitHandle waitProcessRequest = new EventWaitHandle(false, EventResetMode.AutoReset);


            RequestListener requestListener = new RequestListener(_doneEvent[0], waitProcessRequest);
            requestListenerThread = new Thread(new ThreadStart(requestListener.MainMethod));


            RequestHandler requestHandler = new RequestHandler(_doneEvent[1], waitProcessRequest);
            requestHandlerThread = new Thread(new ThreadStart(requestHandler.MainMethod));

            Scheduler scheduler = new Scheduler(_doneEvent[2]);
            schedulerThread = new Thread(new ThreadStart(scheduler.MainMethod));

            //** ThreadPool need not to be declared.
            
            
            //block and wait for all initialization done
            WaitHandle.WaitAll(_doneEvent);

            
            
            //while the program is not terminated
            while (!isProgramExit)
            {
                //DO something.
            }


            //If the program is going to exit
            //wait other threads terminate
            requestListenerThread.Join();
            requestHandlerThread.Join();
            schedulerThread.Join();

        }
    }
}
