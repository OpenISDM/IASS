

using System;
using System.Linq.Expressions;

namespace x3
{
	public class MonitoredExpression 	//one monitor expression  ex: water>5
	{
		public int _monitoredObjectID;
		int _currExpressionValue;
		bool _monitoredExpressionResult;
		Expression _expression;		//can use del if expression doesn't work
		//ex: Expression<Func<int, bool>> expr = num => num < 5;


		public MonitoredExpression(int MonitoredObjectID, int currExpressionValue, Expression expression){		//constructor
			_monitoredObjectID = MonitoredObjectID;
			_currExpressionValue = currExpressionValue;
			_expression = expression;		//expression will be passed in already formatted
		}
			
		public void UpdateMonitoredExpression(int currentValue){
			//sample
//			_monitoredExpressionResult = _expression(currentValue); 
		}

	}

}

