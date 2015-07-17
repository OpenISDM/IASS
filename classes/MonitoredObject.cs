using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parsing_test
{
    public class MonitoredObject
    {
        public int _currentValue;
		public int _validTime;
		public int _lastUpdateTime;
		public int _nextUpdateTime;
		public int _updateTimeInterval;
		public int _ShortestResponseTime;
		public string _monitoredObjectID;

        List<MonitoredCondition> _monitoredConditions = new List<MonitoredCondition>();

		public MonitoredObject(string monitoredObjectID)
		{
			_monitoredObjectID = monitoredObjectID;
		
		}

		public void SetCurrentValue(int currentValue){
			_currentValue = currentValue;

		}



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
        public void UpdateMonitoredCondition()
        {
            for (int i = 0; i < _monitoredConditions.Count; i++)
            {
				_monitoredConditions [i].EvaluateMCExpression;
            }
        }


    }

}


