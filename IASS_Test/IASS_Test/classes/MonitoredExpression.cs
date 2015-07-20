using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace IASS_Test
{
	class MonitoredExpression //one monitor expression  ex: water>5
	{
		public int _monitoredObjectID;
		int _currExpressionValue;
		bool _monitoredExpressionResult;

		//**can use del if expression doesn't work
		//ex: Expression<Func<int, bool>> expr = num => num < 5;
		Expression _expression;		


		public MonitoredExpression(int MonitoredObjectID, int currExpressionValue, Expression expression)
		{	
			//constructor
			this._monitoredObjectID = MonitoredObjectID;
			this._currExpressionValue = currExpressionValue;

			//expression will be passed in already formatted
			this._expression = expression;		
		}

		public void UpdateMonitoredExpression(int currentValue)
		{
			//sample
			//_monitoredExpressionResult = _expression(currentValue); 
		}
	}
}