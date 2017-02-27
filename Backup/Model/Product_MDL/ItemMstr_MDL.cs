using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Product_MDL
{
    public class ItemMstr_MDL
    {
        private int _ID;
        private string _Item_Code;
        private string _ProductRemark;
        private string _MouldCode;
        private string _ModeDesc;
        private string _Mould_SpecialFittingsNo;
        private string _InsertsDesc;
        private string _PackageNum;
        private string _Item_Weight;
        private string _Item_ActualGrossWgt;
        private string _Item_WaterGapScale;
        private string _Item_Color;
        private string _CustomerName;
        private string _MaterialCode;
        private string _MaterialDesc;
        private string _PowderCode;
        private string _AuxiliaryMaterialName;
        private string _AuxiliaryMaterialNum;
        private string _OutsideAssociation;
        private string _MachineAssembly;
        private byte[] _ProdPhoto;
        private string _StandEmployee;
        private string _Processes;

        private string _VerNo;
        private string _Creater;
        private string _CreateDate;
        private string _ModiHistoryContent;
        private string _Remark;

        private int _Percentage;

        public ItemMstr_MDL() { }
        public ItemMstr_MDL(string vItem_Code) { this._Item_Code = vItem_Code; }
        public ItemMstr_MDL(string vItem_Code, string vItem_UOM)
        {
            this._Item_Code = vItem_Code;
            //this._Item_UOM = vItem_UOM;
        }
        public ItemMstr_MDL(int vID, string vItem_Code, string vProductRemark, string vMouldCode, string vModeDesc, string vMould_SpecialFittingsNo,
                            string vInsertsDesc, string vPackageNum, string vItem_Weight, string vItem_ActualGrossWgt, string vItem_WaterGapScale,
                            string vItem_Color, string vCustomerName, string vMaterialCode, string vMaterialDesc, string vPowderCode, string vAuxiliaryMaterialName,
                            string vAuxiliaryMaterialNum, string vOutsideAssociation, string vMachineAssembly, byte[] vProdPhoto,string vStandEmployee ,string vProcesses,string vVerNo, string vCreater, string vCreateDate,
                            string vModiHistoryContent, string vRemark)
        {
            this.ID = vID;
            this.Item_Code = vItem_Code;
            this.ProductRemark = vProductRemark;
            this.MouldCode = vMouldCode;
            this.ModeDesc = vModeDesc;

            this.Mould_SpecialFittingsNo = vMould_SpecialFittingsNo;
            this.InsertsDesc = vInsertsDesc;
            this.PackageNum = vPackageNum;
            this.Item_Weight = vItem_Weight;
            this.Item_ActualGrossWgt = vItem_ActualGrossWgt;

            this.Item_WaterGapScale = vItem_WaterGapScale;
            this.Item_Color = vItem_Color;
            this.CustomerName = vCustomerName;
            this.MaterialCode = vMaterialCode;
            this.MaterialDesc = vMaterialDesc;

            this.PowderCode = vPowderCode;
            this.AuxiliaryMaterialName = vAuxiliaryMaterialName;
            this.AuxiliaryMaterialNum = vAuxiliaryMaterialNum;
            this.OutsideAssociation = vOutsideAssociation;
            this.MachineAssembly = vMachineAssembly;

            this.ProdPhoto = vProdPhoto;
            this._StandEmployee = vStandEmployee;
            this._Processes = vProcesses;
            this.VerNo = vVerNo;
            this.Creater = vCreater;
            this.CreateDate = vCreateDate;
            this.ModiHistoryContent = vModiHistoryContent;
            this.Remark = vRemark;
        }
        public ItemMstr_MDL(int vID, string vItem_Code, string vMouldCode, string vModeDesc, string vMaterialCode, string vMaterialDesc, string vCreateDate, int vPercentage)
        {
            this.ID = vID;
            this.Item_Code = vItem_Code;
            this.MouldCode = vMouldCode;
            this.ModeDesc = vModeDesc;

           
            this.MaterialCode = vMaterialCode;
            this.MaterialDesc = vMaterialDesc;
            this.CreateDate = vCreateDate;

            this.Percentage = vPercentage;
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string Item_Code
        {
            get { return _Item_Code; }
            set { _Item_Code = value; }
        }
       
        public string ProductRemark
        {
            get { return _ProductRemark; }
            set { _ProductRemark = value; }
        }

        public string MouldCode
        {
            get { return _MouldCode; }
            set { _MouldCode = value; }
        }

        public string ModeDesc
        {
            get { return _ModeDesc; }
            set { _ModeDesc = value; }
        }

        public string Mould_SpecialFittingsNo
        {
            get { return _Mould_SpecialFittingsNo; }
            set { _Mould_SpecialFittingsNo = value; }
        }

        public string InsertsDesc
        {
            get { return _InsertsDesc; }
            set { _InsertsDesc = value; }
        }

        public string PackageNum
        {
            get { return _PackageNum; }
            set { _PackageNum = value; }
        }

        public string Item_Weight
        {
            get { return _Item_Weight; }
            set { _Item_Weight = value; }
        }

        public string Item_ActualGrossWgt
        {
            get { return _Item_ActualGrossWgt; }
            set { _Item_ActualGrossWgt = value; }
        }

        public string Item_WaterGapScale
        {
            get { return _Item_WaterGapScale; }
            set { _Item_WaterGapScale = value; }
        }

        public string Item_Color
        {
            get { return _Item_Color; }
            set { _Item_Color = value; }
        }

        public string CustomerName
        {
            get { return _CustomerName; }
            set { _CustomerName = value; }
        }

        public string MaterialCode
        {
            get { return _MaterialCode; }
            set { _MaterialCode = value; }
        }

        public string MaterialDesc
        {
            get { return _MaterialDesc; }
            set { _MaterialDesc = value; }
        }

        public string PowderCode
        {
            get { return _PowderCode; }
            set { _PowderCode = value; }
        }

        public string AuxiliaryMaterialName
        {
            get { return _AuxiliaryMaterialName; }
            set { _AuxiliaryMaterialName = value; }
        }

        public string AuxiliaryMaterialNum
        {
            get { return _AuxiliaryMaterialNum; }
            set { _AuxiliaryMaterialNum = value; }
        }

        public string OutsideAssociation
        {
            get { return _OutsideAssociation; }
            set { _OutsideAssociation = value; }
        }

        public string MachineAssembly
        {
            get { return _MachineAssembly; }
            set { _MachineAssembly = value; }
        }

        public byte[] ProdPhoto
        {
            get { return _ProdPhoto; }
            set { _ProdPhoto = value; }
        }
        public string StandEmployee
        {
            get { return _StandEmployee; }
            set { _StandEmployee = value; }
        }
        public string Processes
        {
            get { return _Processes; }
            set { _Processes = value; }
        }
        

        public string VerNo
        {
            get { return _VerNo; }
            set { _VerNo = value; }
        }

        public string Creater
        {
            get { return _Creater; }
            set { _Creater = value; }
        }

        public string CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }

        public string ModiHistoryContent
        {
            get { return _ModiHistoryContent; }
            set { _ModiHistoryContent = value; }
        }

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        public int Percentage
        {
            get { return _Percentage; }
            set { _Percentage = value; }
        }

    }
}
