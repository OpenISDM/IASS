using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class MonitoredField
    {
        //Property
        private String referencedKey;
        private String fieldKey;

        private String datasetUUID;
        private int monitorTaskID;


        private DataValue currentValue;
        private String valueType;

        private List<Condition> monitoredConditions;

        //Constructor
        public MonitoredField(String datasetUUID, String referencedKey, String fieldKey,String valueType)
        {
            //Debug information
            Console.WriteLine("A new monitored field is created");

            this.referencedKey = referencedKey;
            this.fieldKey = fieldKey;
            this.valueType = valueType;
            this.datasetUUID = datasetUUID;
            DataTypeSelection selectValueType = new DataTypeSelection(valueType);
            //with set and get
            currentValue = selectValueType.returnDataClass();
        }

        //Method
        public String getReferencedKey()
        {
            return this.referencedKey;
        }
        public String getFieldKey()
        {
            return this.fieldKey;
        }
        protected int generateID(int referenceNumber)
        {
            //This function will generated a new ID for the monitored field
            int newID;
            newID = referenceNumber + 1;
            return newID;
        }
        //add, delete, get condition list
       
    }
}
