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
using IASS.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace IASS
{
    public delegate void Del();
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, MonitoredObject> MODictionary = new Dictionary<string, MonitoredObject>();

            Del handler1 = new Del(GetCurrentValue1);
            Del handler2 = new Del(GetCurrentValue2);
            Del handler3 = new Del(GetCurrentValue3);
            Del handler4 = new Del(GetCurrentValue4);
            Del handler5 = new Del(GetCurrentValue5);

            MonitoredObject MO1 = new MonitoredObject(null, 1638777864,5663215654,3223402342,30000000,30000, handler1);
            MonitoredObject MO2 = new MonitoredObject(null, 1638777864,5663215654,3223402342,30000000,30000, handler2);
            MonitoredObject MO3 = new MonitoredObject(null, 1638777864,5663215654,3223402342,30000000,30000, handler3);
            MonitoredObject MO4 = new MonitoredObject(null, 1638777864,5663215654,3223402342,30000000,30000, handler4);
            MonitoredObject MO5 = new MonitoredObject(null, 1638777864,5663215654,3223402342,30000000,30000, handler5);


            MODictionary.Add("MO1", MO1);
            MODictionary.Add("MO2", MO2);
            MODictionary.Add("MO3", MO3);
            MODictionary.Add("MO4", MO4);
            MODictionary.Add("MO5", MO5);

            foreach (var mo in MODictionary ) {
                Console.WriteLine("Key = {0}, Value ={1}", mo.Key, mo.Value);
                mo.Value.AccessPath.DynamicInvoke();
            }
        }

        private static void GetCurrentValue1()
        {
            string url = "http://data.taipei.gov.tw/opendata/apply/query/NTQzRjZFREItQzRENC00NkU4LUFGMkUtMkZFRjcxRTNEMzMz?$format=json";
            WebClient client = new WebClient ();

            var x = client.DownloadString (url);

            JArray y = (JArray) JsonConvert.DeserializeObject (x);

            //Console.WriteLine(y);

            var item = y.First;
            var itemProperties = item.Children<JProperty>();

            //you could do a foreach or a linq here depending on what you need to do exactly with the value
            var myElement = itemProperties.FirstOrDefault(k => k.Name == "TP");
            var myElementValue = myElement.Value;            
            Console.WriteLine(myElementValue);
            Console.WriteLine();
        }

        private static void GetCurrentValue2()
        {
            string url = "http://data.taipei.gov.tw/opendata/apply/query/OTgyQjVGQzgtNUU5MS00MzA1LUFGM0ItMkUwOTZBQTE4Q0Ux?$format=json";
            WebClient client = new WebClient ();

            var x = client.DownloadString (url);

            JArray y = (JArray) JsonConvert.DeserializeObject (x);

            //Console.WriteLine(y);

            var item = y.First;
            var itemProperties = item.Children<JProperty>();

            //you could do a foreach or a linq here depending on what you need to do exactly with the value
            var myElement = itemProperties.FirstOrDefault(k => k.Name == "village");
            var myElementValue = myElement.Value;

            Console.WriteLine(myElementValue);

        }

        private static void GetCurrentValue3()
        {
            string url = "http://m.coa.gov.tw/OpenData/DebrisAlertService/GetDebrisVillInfo.aspx";
            WebClient client = new WebClient ();

            var x = client.DownloadString (url);

            JArray y = (JArray) JsonConvert.DeserializeObject (x);

            //Console.WriteLine(y);

            var item = y.First;
            var itemProperties = item.Children<JProperty>();

            //you could do a foreach or a linq here depending on what you need to do exactly with the value
            var myElement = itemProperties.FirstOrDefault(k => k.Name == "AlertValue");
            var myElementValue = myElement.Value;
            Console.WriteLine(myElementValue);
        }

        private static void GetCurrentValue4()
        {
            string url = "http://opendata.epa.gov.tw/ws/Data/RainTenMin/?format=json";
            WebClient client = new WebClient ();

            var x = client.DownloadString (url);

            JArray y = (JArray) JsonConvert.DeserializeObject (x);

            //Console.WriteLine(y);

            var item = y.First;
            var itemProperties = item.Children<JProperty>();

            //you could do a foreach or a linq here depending on what you need to do exactly with the value
            var myElement = itemProperties.FirstOrDefault(k => k.Name == "TWD67Lon");
            var myElementValue = myElement.Value;
            Console.WriteLine(myElementValue);
        }

        private static void GetCurrentValue5()
        {
            string url = "http://data.coa.gov.tw/Service/OpenData/DataFileService.aspx?UnitId=061";
            WebClient client = new WebClient ();

            var x = client.DownloadString (url);

            JArray y = (JArray) JsonConvert.DeserializeObject (x);

            //Console.WriteLine(y);

            var item = y.First;
            var itemProperties = item.Children<JProperty>();

            //you could do a foreach or a linq here depending on what you need to do exactly with the value
            var myElement = itemProperties.FirstOrDefault(k => k.Name == "town");
            var myElementValue = myElement.Value;
            Console.WriteLine(myElementValue);
        }
    }
}
