using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Product_MDL
{
    public class MPSResult_MDL
    {
        private int _ID;

        private string _MPSNo;
        private string _WorkOrderNo;
        private string _ProductNo;
        private string _MachineNo;
        private string _MouldNo;
        private string _Num;
        private string _DueDate;
        private string _SchStartDate;
        private string _SchEndDate;
        private string _Status;

        private string _RearrangeFlag;
        private string _ErrMsg;
        private string _CreateDate;
        private string _Checker;
        private string _Creater;

        private string _DeliveryQty;

       

        public MPSResult_MDL(){}
        public MPSResult_MDL(int vID,
           string vMPSNo,
           string vWorkOrderNo,
           string vProductNo,
           string vMachineNo,
           string vMouldNo,
           string vNum,
           string vDueDate,
           string vSchStartDate,
           string vSchEndDate,
           string vStatus,

           string vRearrangeFlag,
           string vErrMsg,
           string vCreateDate,
           string vChecker,
           string vCreater)
        {
            this._ID = vID;

            this._MPSNo = vMPSNo;
            this._WorkOrderNo = vWorkOrderNo;
            this._ProductNo = vProductNo;
            this._MachineNo = vMachineNo;
            this._MouldNo = vMouldNo;
            this._Num = vNum;
            this._DueDate = vDueDate;
            this._SchStartDate = vSchStartDate;
            this._SchEndDate = vSchEndDate;
            this._Status = vStatus;

            this._RearrangeFlag = vRearrangeFlag;
            this._ErrMsg = vErrMsg;
            this._CreateDate = vCreateDate;
            this._Checker = vChecker;
            this._Creater = vCreater;
        }

        public MPSResult_MDL(int vID,
                  string vMPSNo,
                  string vWorkOrderNo,
                  string vProductNo,
                  string vMachineNo,
                  string vMouldNo,
                  string vNum,
                  string vDueDate,
                  string vSchStartDate,
                  string vSchEndDate,
                  string vStatus,

                  string vRearrangeFlag,
                  string vErrMsg,
                  string vCreateDate,
                  string vChecker,
                  string vCreater,
                  string vDeliveryQty)
        {
            this._ID = vID;

            this._MPSNo = vMPSNo;
            this._WorkOrderNo = vWorkOrderNo;
            this._ProductNo = vProductNo;
            this._MachineNo = vMachineNo;
            this._MouldNo = vMouldNo;
            this._Num = vNum;
            this._DueDate = vDueDate;
            this._SchStartDate = vSchStartDate;
            this._SchEndDate = vSchEndDate;
            this._Status = vStatus;

            this._RearrangeFlag = vRearrangeFlag;
            this._ErrMsg = vErrMsg;
            this._CreateDate = vCreateDate;
            this._Checker = vChecker;
            this._Creater = vCreater;
            this._DeliveryQty = vDeliveryQty;
        }
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }


        public string DeliveryQty
        {
            get { return _DeliveryQty; }
            set { _DeliveryQty = value; }
        }
        public string MPSNo
        {
            get { return _MPSNo; }
            set { _MPSNo = value; }
        }

        public string WorkOrderNo
        {
            get { return _WorkOrderNo; }
            set { _WorkOrderNo = value; }
        }

        public string ProductNo
        {
            get { return _ProductNo; }
            set { _ProductNo = value; }
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

        public string Num
        {
            get { return _Num; }
            set { _Num = value; }
        }

        public string DueDate
        {
            get { return _DueDate; }
            set { _DueDate = value; }
        }

        public string SchStartDate
        {
            get { return _SchStartDate; }
            set { _SchStartDate = value; }
        }

        public string SchEndDate
        {
            get { return _SchEndDate; }
            set { _SchEndDate = value; }
        }

        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        //```````````````````````````````````````
        public string RearrangeFlag
        {
            get { return _RearrangeFlag; }
            set { _RearrangeFlag = value; }
        }

        public string ErrMsg
        {
            get { return _ErrMsg; }
            set { _ErrMsg = value; }
        }
        public string CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }

        public string Checker
        {
            get { return _Checker; }
            set { _Checker = value; }
        }

        public string Creater
        {
            get { return _Creater; }
            set { _Creater = value; }
        }
    }
}
