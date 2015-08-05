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
        private List<MonitoredCondition> monitoredConditions = new List<MonitoredCondition>();

        //class constructor
        public MonitoredObject(string monitoredObjectID)
        {
            this.monitoredObjectID = monitoredObjectID;

        }

        /*
        Routine Name:
            MOID(MonitoredObjectID)

        Routine Description:
            This function allows the caller to Get and Set values.
            We implement it using C# feature - Properties

        Arguments:
            None.

        Return Value:
            The function returns monitor object ID.
        */
        public string MOID
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
            CV(currentValue)

        Routine Description:
            This function allows the caller to Get and Set values.
            We implement it using C# feature - Properties

        Arguments:
            None.

        Return Value:
            The function returns current value of monitored object.
        */
        public string CV
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
            LUT(lastUpdateTime)

        Routine Description:
            This function allows the caller to Get and Set values.
            We implement it using C# feature - Properties

        Arguments:
            None.

        Return Value:
            The function returns last update time of monitored object.
        */
        public ulong LUT
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
            NUT(nextUpdateTime)

        Routine Description:
            This function allows the caller to Get and Set values.
            We implement it using C# feature - Properties

        Arguments:
            None.

        Return Value:
            The function returns next update time of monitored object.
        */
        public ulong NUT
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
            UTI(updateTimeInterval)

        Routine Description:
            This function allows the caller to Get and Set values.
            We implement it using C# feature - Properties

        Arguments:
            None.

        Return Value:
            The function returns update time interval of monitored object.
        */
        public ulong UTI
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
            SRT(shortestResponseTime)

        Routine Description:
            This function allows the caller to Get and Set values.
            We implement it using C# feature - Properties

        Arguments:
            None.

        Return Value:
            The function returns shortest response time of monitored object.
        */
        public ulong SRT
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
            AddMonitoredCondition(newMonitoredCondition)

        Routine Description:
            This function adds a new MonitoredCondition object to the MonitoredObject's monitoredCondition list.

        Arguments:
            MonitoredCondition newMonitoredCondition

        Return Value:
            None.
        */
        private void AddMonitoredCondition(MonitoredCondition newMonitoredCondition)
        {
            monitoredConditions.Add(newMonitoredCondition);
        }

        /*
        Routine Name:
            AddMonitoredCondition(newMonitoredCondition)

        Routine Description:
            This function adds a new MonitoredCondition object to the MonitoredObject's monitoredCondition list.

        Arguments:
            MonitoredCondition newMonitoredCondition

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
            for ( int i = 0; i < monitoredConditions.Count; i++ ) {
                monitoredConditions[i].EvaluateExpression();
            }
        }


    }

}


