using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Adminis_MDL
{
   public class SysClassInfo_MDL
    {
       private int _ID;
       private string _ClassID;
       private string _ClassName;
       private string _Remark;

       public SysClassInfo_MDL(int _ID, string _ClassID, string _ClassName,string _Remark)
       {
            this._ID = _ID;
            this._ClassID = _ClassID;
            this._ClassName = _ClassName;
            this._Remark = _Remark;
       }

       public SysClassInfo_MDL(int _ID, string _ClassID, string _ClassName)
       {
           this._ID = _ID;
           this._ClassID = _ClassID;
           this._ClassName = _ClassName;
       }

       public int ID
       {
           get { return _ID; }
           set { _ID = value; }
       }

       public string ClassID
       {
           get { return _ClassID; }
           set { _ClassID = value; }
       }

       public string ClassName
       {
           get { return _ClassName; }
           set { _ClassName = value; }
       }

       public string Remark
       {
           get { return _Remark; }
           set { _Remark = value;}
       }
    }
}
