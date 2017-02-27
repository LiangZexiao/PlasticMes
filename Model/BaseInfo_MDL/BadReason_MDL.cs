using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.BaseInfo_MDL
{
    public class BadReason_MDL
    {
        private int _ID;
        private string _ReasonID;
        private string _IMReasonName;
        private string _OMReasonName;
        public BadReason_MDL() {}
        public BadReason_MDL(int vID, string vReasonID, string vIMReasonName, string vOMReasonName)
        {
            this._ID = vID;
            this._ReasonID = vReasonID;
            this._IMReasonName = vIMReasonName;
            this._OMReasonName = vOMReasonName;
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

        public string IMReasonName
        {
            get { return _IMReasonName; }
            set { _IMReasonName = value; }
        }
        public string OMReasonName
        {
            get { return _OMReasonName; }
            set { _OMReasonName = value; }
        }
    }
}
