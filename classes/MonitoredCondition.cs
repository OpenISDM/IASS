

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

		public List<MonitoredObject> monitoredObjectList;
		public string expression;
		public bool monitoredConditionResult;


		//Constructor
		public MonitoredCondition(string expression, List<MonitoredObject> monitoredObjectList)
		{	
			this.expression = expression;
			this.monitoredObjectList = monitoredObjectList;
			EvaluateExpression ();

		}

		public void EvaluateMCExpression(){
			var parameter = Expression.Parameter(typeof(List<MonitoredObject>), "monitoredObjectList");

			var expression = System.Linq.Dynamic.DynamicExpression.ParseLambda(new[] { p }, null, this.expression);
			var result = (bool) e.Compile().DynamicInvoke(monitoredObjectList);
			monitoredConditionResult = result; 
		}


	}
}


