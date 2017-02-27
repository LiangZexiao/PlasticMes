using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.BaseInfo_MDL
{
    public class ColorMessage_MDL
    {
        private int _ID;

        private string _Number;

        private string _ColorName;

        private int _Depth;

        public ColorMessage_MDL() { }

        public ColorMessage_MDL(string vNumber) 
        {
            this._Number = vNumber;
        }

        public ColorMessage_MDL(int vID,string vNumber,string vColorName,int vDepth)
        {
            this._ID = vID;
            this._Number = vNumber;
            this._ColorName = vColorName;
            this._Depth = vDepth;
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string Number
        {
            get { return _Number; }
            set { _Number = value; }
        }

        public string ColorName
        {
            get { return _ColorName; }
            set { _ColorName = value; }
        }

        public int Depth
        {
            get { return _Depth; }
            set { _Depth = value; }
        }
    }
}
