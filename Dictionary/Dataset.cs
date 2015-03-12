using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Dataset
    {
        /*
         * Properties:
         * String datasetID: the unique ID of the dataset
         * String datasetName: the name of the dataset
         * 
         * ValidTime timeBlock: time information block of the dataset 
         *                      {update frequency, last updated date, exired time}
         * 
         * List<String> fields: all fields in the dataset
         *                      example:{Station name, station ID, value in 1hr}
         *                      
         * String referencedField: the reference field
         *                         example: "Station name"
         *                         
         * List<String> keyFieldListL: keys in the referenced field
         *                             example:{Taipei station, HsinChu station}
         * 
         * Methods:
         * 1. getDatasetName(): get the name of this dataset
         * 2. getDatasetUUID(): get the UUID of this dataset
         * 3. listFields(): get the fields in this dataset
         * 4. listReferencedFields(): list the keys in the referenced field
         * 5. getMonitoredFieldListByKey(String referencedKey):
         *                 get a list of monitored fields which related to a specific key
         *                 example: {
         *                           <Taipei station, value in 1hr>
         *                           <Taipei station, value in 10mins>
         *                          }
         * 6. printMonitoredFieldListByKey(String referencedKey)
         * 7. printAllMonitoredFieldList()
         * 
         */

        //Property
        private String datasetID;
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
        private List<String> fields; 

        /*
         * A field which be used as a reference
         * example: "Station Name"
         */
        private String referencedField;

        /*
         * Keys in the referenced field
         * example: Station Name:{Taipei station_1, Taipei station_2, Taipei station_3}
         */
        private List<String> keyFieldList;

        /*
         * <a key in the referenced field, monitored fields with the key>
         * example: <Taipei station_1,
         *           monitored fields with "Taipei station_1"
         *           :{Value in 10 mins, Value in 1 hr}>
         */

        protected Dictionary<String, List<MonitoredField>> monitoredList;



        //Constructor


        //Method
        public String getDatasetName()
        {
            // return the name of this dataset
            return this.datasetName;
        }
        public void setDatasetName(String datasetName)
        {
            // return the name of this dataset
            this.datasetName = datasetName;
        }
        public String getDatasetUUID()
        {
            return this.datasetID;
        }
        public void setDatasetUUID(String datasetUUID)
        {
            this.datasetID = datasetUUID;
        }
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
        public List<MonitoredField> getMonitoredFieldListByKey(String referencedKey)
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
        public void printMonitoredFieldListByKey(String referencedKey)
        {
            /*Check whether the specified key exist,
             *if it is then return the list of monitored fields related to the key
             */
            List<MonitoredField> fieldList;
            String temporaryKey;
            String temporaryField;

            if (monitoredList.ContainsKey(referencedKey) == true)
            {
                fieldList = monitoredList[referencedKey];

                /* for each monitor field,
                 * list all <key, field> pairs
                 */
                foreach (var oneField in fieldList)
                {
                    temporaryKey = oneField.getReferencedKey();
                    temporaryField = oneField.getFieldKey();
                    Console.WriteLine("Pair <{0}, {1}> is monitored",
                                       temporaryKey, temporaryField);
                }
            }
            else
            {
                //Exception
                Console.WriteLine("This key does not exist");
            }
        }
        public void printAllMonitoredFieldList()
        {
            List<String> keyList = this.keyFieldList;
            foreach (var oneKey in keyList)
            {
                /* for each key in the referenced field,
                 * retrieve the monitored field which related to this key
                 */
                 printMonitoredFieldListByKey(oneKey);

            }
        }
    }
}
