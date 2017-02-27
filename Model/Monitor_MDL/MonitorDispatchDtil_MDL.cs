using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Monitor_MDL
{
    public class MonitorDispatchDtil_MDL
    {
        private int _MasterID;
        private string _DispatchNo;
        private string _PlanDate;
        private string _PlanQty;
        private string _RealQty;
        private string _DiffQty;
        private string _AddDiffQty;
        private string _CompleteRate;

       public MonitorDispatchDtil_MDL() { }
       public MonitorDispatchDtil_MDL(int vMasterID, string vDispatchNo, string vPlanDate, string vPlanQty, string vRealQty,
                string vDiffQty, string vAddDiffQty, string vCompleteRate)
        {
            this._MasterID = vMasterID;
            this._DispatchNo = vDispatchNo;
            this._PlanDate = vPlanDate;
            this._PlanQty = vPlanQty;
            this._RealQty = vRealQty;
            this._DiffQty = vDiffQty;
            this._AddDiffQty = vAddDiffQty;
            this._CompleteRate = vCompleteRate;
        }

        public int MasterID
        {
            get { return _MasterID; }
            set { _MasterID = value; }
        }

       public string DispatchNo
       {
           get { return _DispatchNo; }
           set { _DispatchNo = value; }
       }

       public string PlanDate
       {
           get { return _PlanDate; }
           set { _PlanDate = value; }
       }

       public string PlanQty
       {
           get { return _PlanQty; }
           set { _PlanQty = value; }
       }

       public string RealQty
       {
           get { return _RealQty; }
           set { _RealQty = value; }
       }

       public string DiffQty
       {
           get { return _DiffQty; }
           set { _DiffQty = value; }
       }

       public string AddDiffQty
       {
           get { return _AddDiffQty; }
           set { _AddDiffQty = value; }
       }

       public string CompleteRate
       {
           get { return _CompleteRate; }
           set { _CompleteRate = value; }
       }
    }
}
