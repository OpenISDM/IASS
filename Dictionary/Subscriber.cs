using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Subscriber
    {
        //Property
        /*
         * The key which is used to varify the subscriber,
         * and how to notify subscriber assigned applications
         * example: key: 100aa, notify: PUSH
         */
        private int subscribeKey;
        private String nameOfNotifyWay;
        
        private NotificationSelection notification;
        private NotifyWay usedWay;

        //Constructor
        public Subscriber(String nameOfNotifyWay)
        {
            //Debug information
            Console.WriteLine("An Object Subscriber was created with type ={0}",nameOfNotifyWay);
            
            /*
             * Pass the assigned notification way by name (String type)
             * to get corresponding class of notify way
             */
            this.nameOfNotifyWay = nameOfNotifyWay;
            notification = new NotificationSelection(nameOfNotifyWay);
            this.usedWay= notification.usedWay;
        }

        //Method
        public String getWay()
        {
            // get the notification way
            return this.nameOfNotifyWay;
        }
        public Boolean executeNotify()
        {
            // execute corresponding notification way
            Boolean notifySuccess = false;
            notifySuccess = this.usedWay.executeNotify(null);
            return notifySuccess;
        }
    }
}
