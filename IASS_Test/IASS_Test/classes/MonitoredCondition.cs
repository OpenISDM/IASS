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
        List<MonitoredObject> MOList =null;
        bool monitoredConditionResult;

        //stores all the monitor expression
        List<MonitoredExpression> monitoredExpressions = new List<MonitoredExpression>(); 		
        Expression monitoredConditionLogic;
        //Constructor
        public MonitoredCondition(List<MonitoredExpression> monitoredExpressions, Expression monitorConditionLogic)
        {	
            //constructor 
            monitoredExpressions = monitoredExpressions;    //a list of monitoredExpressions
            monitoredConditionLogic = monitorConditionLogic;
            monitoredConditionResult = false;
        }

        //Get Methods
        public string GetMCID()
        {
            return MCID;
        }
        //Methods
        public void UpdateMonitoredExpression(int monitoredObjectID, int currentValue)
        { 	
            //check the expression results when MO is updated
            for (int i = 0; i < monitoredExpressions.Count; i++)
            {
                if (monitoredExpressions[i].monitoredObjectID == monitoredObjectID)
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
        public void SetMCID(string requestID)
        {
            //7/16 version1: test code
            MCID = requestID + "***";
        }
        public void SetMOList(List<MonitoredObject> MOList)
        {
            this.MOList = MOList;
        }
        public List<MonitoredObject> GetMOList()
        {
            return MOList;
        }
    }
}
