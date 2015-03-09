using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class NotificationList
    {
        //Property

        private int conditionID;
        /*
         * The subscribers which subscribe this condition
         * thatis, when the condition happens, which notification will be triigered,
         * example: List {notify application A with PUSH,
         *                notify application B with trigger SIGNAL of scrolling text Marquee }
         */
        List<Subscriber> subscriberInfo;

        //Constructor
        //Method
    }
}
