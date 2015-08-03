

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IASS_Test
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

		private string GetRequestID ()
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

