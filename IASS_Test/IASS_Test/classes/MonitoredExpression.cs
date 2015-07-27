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
        public int monitoredObjectID;
        int currExpressionValue;
        bool monitoredExpressionResult;

        //**can use del if expression doesn't work
        //ex: Expression<Func<int, bool>> expr = num => num < 5;
        Expression expression;		
        

        public MonitoredExpression(int MonitoredObjectID, int currExpressionValue, Expression expression)
        {	
            //constructor
            this.monitoredObjectID = MonitoredObjectID;
            this.currExpressionValue = currExpressionValue;

            //expression will be passed in already formatted
            this.expression = expression;		
        }

        public void UpdateMonitoredExpression(int currentValue)
        {
            //sample
            //_monitoredExpressionResult = _expression(currentValue); 
        }
    }
}
