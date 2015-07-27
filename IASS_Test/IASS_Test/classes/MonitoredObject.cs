using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IASS_Test
{
    class MonitoredObject
    {
        private int currentValue;
        private int validTime;
        private int lastUpdateTime;
        private int nextUpdateTime;
        private int updateTimeInterval;
        private int ShortestResponseTime;
        private string monitoredObjectID;

        List<MonitoredCondition> monitoredConditions = new List<MonitoredCondition>();


        public int AccessPath()
        {
            //run script/function to get value
            //script/function will return currentValue, validTime, and lastUpdateTime 

            //			_currentValue = updatedValue;
            //			_validTime = validTime;
            //			_lastUpdateTime = lastUpdateTime;
            //			_nextUpdateTime = lastUpdateTime + _updateTimeInterval;

            return currentValue;
        }

        //check all update all monitor condition result in _monitorConditions list 
        public void UpdateMonitoredCondition()
        {
            for (int i = 0; i < monitoredConditions.Count; i++)
            {
                //				_monitoredConditions [i].CheckMonitoredExpression(_monitoredObjectID, _currentValue);
            }
        }
        //7/27 test code to generate sample monitored object
        public void SetMonitoredObjectID(string monitoredObjectID)
        {
            this.monitoredObjectID = monitoredObjectID;
        }
        public string GetMonitoredObjectID()
        {
            return monitoredObjectID;
        }
    }
}
