using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Adminis_MDL
{
    public class GroupInfo_MDL
    {
        private int _ID;
        private ArrayList _IDList;
        private string _GroupID;
        private string _GroupName;
        private string _Header;
        private string _Action;
        private int _MemberNum;
        private string _Remark;
        private DateTime _aDate;
        private DateTime _mDate;

        public GroupInfo_MDL() { }
        public GroupInfo_MDL(int _ID, string _GroupID, string _GroupName, string _Header, string _Action, int _MemberNum, string _Remark,DateTime _aDate,DateTime _mDate)
        {
            this._ID = _ID;
            this._GroupID = _GroupID;
            this._GroupName = _GroupName;
            this._Header = _Header;
            this._Action = _Action;
            this._MemberNum = _MemberNum;
            this._Remark = _Remark;
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
        public string GroupID
       {
           get { return _GroupID; }
           set { _GroupID = value; }
       }
        public string GroupName
       {
           get { return _GroupName; }
           set { _GroupName = value; }
       }
        public string Header
       {
           get { return _Header; }
           set { _Header = value; }
       }
        public string Action
       {
           get { return _Action; }
           set { _Action = value; }
       }
        public int MemberNum
       {
           get { return _MemberNum; }
           set { _MemberNum = value; }
       }
        public string Remark
       {
           get { return _Remark; }
           set { _Remark = value; }
       }
        public DateTime aDate
       {
           get { return _aDate; }
           set { _aDate = value; }
       }
        public DateTime mDate
       {
           get { return _mDate; }
           set { _mDate = value; }
       }
    }
}
