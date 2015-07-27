using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IASS_Test
{
    class Request
    {
        string requestUID = "";
        string MCstring = "water >5 & fire = TRUE";
        string pointerToNotificaitionList =null;
        string pointerToMC = "";
        bool ModifyByOthers =false;
        bool ViewByOthers =false;

        public Request(string MCstring, string pointerToNotificationList, bool ModifyByOthers, bool ViewByOthers){
            this.MCstring = MCstring;
            this.pointerToNotificaitionList = pointerToNotificationList;
            this.ModifyByOthers = ModifyByOthers;
            this.ViewByOthers = ViewByOthers;
            this.requestUID = GenerateRequestID(); 

        }
        

        //Method
        public string GenerateRequestID()
        {
            string requestUniquID ="";
            //version 1 :7/16, test code
            requestUniquID = MCstring + "_"+DateTime.Now.ToString();
            return requestUniquID;
        }
        public void SetPointerTOMC(string pointerToMC)
        {
            //update the pointer of MC
        }
        //Get, Set Method
        public string GetMCstring()
        {
            return MCstring;
        }
        public string GetPointerToNotificationList()
        {
            return pointerToNotificaitionList;
        }
        public string GetRequestUID()
        {
            return requestUID;
        }
        public bool GetModifyFlag()
        {
            return ModifyByOthers;
        }
        public bool GetViewFlag()
        {
            return ViewByOthers;
        }
    }
}
