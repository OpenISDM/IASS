﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace IASS_Test
{
    class Scheduler
    {
        EventWaitHandle _doneSignal;
        EventWaitHandle _waitProcessRequest;
        DateTime _currentTime;
        int _currentTimeInSecond = 0;
        int _nextWakeUpTimeInSecond = 0;
        int _sleepTimeInSecond = 0;

        public Scheduler(EventWaitHandle doneSignal)
        {
            this._doneSignal = doneSignal;
        }

        //main mehtod of this class (for threading)
        public void MainMethod()
        {
                        
            //while the program is not terminated
            while (!Program.isProgramExit)
            {
                // Read next update time table, and compute the next wake up time.
                _currentTime = DateTime.Now;
                _currentTimeInSecond = transformToTimeStamp(_currentTime);

                _nextWakeUpTimeInSecond = ReadTimerTable();

                //the thread sleep until time expired.
                _sleepTimeInSecond = _currentTimeInSecond - _nextWakeUpTimeInSecond;

                //if the time expired
                if (_sleepTimeInSecond <= 0)
                {
                    //ThreadPool.QueueUserWorkItem;
                }
                else // if the time is not expired
                {
                    //sleep until time expired
                    //** the input of thread sleep is micro second
                    Thread.Sleep(_sleepTimeInSecond*1000);
                }

                //the thread is awake
                //check whether current time matches 
                _currentTime = DateTime.Now;
                _currentTimeInSecond = transformToTimeStamp(_currentTime);
                if (_currentTimeInSecond < _nextWakeUpTimeInSecond)
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

            }
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