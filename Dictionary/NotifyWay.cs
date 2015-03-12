using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    abstract class NotifyWay
    {
        /*
         * This is the abstruct class of notification ways
         * It contains at least two properties which are "notifySucess" that present 
         * the result of this notification (success: True, fail: false),
         * and "way" that to specify this notification way.
         * Beside, there is at least a method "executeNotify"
         * which is about how to execute the notification
         */

        //Property
        
        //Is the notification successfully delivered?
        //private abstract Boolean notifySuccess;
        //Which way will be implemented? 
        //private abstract String way;

        //Method
        
        //When triggered, execute notification
        public abstract Boolean executeNotify(Object nofityParameters);
    }
    class NotificationSelection
    {
        //Property
        public NotifyWay usedWay;
        //Constructor
        public NotificationSelection(String way)
        {
            if (way == "PUSH")
            {
                // When PUSH is chosen
                usedWay = new NotifyByPUSH();
            }
            else if (way == "SIGNAL")
            {
                // When SENDING SIGNAL is chosen
                usedWay = new NotifyBySIGNAL();
            }
            else
            {
                // The chosen way may be wrong or has not be supported yet
                usedWay = null;

            }
        }

        //Method
    }
    class NotifyByPUSH : NotifyWay
    {
        
        //Overriding property
        private Boolean notifySuccess = false;
        private String way = "PUSH";

        //Constructor
        public NotifyByPUSH()
        {
            //Debug information
            Console.WriteLine("An Object NotifyByPUSH was created");
        }

        //Overriding method
        public override Boolean executeNotify(object nofityParameters)
        {
           
            //How to execute PUSH
            notifySuccess = true;
            return notifySuccess;
            //Execption
            throw new NotImplementedException();
        }
    }
    class NotifyBySIGNAL : NotifyWay
    {

        //Overriding property
        private Boolean notifySuccess = false;
        private String way = "SIGNAL";

        //Constructor
        public NotifyBySIGNAL()
        {
            //Debug information
            Console.WriteLine("An Object NotifyBySIGNAL was created");
        }
        //Overriding method
        public override Boolean executeNotify(object nofityParameters)
        {

            //How to execute PUSH
            notifySuccess = true;
            return notifySuccess;
            //Execption
            throw new NotImplementedException();
        }
    }
}
