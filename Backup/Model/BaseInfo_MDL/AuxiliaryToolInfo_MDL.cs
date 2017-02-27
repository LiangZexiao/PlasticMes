using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.BaseInfo_MDL
{
    public  class AuxiliaryToolInfo_MDL
    {
        private string _iD;

        private string _deviceCode;

        private string _deviceDesc;

        private string _assetCode;

        private string _madeDate;

        private string _manufacturers;

        private string _power;

        private byte[] _deviceImg;

        private string _description;

        private string _remark;
        private string _MouldNo;
        private string _MachineNo;

        public AuxiliaryToolInfo_MDL() { }

        public AuxiliaryToolInfo_MDL(string vID, string vDeviceCode, string vDeviceDesc, string vAssetCode
                 , string vMadeDate, string vManufacturers, string vPower, byte[] vDeviceImg, string vDescription
                 , string vRemark,string vMouldNo,string vMachineNo)
        {
            this._iD = vID;
            this._deviceCode = vDeviceCode;
            this._deviceDesc = vDeviceDesc;
            this._assetCode = vAssetCode;
            this._madeDate = vMadeDate;
            this._manufacturers = vManufacturers;
            this._power = vPower;
            this._deviceImg = vDeviceImg;
            this._description = vDescription;
            this._remark = vRemark;
            this._MachineNo = vMachineNo;
            this._MouldNo = vMouldNo;
        }
       
        public string ID
        {
            get
            {
                return this._iD;
            }
            set
            {
                this._iD = value;
            }
        }
 
        public string DeviceCode
        {
            get
            {
                return this._deviceCode;
            }
            set
            {
                this._deviceCode = value;
            }
        }

       
        public string DeviceDesc
        {
            get
            {
                return this._deviceDesc;
            }
            set
            {
                this._deviceDesc = value;
            }
        }

       
        public string AssetCode
        {
            get
            {
                return this._assetCode;
            }
            set
            {
                this._assetCode = value;
            }
        }

       
        public string MadeDate
        {
            get
            {
                return this._madeDate;
            }
            set
            {
                this._madeDate = value;
            }
        }

       
        public string Manufacturers
        {
            get
            {
                return this._manufacturers;
            }
            set
            {
                this._manufacturers = value;
            }
        }

       
        public string Power
        {
            get
            {
                return this._power;
            }
            set
            {
                this._power = value;
            }
        }

       
        public byte[] DeviceImg
        {
            get
            {
                return this._deviceImg;
            }
            set
            {
                this._deviceImg = value;
            }
        }

       
        public string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
            }
        }

       
        public string Remark
        {
            get
            {
                return this._remark;
            }
            set
            {
                this._remark = value;
            }
        }
        public string MouldNo
        {
            get { return this._MouldNo; }
            set { this._MouldNo = value; }
        }
        public string MachineNo
        {
            get { return this._MachineNo; }
            set { this._MachineNo = value; }
        }
    }
}
