/* 
Copyright (c) 2015  OpenISDM
    
Project Name: 
    
    IASS(Intelligent Active Storage Service)

File Name:

    Request.cs
 
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

namespace IASS.Collections
{

	class Request
	{
		private string requestID;
		private string monitoredConditionExpression;
		private bool modifyByOthers;
		private bool viewByOthers;
		//pointer to corresponding MonitoredCondition
		//		string pointerToMonitoredCondition

		public Request(string requestID, string monitoredConditionExpression, bool modifyByOthers, bool viewByOthers){
			this.requestID = requestID;
			this.monitoredConditionExpression = monitoredConditionExpression;
			this.modifyByOthers = modifyByOthers;
			this.viewByOthers = viewByOthers;
		}

		public string GetRequestID ()
		{
			return this.requestID;
		}

		private void SetModifyByOthers (bool modifyByOthers)
		{
			this.modifyByOthers = modifyByOthers;
		}

		private bool GetModifyByOthers ()
		{
			return this.modifyByOthers;
		}

		private void SetViewByOthers (bool viewByOthers)
		{
			this.viewByOthers = viewByOthers;
		}

		private bool GetViewByOthes ()
		{ 
			return this.viewByOthers;
		}



	}

}

