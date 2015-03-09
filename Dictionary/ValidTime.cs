using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class ValidTime
    {
        //Property
        
        private DateTime lastUpdated;
        private int updateInMicroSecond;
        //Constructor
        public ValidTime(DateTime updatedTime,int updateInMicroSecond)
        {
            this.lastUpdated = updatedTime;
            this.updateInMicroSecond = updateInMicroSecond;
        }

        //Method
        public void changeUpdatedTime()
        {
            //update the last updated time
        }
        public void setNewFrequency()
        {
            //change the update frequency
        }

    }
}
