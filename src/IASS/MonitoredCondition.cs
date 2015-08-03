

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace IASS_Test
{
	public class MonitoredCondition
	{

		private List<MonitoredObject> monitoredObjectList;
		private string expression;
		private bool monitoredConditionResult;

		//Constructor
		public MonitoredCondition(string expression, List<MonitoredObject> monitoredObjectList)
		{	
			this.expression = expression;
			this.monitoredObjectList = monitoredObjectList;
			EvaluateExpression ();
		}

		private void EvaluateExpression(){
			var parameter = Expression.Parameter(typeof(List<MonitoredObject>), "monitoredObjectList");

			var expression = System.Linq.Dynamic.DynamicExpression.ParseLambda(new[] { parameter }, null, this.expression);
			var result = (bool) expression.Compile().DynamicInvoke(monitoredObjectList);
			monitoredConditionResult = result; 
		}


	}

}


