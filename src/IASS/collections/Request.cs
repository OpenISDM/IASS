/* 
Copyright (c) 2015  OpenISDM
    
Project Name: 
    
    IASS(Intelligent Active Storage Service)

File Name:

    Request.cs
 
Abstract:
 
	The Request class stores the requests that apps asks from IASS.
 
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

    class Request
    {
        private string requestID;
        private string monitoredConditionExpression;
        private bool modifyByOthers;
        private bool viewByOthers;

        /*
        Routine Name:
            Constructor

        Routine Description:
            This function allows the caller to init attributes 
            of notification object.

        Arguments:
            RequestID - 
            MonitoredConditionExpression -
            ModifyByOthers -
            ViewByOthers -

        Return Value:
            None.
        */
        public Request(
            string requestID,
            string expression,
            bool modifyByOthers,
            bool viewByOthers
            )
        {
            this.requestID = requestID;
            this.monitoredConditionExpression = expression;
            this.modifyByOthers = modifyByOthers;
            this.viewByOthers = viewByOthers;
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
             The function returns request ID.
         */
        public string ID
        {
            get
            {
                return requestID;
            }
            set
            {
                requestID = value;
            }

        }

        /*
        Routine Name:
            MonitoredConditionExpression

        Routine Description:
            This function allows the caller to Get and Set values.
            We implement it using C# feature - Properties

        Arguments:
            None.

        Return Value:
            The function returns an expression of monitored condition 
            form MonitoredCondition object.
        */
        public string MonitoredConditionExpression
        {
            get
            {
                return monitoredConditionExpression;
            }
            set
            {
                monitoredConditionExpression = value;
            }

        }

        /*
        Routine Name:
            ModifyByOthers

        Routine Description:
            This function allows the caller to Get and Set values.
            We implement it using C# feature - Properties

        Arguments:
            None.

        Return Value:
            The function returns flag of modifyByOthers.
        */
        public bool ModifyByOthers
        {
            get
            {
                return modifyByOthers;
            }
            set
            {
                modifyByOthers = value;
            }

        }

        /*
        Routine Name:
            ViewByOthers

        Routine Description:
            This function allows the caller to Get and Set values.
            We implement it using C# feature - Properties

        Arguments:
            None.

        Return Value:
            The function returns flag of viewByOthers.
        */
        public bool ViewByOthers
        {
            get
            {
                return viewByOthers;
            }
            set
            {
                viewByOthers = value;
            }

        }

    }

}

