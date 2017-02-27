using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Call_MDL
{
    public class CallMachineVacation_MDL
    {
        private int _ID;
        private string _MachineNo;
        private string _StartDate;
        private string _EndDate;
        private string _Creator;
        private string _CreateDate;
        private string _WorkShop;

        public CallMachineVacation_MDL(int vID,string vMachineNo,string vStartDate,string vEndDate,string vCreator,string vCreateDate,string vWorkShop)
        {
            this._ID = vID;
            this._MachineNo = vMachineNo;
            this._StartDate = vStartDate;
            this._EndDate = vEndDate;
            this._Creator = vCreator;
            this._CreateDate = vCreateDate;
            this._WorkShop = vWorkShop;
        }
        public CallMachineVacation_MDL(int vID, string vMachineNo, string vStartDate, string vEndDate, string vCreator, string vCreateDate)
        {
            this._ID = vID;
            this._MachineNo = vMachineNo;
            this._StartDate = vStartDate;
            this._EndDate = vEndDate;
            this._Creator = vCreator;
            this._CreateDate = vCreateDate;
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string MachineNo
        {
            get { return _MachineNo; }
            set { _MachineNo = value; }
        }
        public string StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; }
        }
        public string EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; }
        }
        public string Creator
        {
            get { return _Creator; }
            set { _Creator = value; }
        }
        public string CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }
        public string WorkShop
        {
            get { return _WorkShop; }
            set { _WorkShop = value; }
        }

    }
}
