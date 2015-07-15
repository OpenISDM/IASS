

using System;
using System.Collections.Generic;


namespace x3
{
	public class MonitoredObject
	{

		private int _currentValue;
		private int _validTime;
		private int _lastUpdateTime;
		private int _nextUpdateTime;
		private int _updateTimeInterval;
		private int _ShortestResponseTime;
		private int _monitoredObjectID;

		List<MonitoredCondition> _monitoredConditions = new List<MonitoredCondition>();


		public int AccessPath()
		{
			//run script/function to get value
			//script/function will return currentValue, validTime, and lastUpdateTime 

//			_currentValue = updatedValue;
//			_validTime = validTime;
//			_lastUpdateTime = lastUpdateTime;
//			_nextUpdateTime = lastUpdateTime + _updateTimeInterval;

			return _currentValue;
		}

		//check all update all monitor condition result in _monitorConditions list 
		public void UpdateMonitoredCondition(){
			for (int i = 0; i < _monitoredConditions.Count; i++) {
//				_monitoredConditions [i].CheckMonitoredExpression(_monitoredObjectID, _currentValue);
			}
		}


	}

}



