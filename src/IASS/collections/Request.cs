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


		//class constructor 
        public Request(string requestID, string monitoredConditionExpression, bool modifyByOthers, bool viewByOthers)
        {
            this.requestID = requestID;
            this.monitoredConditionExpression = monitoredConditionExpression;
            this.modifyByOthers = modifyByOthers;
            this.viewByOthers = viewByOthers;
        }

        /*
         Routine Name:
             RID(requestID)

         Routine Description:
             This function allows the caller to Get and Set values.
             We implement it using C# feature - Properties

         Arguments:
             None.

         Return Value:
             The function returns request ID.
         */
        public string RID
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
            MBO(modifyByOthers)

        Routine Description:
            This function allows the caller to Get and Set values.
            We implement it using C# feature - Properties

        Arguments:
            None.

        Return Value:
            The function returns flag of modifyByOthers.
        */
        public bool MBO
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
            VBO(viewByOthers)

        Routine Description:
            This function allows the caller to Get and Set values.
            We implement it using C# feature - Properties

        Arguments:
            None.

        Return Value:
            The function returns flag of viewByOthers.
        */
        public bool VBO
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

