﻿/* 
Copyright (c) 2015  OpenISDM
    
Project Name: 
    
    IASS(Intelligent Active Storage Service)
 
Abstract:
 

 
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
using IASS.Collections;

namespace IASS
{
    class Program
    {
        static void Main(string[] args)
        {
            string requestID = "kevin God";
            string monitoredConditionExpression = "waterLevel > 100";
            bool modifyByOthers = true;
            bool viewByOthers = true;

            Request newRequest = new Request(requestID, monitoredConditionExpression, modifyByOthers, viewByOthers);

            newRequest.GetRequestID();

        }
    }
}
