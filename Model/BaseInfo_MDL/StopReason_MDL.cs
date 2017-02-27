using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.BaseInfo_MDL
{
    public class StopReason_MDL
    {
        private int _ID;
        private string _ReasonID;
        private string _ReasonName;

        public StopReason_MDL() {}
        public StopReason_MDL(int vID, string vReasonID,string vReasonName)
        {
            this._ID = vID;
            this._ReasonID = vReasonID;
            this._ReasonName = vReasonName;
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string ReasonID
        {
            get { return _ReasonID; }
            set { _ReasonID = value; }
        }

        public string ReasonName
        {
            get { return _ReasonName; }
            set { _ReasonName = value; }
        }
    }
}
