using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Adminis_MDL
{
    public class UserProgramMap_MDL
    {
        private int _ID;
        private ArrayList _IDList;
        private string _UserID;
        private string _ProgramID;
        private string _ProgramName;

        private string _AddFlag;
        private string _CnlFlag;
        private string _MdyFlag;
        private string _QuyFlag;
        private string _PrtFlag;
        private string _ChkFlag;
        private string _ChkFlagNO;
        private string _aDate;
        private string _mDate;

        public UserProgramMap_MDL(int _ID, string _UserID, string _ProgramID,string _ProgramName, string _AddFlag, string _CnlFlag, string _MdyFlag, string _QuyFlag, string _PrtFlag, string _ChkFlag, string _aDate, string _mDate)
        {
            this._ID = _ID;
            this._UserID = _UserID;
            this._ProgramID = _ProgramID;
            this._ProgramName = _ProgramName;
            this._AddFlag = _AddFlag;
            this._CnlFlag = _CnlFlag;
            this._MdyFlag = _MdyFlag;
            this._QuyFlag = _QuyFlag;
            this._PrtFlag = _PrtFlag;
            this._ChkFlag = _ChkFlag;
            this._aDate = _aDate;
            this._mDate = _mDate;
        }
        public UserProgramMap_MDL(int _ID, string _UserID, string _ProgramID, string _ProgramName, string _AddFlag, string _CnlFlag, string _MdyFlag, string _QuyFlag, string _PrtFlag, string _ChkFlag,string _ChkFlagNO, string _aDate, string _mDate)
        {
            this._ID = _ID;
            this._UserID = _UserID;
            this._ProgramID = _ProgramID;
            this._ProgramName = _ProgramName;
            this._AddFlag = _AddFlag;
            this._CnlFlag = _CnlFlag;
            this._MdyFlag = _MdyFlag;
            this._QuyFlag = _QuyFlag;
            this._PrtFlag = _PrtFlag;
            this._ChkFlag = _ChkFlag;
            this._ChkFlagNO = _ChkFlagNO;
            this._aDate = _aDate;
            this._mDate = _mDate;
        }

        public int ID
       {
           get { return _ID; }
           set { _ID = value; }
       }
       public ArrayList IDList
       {
           get { return _IDList; }
           set { _IDList = value; }
       }
        public string UserID
       {
           get { return _UserID; }
           set { _UserID = value; }
       }
        public string ProgramID
       {
           get { return _ProgramID; }
           set { _ProgramID = value; }
       }
        public string ProgramName
        {
            get { return _ProgramName; }
            set { _ProgramName = value; }
        }
        public string AddFlag
       {
           get { return _AddFlag; }
           set { _AddFlag = value; }
       }
        public string CnlFlag
       {
           get { return _CnlFlag; }
           set { _CnlFlag = value; }
       }
        public string MdyFlag
       {
           get { return _MdyFlag; }
           set { _MdyFlag = value; }
       }

        public string QuyFlag
       {
           get { return _QuyFlag; }
           set { _QuyFlag = value; }
       }
        public string PrtFlag
       {
           get { return _PrtFlag; }
           set { _PrtFlag = value; }
       }

        public string ChkFlag
       {
           get { return _ChkFlag; }
           set { _ChkFlag = value; }
       }

        public string ChkFlagNO
        {
            get { return _ChkFlagNO; }
            set { _ChkFlagNO = value; }
        }

        public string aDate
       {
           get { return _aDate; }
           set { _aDate = value; }
       }
        public string mDate
       {
           get { return _mDate; }
           set { _mDate = value; }
       }

    }
}
