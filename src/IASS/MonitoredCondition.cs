/* 
Copyright (c) 2015  OpenISDM
    
Project Name: 
    
    IASS(Intelligent Active Storage Service)

File Name:

    MonitoredCondition.cs
 
Abstract:
 

 
Authors:  
 
    Li-Kai, Chi, kevinjipotw@gmail.com
    Johnson Su, johnsonsu@iis.sinica.edu.tw
 
License:
 
    GPL 3.0 This file is subject to the terms and conditions defined 
    in file 'COPYING.txt', which is part of this source code package.
 
Major Revision History:
 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace IASS.Collections
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
            EvaluateExpression();
        }

        private void EvaluateExpression()
        {
            var parameter = Expression.Parameter(typeof(List<MonitoredObject>), "monitoredObjectList");

            var expression = System.Linq.Dynamic.DynamicExpression.ParseLambda(new[] { parameter }, null, this.expression);
            var result = (bool) expression.Compile().DynamicInvoke(monitoredObjectList);
            monitoredConditionResult = result;
        }


    }

}


