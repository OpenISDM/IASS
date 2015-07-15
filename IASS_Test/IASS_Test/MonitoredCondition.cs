using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace IASS_Test
{
    class MonitoredCondition
    {
        string MCID;
        List<MonitoredObject> _MOList;
        bool _monitoredConditionResult;

        //stores all the monitor expression
        List<MonitoredExpression> _monitoredExpressions = new List<MonitoredExpression>(); 		
        Expression _monitoredConditionLogic;
        //Constructor
        public MonitoredCondition(List<MonitoredExpression> monitoredExpressions, Expression monitorConditionLogic)
        {	
            //constructor 
            _monitoredExpressions = monitoredExpressions;    //a list of monitoredExpressions
            _monitoredConditionLogic = monitorConditionLogic;
            _monitoredConditionResult = false;

        }

        //Get Methods
        public string GetMCID()
        {
            return MCID;
        }
        public List<MonitoredObject> GetMOList()
        {
            return _MOList;
        }
        //Methods
        public void UpdateMonitoredExpression(int monitoredObjectID, int currentValue)
        { 	
            //check the expression results when MO is updated
            for (int i = 0; i < _monitoredExpressions.Count; i++)
            {
                if (_monitoredExpressions[i]._monitoredObjectID == monitoredObjectID)
                {
                    //_monitoredExpressions[i].checkMonitoredExpression(currentValue);
                }
            }
        }
        public void EvalMonitoredConditionResult()
        { 	//eval all expressions in MC as a group
            //sample
            //_monitoredConditionResult = _monitorConditionLogic(_monitoredExpressions[0], _monitoredExpressions[1]) 
        }
    }
}
