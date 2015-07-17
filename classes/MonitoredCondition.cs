using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace parsing_test
{
    public class MonitoredCondition
    {
        
		public List<MonitoredObject> _MOList;
		public string _expression;
		public bool _monitoredConditionResult;


        //Constructor
		public MonitoredCondition(string expression, List<MonitoredObject> MOList)
        {	
			_expression = expression;
			_MOList = MOList;
			EvaluateMCExpression ();

        }

		public void EvaluateMCExpression(){
			var p = Expression.Parameter(typeof(List<MonitoredObject>), "_MOList");

			var e = System.Linq.Dynamic.DynamicExpression.ParseLambda(new[] { p }, null, _expression);
			var result = (bool) e.Compile().DynamicInvoke(_MOList);
			_monitoredConditionResult = result; 


		}


    }
}


