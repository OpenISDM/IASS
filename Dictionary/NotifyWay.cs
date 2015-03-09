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
        private abstract Boolean notifySuccess;
        private abstract String way;
        //Method
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
                usedWay = new NotifyByPUSH();
            }
            else if (way == "SIGNAL")
            {
                usedWay = new NotifyBySIGNAL();
            }
            else
            {
                usedWay = null;
                Console.WriteLine("No such notification way!");
            }
        }

        //Method
    }
    class NotifyByPUSH : NotifyWay
    {
        
        //Overriding property
        private override Boolean notifySuccess = false;
        private override String way = "PUSH";


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
        private override Boolean notifySuccess = false;
        private override String way = "SIGNAL";

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
