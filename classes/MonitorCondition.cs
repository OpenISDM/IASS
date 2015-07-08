

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace x3
{
	public class MonitoredCondition   	//one monitored condition ex: water < 5 && fire > 6 
	{
		
		bool _monitoredConditionResult;  
		List<MonitoredExpression> _monitoredExpressions = new List<MonitoredExpression>(); 		//stores all the monitor expression
		Expression _monitorConditionLogic;

		public MonitoredCondition(List<MonitoredExpression> monitoredExpressions, Expression monitorConditionLogic){		//constructor 
			_monitoredExpressions = monitoredExpressions;    //a list of monitoredExpressions
			_monitorConditionLogic = monitorConditionLogic;
			_monitoredConditionResult = false;

		}

		public void CheckMonitoredExpression(int monitoredObjectID, int currentValue){ 	//check the expression results when MO is updated
			for(int i = 0; i < _monitoredExpressions.Count; i++){ 
				if(_monitoredExpressions[i]._monitoredObjectID == monitoredObjectID){
					_monitoredExpressions[i].checkMonitoredExpression(currentValue);
				}
			}
		}

		public void EvalMonitoredConditionResult(){ 	//eval all expressions in MC as a group
			//sample
//			_monitoredConditionResult = _monitorConditionLogic(_monitoredExpressions[0], _monitoredExpressions[1]) 


		}


	}

}


