using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class MonitoredListWithKey
    {
        //Property

        /*
         * refencedKey is the specified key in referenced field,
         * and referencedKeyCount is the order of it.
         * example: Taipei station_1, in 7 th tuple
         *          {regerencedKey: Taipei station_1, referencedKeyCount: 7}
         */
        private String referencedKey;
        private int referencedKeyCount;


        /*
         * With this key, which fields are monitored.
         * example: {key: Taipei station_1,List:{value in 10 mins, value in 1 hr}} 
         */
        List<String> monitoredFields;
        /*
         * <one of the monitored fields, the conditions based on this field>
         * example: <value in 10 mins, conditions:{> 100, < 50, = 20}>
         */
        Dictionary<String,ConditionList> fieldConditions;

        //Constructor

        //Method
    }
}
