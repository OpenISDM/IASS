using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class ConditionList
    {
        //Porperty
        /*
         * the type of value with the <key, field> pair
         * example: Boolean, String, integer
         */
        private String valueType;
        /*
         * the current value with the <key, field> pair
         * example: in <Taipei station_1, value in 10 mins> pair, 
         *          the current value = 30 then value will equal 30
         */
        DataValue value;
        /*
         * The list of related conditions
         * example: Conditions: {condition 001 = when the value <100, 
         *                       condition 002 = When the value = 50} 
         */
        List<Condition> conditions;
        /*
         * <condition ID, corresponding notification list>
         * When condition with specified ID happens,
         * which notification will be triggered
         * 
         * example: <condition 001,
         *           NotificationLsit: 
         *           {notify application A with push, notify application B with push}>
         */
        Dictionary<int, NotificationList> triggeredNotifications;
        
        //Constructor
        //Method
    }
}
