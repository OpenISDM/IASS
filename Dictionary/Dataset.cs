using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Dataset
    {
        //Property
        private int dataSetID;
        private String datasetName;

        /*
         * --Time information block--
         * Properties:{update frequency, time of last updated,}
         * Methods:{changeUpdatedTime(), setNewFrequency()}
         */
        private ValidTime timeBlock;

        /*
         * What fields are in the dataset
         * example: {Station ID, Station Name, Value in 10 mins, Value in 1 hr}
         */
        List<String> fields; 

        /*
         * A field which be used as a reference
         * example: "Station Name"
         */
        private String referencedField;

        /*
         * Keys in the referenced field
         * example: Station Name:{Taipei station_1, Taipei station_2, Taipei station_3}
         */
        List<String> keyFieldList;
        /*
         * <a key in the referenced field, monitored fields with the key>
         * example: <Taipei station_1,
         *           monitored fields with "Taipei station_1"
         *           :{Value in 10 mins, Value in 1 hr}>
         */
        Dictionary<String, MonitoredListWithKey> monitoredList;

        //Constructor

        //Method
        public List<String> listFields()
        {
            // return the list of fields
            return this.fields;
        }
        public List<String> listReferencedFields()
        {
            //return the keys in referenced field
            return this.keyFieldList;
        }
        public MonitoredListWithKey getMonitoredList(String referencedKey)
        {
            /*Check whether the specified key exist,
             *if it is then return the list of monitored fields related to the key
             */
            if (monitoredList.ContainsKey(referencedKey) == true)
            {
                return monitoredList[referencedKey];
            }
            else
            {
                return null;
            }
        }
    }
}
