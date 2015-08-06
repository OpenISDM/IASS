/* 
Copyright (c) 2015  OpenISDM
    
Project Name: 
    
    IASS(Intelligent Active Storage Service)
 
File Name:

    Notification.cs
    
Abstract:
 

 
Authors:  
 
    Li-Kai, Chi, kevinjipotw@gmail.com
    Johnson Su, johnsonsu@iis.sinica.edu.tw
 
License:
 
    GPL 3.0 This file is subject to the terms and conditions defined 
    in file 'COPYING.txt', which is part of this source code package.
 
Major Revision History:
 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IASS.Collections
{
    class Notification
    {
        private string notificaitonID;
        private string notificationType;
        private string notificationMessage;

        /*
        Routine Name:
            Constructor

        Routine Description:
            This function allows the caller to init attributes 
            of notification object.

        Arguments:
            NotificaitonID - 
            NotificationType -
            NotificationMessage -

        Return Value:
            None.
        */
        public Notification(
            string notficationID,
            string notificationType,
            string notificationMessage
            )
        {
            this.notificaitonID = notficationID;
            this.notificationType = notificationType;
            this.notificationMessage = notificationMessage;
        }

        /*
         Routine Name:
             ID

         Routine Description:
             This function allows the caller to Get and Set values.
             We implement it using C# feature - Properties

         Arguments:
             None.

         Return Value:
             The function returns a notification ID.
         */
        public string ID
        {
            get
            {
                return notificaitonID;
            }
            set
            {
                notificaitonID = value;
            }

        }
        /*
         Routine Name:
             ActionType

         Routine Description:
             This function allows the caller to Get and Set values.
             We implement it using C# feature - Properties

         Arguments:
             None.

         Return Value:
             The function returns an action type of notification.
         */
        public string ActionType
        {
            get
            {
                return notificationType;
            }
            set
            {
                notificationType = value;
            }

        }
        /*
         Routine Name:
             Message

         Routine Description:
             This function allows the caller to Get and Set values.
             We implement it using C# feature - Properties

         Arguments:
             None.

         Return Value:
             The function returns a message string of notification.
         */
        public string Message
        {
            get
            {
                return notificationMessage;
            }
            set
            {
                notificationMessage = value;
            }

        }
    }
}
