using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Collect_MDL
{
    public class ErrDataInfo_MDL
    {
        private int _ID;
        private string _MachineNo;        
        private string _MouldNo;
        private string _DispatchNo;
        private string _WorkOrderNo;

        private string _OriginalData;
        private string _ModifyData;
        private string _UploadDate;

        private string _ModifyFlag;
        private string _ModifyFlagID;
        private string _InputFlagID;
        private string _InputFlag;

        private string _Operator;
        private string _OperatorDate;

        public ErrDataInfo_MDL() { }
        public ErrDataInfo_MDL(int vID,
           string vMachineNo, string vMouldNo, string vDispatchNo, string vWorkOrderNo, 
           string vOriginalData, string vModifyData, string vUploadDate,             
           string vModifyFlagID, string vModifyFlag, string vInputFlagID, string vInputFlag,
           string vOperator, string vOperatorDate)
        {
            this._ID = vID;
            this._MachineNo = vMachineNo;            
            this._MouldNo = vMouldNo;
            this._DispatchNo = vDispatchNo;
            this._WorkOrderNo = vWorkOrderNo;

            this._OriginalData = vOriginalData;
            this._ModifyData = vModifyData;
            this._UploadDate = vUploadDate;

            this._ModifyFlagID = vModifyFlagID;
            this._ModifyFlag = vModifyFlag;
            this._InputFlagID = vInputFlagID;
            this._InputFlag = vInputFlag;

            this._Operator = vOperator;
            this._OperatorDate = vOperatorDate;
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

        public string MouldNo
        {
            get { return _MouldNo; }
            set { _MouldNo = value; }
        }

        public string DispatchNo
        {
            get { return _DispatchNo; }
            set { _DispatchNo = value; }
        }

        public string WorkOrderNo
        {
            get { return _WorkOrderNo; }
            set { _WorkOrderNo = value; }
        }

        public string OriginalData
        {
            get { return _OriginalData; }
            set { _OriginalData = value; }
        }

        public string ModifyData
        {
            get { return _ModifyData; }
            set { _ModifyData = value; }
        }

        public string UploadDate
        {
            get { return _UploadDate; }
            set { _UploadDate = value; }
        }

        public string ModifyFlagID
        {
            get { return _ModifyFlagID; }
            set { _ModifyFlagID = value; }
        }

        public string ModifyFlag
        {
            get { return _ModifyFlag; }
            set { _ModifyFlag = value; }
        }

        public string InputFlag
        {
            get { return _InputFlag; }
            set { _InputFlag = value; }
        }

        public string InputFlagID
        {
            get { return _InputFlagID; }
            set { _InputFlagID = value; }
        }

        public string Operator
        {
            get { return _Operator; }
            set { _Operator = value; }
        }

        public string OperatorDate
        {
            get { return _OperatorDate; }
            set { _OperatorDate = value; }
        }

    }
}
