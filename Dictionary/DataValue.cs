using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    abstract class DataValue
    {

        abstract public void setValueType(String valueType);
        abstract public String getValueType();
        abstract public Boolean setValue(Object newValue);
    }
    class DataTypeSelection
    {
        //Property
        DataValue dataValue;

        //Constructor
        public DataTypeSelection(String valueType)
        {
            if (valueType.Equals("Boolean"))
            {
                dataValue = new DataBoolean();
            }
            else if(valueType.Equals("Integer"))
            {
                dataValue = new DataInteger();
            }
            else 
            {
                Console.WriteLine("This type of value is not supported.");
            }
        }
        //Method
        public DataValue returnDataClass()
        {
            return dataValue;
        }
    }
    class DataBoolean : DataValue
    {
        //Overriding property
        private String valueType;
        private Boolean value;

        private Boolean upperBound = true;
        private Boolean lowerBound = false;

        //Constructor
        public DataBoolean()
        {
            value = false;
        }

        //Overriding method
        public override void setValueType(String valueType)
        {
            this.valueType = valueType;
        }
        public override String getValueType()
        {
            return this.valueType;
        }
        public Boolean getValue()
        {
            return this.value;
        }
        public override Boolean setValue(Object newValue)
        {
            Boolean setSuccess = false;
            value = (Boolean) newValue;
            setSuccess = true;
            return setSuccess;
        }
    }
    class DataInteger : DataValue
    {
        //Overriding property
        private String valueType = "Integer";
        private int value;

        // -2147473647 ~ 2147483647
        private int upperBound = -2147473647;
        private int lowerBound = 2147483647;

        //Constructor
        public DataInteger()
        {
            value = 0;
        }

        //Overriding method
        public override void setValueType(String valueType)
        {
            this.valueType = valueType;
        }
        public override String getValueType()
        {
            return this.valueType;
        }
        public int getValue()
        {
            return this.value;
        }
        public override Boolean setValue(Object newValue)
        {
            Boolean setSuccess = false;
            value = (int)newValue;
            setSuccess = true;
            return setSuccess;
        }
    }
}
