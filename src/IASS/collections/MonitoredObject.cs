/* 
Copyright (c) 2015  OpenISDM
    
Project Name: 
    
    IASS(Intelligent Active Storage Service)

File Name:

    MonitoredObject.cs
 
Abstract:
	
	This file contains the MonitoredObject class which is one of the main data structure of IASS that stores the information of the data we are monitoring.
 
Authors:  

    Li-Kai, Chi, kevinjipotw@gmail.com
    Johnson Su, johnsonsu@iis.sinica.edu.tw
 
License:
 
    GPL 3.0 This file is subject to the terms and conditions defined 
    in file 'COPYING.txt', which is part of this source code package.
 
Major Revision History:
 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IASS.Collections
{
    public class MonitoredObject
    {
        private string monitoredObjectID;
        private string currentValue;
        private ulong validTime;
        private ulong lastUpdateTime;
        private ulong nextUpdateTime;
        private ulong updateTimeInterval;
        private ulong shortestResponseTime;
        private List<MonitoredCondition> monitoredConditions;

        /*
        Routine Name:
            Constructor

        Routine Description:
            This function allows the caller to init attributes 
            of Monitored object.

        Arguments:
            MonitoredObjectID - 
            CurrentValue -
            ValidTime -
            LastUpdateTime -
            NextUpdateTime -
            UpdateTimeInterval -
            ShortestResponseTime -

        Return Value:
            None.
        */
        public MonitoredObject(
            string MonitoredObjectID,
            string CurrentValue,
            ulong ValidTime,
            ulong LastUpdateTime,
            ulong NextUpdateTime,
            ulong UpdateTimeInterval,
            ulong ShortestResponseTime
            )
        {
            this.monitoredObjectID = MonitoredObjectID;
            this.currentValue = CurrentValue;
            this.validTime = ValidTime;
            this.lastUpdateTime = LastUpdateTime;
            this.nextUpdateTime = NextUpdateTime;
            this.updateTimeInterval = UpdateTimeInterval;
            this.shortestResponseTime = ShortestResponseTime;
            this.monitoredConditions = new List<MonitoredCondition>();
        }

        /*
        Routine Name:
            ID

        Routine Description:
            This function allows the caller to Get and Set values.
            We implement it using C# feature - Properties

        Arguments:
            None.

        Return Value:
            The function returns monitor object ID.
        */
        public string ID
        {
            get
            {
                return monitoredObjectID;
            }
            set
            {
                monitoredObjectID = value;
            }

        }

        /*
        Routine Name:
            CurrentValue

        Routine Description:
            This function allows the caller to Get and Set values.
            We implement it using C# feature - Properties

        Arguments:
            None.

        Return Value:
            The function returns current value of monitored object.
        */
        public string CurrentValue
        {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = value;
            }

        }

        /*
        Routine Name:
            VaildTime

        Routine Description:
            This function allows the caller to Get and Set values.
            We implement it using C# feature - Properties

        Arguments:
            None.

        Return Value:
            The function returns last update time of monitored object.
        */
        public ulong ValidTime
        {
            get
            {
                return validTime;
            }
            set
            {
                validTime = value;
            }

        }

        /*
        Routine Name:
            LastUpdateTime

        Routine Description:
            This function allows the caller to Get and Set values.
            We implement it using C# feature - Properties

        Arguments:
            None.

        Return Value:
            The function returns last update time of monitored object.
        */
        public ulong LastUpdateTime
        {
            get
            {
                return lastUpdateTime;
            }
            set
            {
                lastUpdateTime = value;
            }

        }

        /*
        Routine Name:
            NextUpdateTime

        Routine Description:
            This function allows the caller to Get and Set values.
            We implement it using C# feature - Properties

        Arguments:
            None.

        Return Value:
            The function returns next update time of monitored object.
        */
        public ulong NextUpdateTime
        {
            get
            {
                return nextUpdateTime;
            }
            set
            {
                nextUpdateTime = value;
            }

        }

        /*
        Routine Name:
            UpdateTimeInterval

        Routine Description:
            This function allows the caller to Get and Set values.
            We implement it using C# feature - Properties

        Arguments:
            None.

        Return Value:
            The function returns update time interval of monitored object.
        */
        public ulong UpdateTimeInterval
        {
            get
            {
                return updateTimeInterval;
            }
            set
            {
                updateTimeInterval = value;
            }

        }


        /*
        Routine Name:
            ShortestResponseTime

        Routine Description:
            This function allows the caller to Get and Set values.
            We implement it using C# feature - Properties

        Arguments:
            None.

        Return Value:
            The function returns shortest response time of monitored object.
        */
        public ulong ShortestResponseTime
        {
            get
            {
                return shortestResponseTime;
            }
            set
            {
                shortestResponseTime = value;
            }

        }

        /*
        Routine Name:
            MonitoredConditions

        Routine Description:
            This function adds a new MonitoredCondition object to the 
            MonitoredObject's monitoredCondition list.

        Arguments:
            MonitoredCondition newMonitoredCondition

        Return Value:
            None.
        */

        public List<MonitoredCondition> MonitoredConditions
        {
            get
            {
                return monitoredConditions;
            }
            set
            {
                monitoredConditions = value;
            }
        }


        /*
        Routine Name:
            AddMonitoredCondition

        Routine Description:
            This function adds a new MonitoredCondition object to the MonitoredObject's monitoredCondition list.

        Arguments:
            MonitoredCondition newMonitoredCondition

        Return Value:
            None.
        */
        public void AddMonitoredCondition(MonitoredCondition newMonitoredCondition)
        {
            this.monitoredConditions.Add(newMonitoredCondition);
        }

        /*
        Routine Name:
            AccessPath

        Routine Description:
           

        Arguments:
            

        Return Value:
            None.
        */
        public string AccessPath()
        {
            //run script/function to get value
            //script/function will return currentValue, validTime, and lastUpdateTime 

            //			currentValue = updatedValue;
            //			validTime = validTime;
            //			lastUpdateTime = lastUpdateTime;
            //			nextUpdateTime = lastUpdateTime + updateTimeInterval;

            return currentValue;
        }

        /*
        Routine Name:
            EvaluateMonitoredConditions()

        Routine Description:
            This function evaluates all the MonitoredConditions that are stored in the monitoredCondition list.

        Arguments:
            None.

        Return Value:
            None.
        */
        public void EvaluateMonitoredConditions()
        {
            foreach ( var count in monitoredConditions ) {
                count.EvaluateExpression();
            }
        }


    }

}


