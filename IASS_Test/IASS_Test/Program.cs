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
        static List<MonitoredCondition> MCList;
        static List<Request> requestList; 

        static void Main(string[] args)
        {

			Console.WriteLine("This is IASS version 1.0");
            //@@@@@Debug message:
            //Console.WriteLine("This is program.cs: enter the IASS program.");

            //#####Use hint:
            Console.WriteLine("This is IASS version 1.0");

            
            /*
             * Allocate memory for global structures and queues:
             * Monitored object dictionary, Monitored condition list,
             * notification information, next update time table, and request process queue.
             */

            //@@@@@Debug message:
            //Console.WriteLine("This is program.cs: start allocate data structures.");            
            //#####Use hint:
            Console.WriteLine("Start setting......");
            
            Dictionary<string, MonitoredObject> MODictionary; //<MOID, MonitoredObject class>
            List<Notification> notificationList;//<Notificaiton class>
            List<KeyValuePair<string, int>> timerTable; //<MOID, timestamp of next update time>
            requestList = new List<Request>();
            MCList= new List<MonitoredCondition>(); //<MonitoredCondtion class> 
            requestProcessQueue =new Queue<Request>();

            //@@@@@Debug message:
            //Console.WriteLine("This is program.cs: data allocation finished.");


            /*
             * Error Handling:
             * if memory allocation fails.
             */

            //#####Use hint:
            Console.WriteLine("allocate memory complete.");

            //@@@@@Debug message:
            //Console.WriteLine("This is program.cs: check whether IASS has previous records.");

            //Check log files to see whether it is the first time to set up IASS.
            if (!File.Exists(IASSLogPath))
            {
                //no log means IASS has not previous records

                //@@@@@Debug message:
                //Console.WriteLine("This is program.cs: there is no previous IASS records.");

                //#####Use hint:
                Console.WriteLine("No previous  records are found, start a new IASS");
            }
            else
            {
                //IASS has previous records

                //@@@@@Debug message:
                //Console.WriteLine("This is program.cs: load previosu records.");
                
                //for each data structure, load previous records: Request, MonitoredObject, MonitoredCondition,Notificaiton

                /*
                 * Error Handling:
                 * if record files cannot be found.
                 */
                //#####Use hint:
                Console.WriteLine("Records loading complete.");
            }

            //@@@@@Debug message:
            //Console.WriteLine("This is program.cs: create event wait handles for thread communication.");

            //create event wait handlers for thread communication
            EventWaitHandle[] _doneSignal = new EventWaitHandle[3];
            for (var numberOfWaitHandle = 0; numberOfWaitHandle < 3; numberOfWaitHandle++)
            {
                _doneSignal[numberOfWaitHandle] = new EventWaitHandle(false, EventResetMode.AutoReset);
            }
            EventWaitHandle waitProcessRequest = new EventWaitHandle(false, EventResetMode.AutoReset);
            
            //@@@@@Debug message:
            //Console.WriteLine("This is program.cs: finish creating event wait handles.");

            //@@@@@Debug message:
            //Console.WriteLine("This is program.cs: start threading.");

            //@@@@@Debug message:
            //Console.WriteLine("This is program.cs: start requestListener thread.");
            
            RequestListener requestListener = new RequestListener(_doneSignal[0], waitProcessRequest);
            requestListenerThread = new Thread(new ThreadStart(requestListener.MainMethod));
            requestListenerThread.Start();


            //@@@@@Debug message:
            //Console.WriteLine("This is program.cs: start requestHandler thread.");
            RequestHandler requestHandler = new RequestHandler(_doneSignal[1], waitProcessRequest);
            requestHandlerThread = new Thread(new ThreadStart(requestHandler.MainMethod));
            requestHandlerThread.Start();

            //@@@@@Debug message:
            //Console.WriteLine("This is program.cs: start Scheduler thread.");
            Scheduler scheduler = new Scheduler(_doneSignal[2]);
            schedulerThread = new Thread(new ThreadStart(scheduler.MainMethod));
            schedulerThread.Start();

            //** ThreadPool need not to be declared.
            //@@@@@Debug message:
            //Console.WriteLine("This is program.cs: use system thread pool.");


            //@@@@@Debug message:
            //Console.WriteLine("This is program.cs: wait for all initialization done.");   
            //block and wait for all initialization done
            WaitHandle.WaitAll(_doneSignal);

            //@@@@@Debug message:
            //Console.WriteLine("This is program.cs: all finish signal received.");

            //@@@@@Debug message:
            //Console.WriteLine("This is program.cs: reset all signals.");
            for (var numberOfWaitHandle = 0; numberOfWaitHandle < 3; numberOfWaitHandle++)
            {

                _doneSignal[numberOfWaitHandle].Reset();
            }

            Thread.Sleep(500);
            //#####Use hint:
            Console.WriteLine("Setting complete.");

            for (var numberOfWaitHandle = 0; numberOfWaitHandle < 3; numberOfWaitHandle++)
            {

                _doneSignal[numberOfWaitHandle].Set();
            }



           /* 
            //while the program is not terminated
            while (!isProgramExit)
            {
                //DO something.

            }
            */

            //If the prrgram is going to exit
            //wait other threads terminate
            requestListenerThread.Join();

            requestHandlerThread.Join();
            schedulerThread.Join();

            //Block the system
            Console.ReadLine();
        }
        public static void AddToMCList(MonitoredCondition newMonitoredCondition){
            MCList.Add(newMonitoredCondition);

            //@@@@@Debug message:
            //foreach(var mc in MCList){
                //Console.WriteLine("This is program.cs: mc: {0} ",mc.GetMCID());   
            //}

        }
        public static void AddToRequestList(Request newRequest)
        {
            requestList.Add(newRequest);

            //@@@@@Debug message:
            foreach(var request in requestList){
                Console.WriteLine("This is program.cs: request: {0} ",request.GetRequestUID());   
            }

        }
    }
}
