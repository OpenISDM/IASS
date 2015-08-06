/* 
Copyright (c) 2015  OpenISDM
    
Project Name: 
    
    IASS(Intelligent Active Storage Service)
 
Abstract:
 
    This file called main program that is start point in IASS.
 
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
            List<MonitoredObject> mOList = new List<MonitoredObject>();

            mOList.Add(new MonitoredObject(
                "f6ed19be8cd3ca7c556b52bdc2393855",
                "7777",
                1438777862,
                5463215654,
                3023402342,
                10000000,
                10000));

            mOList.Add(new MonitoredObject(
                "88b546521ba8e093d990674d56a05441",
                "8888",
                1538777863,
                5563215654,
                3723402342,
                20000000,
                20000));

            mOList.Add(new MonitoredObject(
                "dbc2fd8684799de4f22fa1ad936a9de0", 
                "9999",
                1638777864,
                5663215654,
                3223402342,
                30000000,
                30000));

            List<MonitoredObject> MCMOlist = new List<MonitoredObject>();
            string expression = "test";
            MonitoredCondition newMonitoredCondition = new MonitoredCondition(expression, MCMOlist);
            mOList[0].AddMonitoredCondition(newMonitoredCondition);

            Console.WriteLine();
            foreach ( MonitoredObject mo in mOList ) {
                Console.Write("Your .NET version is {0}",typeof(string).Assembly.ImageRuntimeVersion);
                Console.WriteLine("-------------------------");
                Console.WriteLine("MonitoredObjectID: {0}",mo.ID);
                Console.WriteLine("CurrentValue: {0}", mo.CurrentValue);
                Console.WriteLine("ValidTime: {0}", mo.ValidTime);
                Console.WriteLine("LastUpdateTime: {0}", mo.LastUpdateTime);
                Console.WriteLine("NextUpdateTime: {0}", mo.NextUpdateTime);
                Console.WriteLine("ShortestResponseTime: {0}", mo.ShortestResponseTime);
                Console.WriteLine("-------------------------");
            }
            Console.ReadKey();
        }
    }
}
