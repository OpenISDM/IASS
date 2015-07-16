using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IASS_Test
{
    class Request
    {
        string _requestUID = "";
        string _MCstring = "water >5 & fire = TRUE";
        string _pointerToNotificaitionList =null;
        string _pointerToMC = "";
        bool _ModifyByOthers =false;
        bool _ViewByOthers =false;

        public Request(string MCstring, string pointerToNotificationList, bool ModifyByOthers, bool ViewByOthers){
            this._MCstring = MCstring;
            this._pointerToNotificaitionList = pointerToNotificationList;
            this._ModifyByOthers = ModifyByOthers;
            this._ViewByOthers = ViewByOthers;
            this._requestUID = GenerateRequestID(); 

        }
        

        //Method
        public string GenerateRequestID()
        {
            string requestUniquID ="";
            //version 1 :7/16, test code
            requestUniquID = _MCstring + "_"+DateTime.Now.ToString();
            return requestUniquID;
        }
        public void SetPointerTOMC(string pointerToMC)
        {
            //update the pointer of MC
        }
        //Get, Set Method
        public string GetMCstring()
        {
            return _MCstring;
        }
        public string GetPointerToNotificationList()
        {
            return _pointerToNotificaitionList;
        }
        public string GetRequestUID()
        {
            return _requestUID;
        }
        public bool GetModifyFlag()
        {
            return _ModifyByOthers;
        }
        public bool GetViewFlag()
        {
            return _ViewByOthers;
        }
    }
}
