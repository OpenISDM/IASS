using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace IASS_Test
{
    class Scheduler
    {
        EventWaitHandle doneSignal;
        EventWaitHandle updateTimerTable;

        DateTime currentTime;
        int currentTimeInSecond = 0;
        int nextWakeUpTimeInSecond = 0;
        int sleepTimeInSecond = 100;

        public Scheduler(EventWaitHandle doneSignal, EventWaitHandle updateTimerTable)
        {
            //@@@@@Debug message:
            //Console.WriteLine("This is Scheduler.cs: request handler is constructed.");

            this.doneSignal = doneSignal;
            this.updateTimerTable = updateTimerTable;
        }

        //main mehtod of this class (for threading)
        public void MainMethod()
        {

            //@@@@@Debug message:
            //Console.WriteLine("This is Scheduler.cs: scheduler thread started.");

            //@@@@@Debug message:
            //Console.WriteLine("This is Scheduler.cs: start initialization.");
            //initilization
            // when initialization finished, set doneEvent
            //@@@@@Debug message:
            //Console.WriteLine("This is Scheduler.cs: set doneEvent[2] to say initialization finished.");

            doneSignal.Set();
            Thread.Sleep(1000);
            doneSignal.WaitOne();


                        
            

            //while the program is not terminated
            while (!Program.isProgramExit)
            {
                //@@@@@Debug message:
                //Console.WriteLine("This is scheduler.cs: while the program is not terminated.");
                updateTimerTable.WaitOne(sleepTimeInSecond * 1000);
/*
                // Read next update time table, and compute the next wake up time.
                currentTime = DateTime.Now;
                currentTimeInSecond = transformToTimeStamp(currentTime);

                nextWakeUpTimeInSecond = ReadTimerTable();

                //the thread sleep until time expired.
                sleepTimeInSecond = currentTimeInSecond - nextWakeUpTimeInSecond;

                //if the time expired
                if (sleepTimeInSecond <= 0)
                {
                    //ThreadPool.QueueUserWorkItem;
                }
                else // if the time is not expired
                {
                    //sleep until time expired
                    //** the input of thread sleep is micro second
                    Thread.Sleep(sleepTimeInSecond*1000);
                }

                //the thread is awake
                //check whether current time matches 
                currentTime = DateTime.Now;
                currentTimeInSecond = transformToTimeStamp(currentTime);
                if (currentTimeInSecond < nextWakeUpTimeInSecond)
                {
                    //the thread was waked by interrupt, just continue to compute new wake up time
                    continue;
                }
                else
                {
                    //the thread si awake because time expired.
                    //Add update task in ThreadPool's queue
                    //ThreadPool.QueueUserWorkItem;
                    //Schedule the next update time for Just updated monitored objects
                    //Update timer table and sort by next update time.
                }

*/
            }

            //@@@@@Debug message:
            //Console.WriteLine("This is scheduler.cs: scheduler thread terminated.");
        }
        public int ReadTimerTable()
        {
            int closestUpdateTimeInSecond = 0;
            //get the closest next update time from timer table
            return closestUpdateTimeInSecond;
        }
        public int transformToTimeStamp(DateTime TimeInDateTimeFormat)
        {
            //transform time (DateTime format) to time stamp (int)
            int TimeInSecond = 0;
            return TimeInSecond;
        }
    }
}
