

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IASS_Test
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

		//gets monitoredObjectID
		private string GetMonitoredObjectID()
		{
			return monitoredObjectID;
		}

		//sets currentValue
		private void SetCurrentValue(string currentValue)
		{
			this.currentValue = currentValue;
		}

		//gets currentValue
		private string GetCurrentValue()
		{
			return this.currentValue;
		}

		//sets lastUpdateTime
		private void SetLastUpdateTime(ulong lastUpdateTime)
		{
			this.lastUpdateTime = lastUpdateTime;
		}

		//gets lastUpdateTime
		private ulong GetLastUpdateTime()
		{
			return this.lastUpdateTime;
		}

		//sets nextUpdateTime
		private void SetNextUpdateTime(ulong nextUpdateTime)
		{
			this.nextUpdateTime = nextUpdateTime;
		}

		//gets nextUpdateTime
		private ulong GetNextUpdateTime()
		{
			return this.nextUpdateTime;
		}

		//sets updateTimeInterval
		private void SetUpdateTimeInterval(ulong updateTimeInterval)
		{
			this.updateTimeInterval = updateTimeInterval;
		}

		//gets updateTimeInterval
		private ulong GetUpdateTimeInterval()
		{
			return this.updateTimeInterval;
		}

		//sets shortestResponseTime
		private void SetShortestResponseTime(ulong shortestResponseTime)
		{
			this.shortestResponseTime = shortestResponseTime;
		}

		//gets shortestResponseTime
		private ulong GetShortestResponseTime()
		{
			return this.shortestResponseTime;
		}

		//adds monitored condition
		private void AddMonitoredCondition(MonitoredCondition newMonitoredCondition)
		{
			monitoredConditions.Add (newMonitoredCondition);
		}
			
		//get the MonitoredObject's current value
		public string AccessPath()
		{
			//run script/function to get value
			//script/function will return currentValue, validTime, and lastUpdateTime 

			//			_currentValue = updatedValue;
			//			_validTime = validTime;
			//			_lastUpdateTime = lastUpdateTime;
			//			_nextUpdateTime = lastUpdateTime + _updateTimeInterval;

			return currentValue;
		}

		//evaluate all monitor conditions monitorConditions list 
		public void EvaluateMonitoredConditions()
		{
			for (int i = 0; i < monitoredConditions.Count; i++)
			{
				monitoredConditions [i].EvaluateExpression();
			}
		}


	}

}


