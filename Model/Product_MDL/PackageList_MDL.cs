using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Product_MDL
{
    public class PackageList_MDL : LikeQuery
    {
        private string _ID;
        private ArrayList v_IDs;
        private string _CompanyName;
        private string _PN;
        private string _ProdNO;
        private string _ProdName;
        private string _NumOfBox;
        private string _FileNO;
        private string _PackageNO;
        private string _PackageModel;
        private string _GlueBoxNO;
        private string _GlueBoxModel;

        private string _GluePackageModel;
        private string _GluePackageNum;
        private string _LongKnifeModel;
        private string _LongKnifeNum;
        private string _ShortKnifeModel;
        private string _ShortKnifeNum;
        private string _BlockOffCardModel;
        private string _BlockOffCardNum;
        private string _FlatCardModel;
        private string _FlatCardNum;

        private string _AbsorbPlasticModel;
        private string _AbsorbPlasticNum;
        private string _Notice;
        private byte[] _PagkagePhoto;
        private object _PagkagePhotoType;
        private string _PackageType;
        private string _CellLineNum;
        private string _LineNum;
        private string _CellPCS;
        private string _BoxNum;
        private string _TotalPCS;

        private string _CellBlockOff;
        private string _FlatCard;
        private string _NewVer;
        private string _ChangedVer;
        private string _EffectDate;
        private string _NewOldChangedFlag;
        private string _NewOldVer;
        private string _OldType;
        private string _OldType_BoxNum;
        private string _OldType_Num;

        private string _OldType_CellNum;
        private string _OldType_BoxPCS;
        private string _OldType_GlueModel;
        private string _OldType_Other;
        private string _TableMaker;
        private string _Checker;
        private string _EffectedDate;
        private string _QCChecker;
        private string _VerNO;
        private string _TableNO;

        public PackageList_MDL() { }
        public PackageList_MDL(bool isFlag, string coltext)
        {
            if (isFlag) this._ID = coltext;
            else this._ProdNO = coltext;
        }

        public PackageList_MDL(ArrayList vIDs) { this.v_IDs = vIDs; }
        public PackageList_MDL(
              string vCompanyName,
              string vPN,
              string vProdNO,
              string vProdName,
              string vNumOfBox,
              string vFileNO,
              string vPackageNO,
              string vPackageModel,
              string vGlueBoxNO,
              string vGlueBoxModel,

              string vGluePackageModel,
              string vGluePackageNum,
              string vLongKnifeModel,
              string vLongKnifeNum,
              string vShortKnifeModel,
              string vShortKnifeNum,
              string vBlockOffCardModel,
              string vBlockOffCardNum,
              string vFlatCardModel,
              string vFlatCardNum,

              string vAbsorbPlasticModel,
              string vAbsorbPlasticNum,
              string vNotice,
              byte[] vPagkagePhoto,
              object vPagkagePhotoType,
              string vPackageType,
              string vCellLineNum,
              string vLineNum,
              string vCellPCS,
              string vBoxNum,
              string vTotalPCS,

              string vCellBlockOff,
              string vFlatCard,
              string vNewVer,
              string vChangedVer,
              string vEffectDate,
              string vNewOldChangedFlag,
              string vNewOldVer,
              string vOldType,
              string vOldType_BoxNum,
              string vOldType_Num,

              string vOldType_CellNum,
              string vOldType_BoxPCS,
              string vOldType_GlueModel,
              string vOldType_Other,
              string vTableMaker,
              string vChecker,
              string vEffectedDate,
              string vQCChecker,
              string vVerNO,
              string vTableNO
            )
        {
            this._CompanyName = vCompanyName;
            this._PN = vPN;
            this._ProdNO = vProdNO;
            this._ProdName = vProdName;
            this._NumOfBox = vNumOfBox;
            this._FileNO = vFileNO;
            this._PackageNO = vPackageNO;
            this._PackageModel = vPackageModel;
            this._GlueBoxNO = vGlueBoxNO;
            this._GlueBoxModel = vGlueBoxModel;

            this._GluePackageModel = vGluePackageModel;
            this._GluePackageNum = vGluePackageNum;
            this._LongKnifeModel = vLongKnifeModel;
            this._LongKnifeNum = vLongKnifeNum;
            this._ShortKnifeModel = vShortKnifeModel;
            this._ShortKnifeNum = vShortKnifeNum;
            this._BlockOffCardModel = vBlockOffCardModel;
            this._BlockOffCardNum = vBlockOffCardNum;
            this._FlatCardModel = vFlatCardModel;
            this._FlatCardNum = vFlatCardNum;

            this._AbsorbPlasticModel = vAbsorbPlasticModel;
            this._AbsorbPlasticNum = vAbsorbPlasticNum;
            this._Notice = vNotice;
            this._PagkagePhoto = vPagkagePhoto;
            this._PagkagePhotoType = vPagkagePhotoType;
            this._PackageType = vPackageType;
            this._CellLineNum = vCellLineNum;
            this._LineNum = vLineNum;
            this._CellPCS = vCellPCS;
            this._BoxNum = vBoxNum;
            this._TotalPCS = vTotalPCS;

            this._CellBlockOff = vCellBlockOff;
            this._FlatCard = vFlatCard;
            this._NewVer = vNewVer;
            this._ChangedVer = vChangedVer;
            this._EffectDate = vEffectDate;
            this._NewOldChangedFlag = vNewOldChangedFlag;
            this._NewOldVer = vNewOldVer;
            this._OldType = vOldType;
            this._OldType_BoxNum = vOldType_BoxNum;
            this._OldType_Num = vOldType_Num;

            this._OldType_CellNum = vOldType_CellNum;
            this._OldType_BoxPCS = vOldType_BoxPCS;
            this._OldType_GlueModel = vOldType_GlueModel;
            this._OldType_Other = vOldType_Other;
            this._TableMaker = vTableMaker;
            this._Checker = vChecker;
            this._EffectedDate = vEffectedDate;
            this._QCChecker = vQCChecker;
            this._VerNO = vVerNO;
            this._TableNO = vTableNO;
        }
        public PackageList_MDL(string vID,
               string vCompanyName,
               string vPN,
               string vProdNO,
               string vProdName,
               string vNumOfBox,
               string vFileNO,
               string vPackageNO,
               string vPackageModel,
               string vGlueBoxNO,
               string vGlueBoxModel,
               string vGluePackageModel,
               string vGluePackageNum,
               string vLongKnifeModel,
               string vLongKnifeNum,
               string vShortKnifeModel,
               string vShortKnifeNum,
               string vBlockOffCardModel,
               string vBlockOffCardNum,
               string vFlatCardModel,
               string vFlatCardNum,
               string vAbsorbPlasticModel,
               string vAbsorbPlasticNum,
               string vNotice,
               byte[] vPagkagePhoto,
               object vPagkagePhotoType,
               string vPackageType,
               string vCellLineNum,
               string vLineNum,
               string vCellPCS,
               string vBoxNum,
               string vTotalPCS,
               string vCellBlockOff,
               string vFlatCard,
               string vNewVer,
               string vChangedVer,
               string vEffectDate,
               string vNewOldChangedFlag,
               string vNewOldVer,
               string vOldType,
               string vOldType_BoxNum,
               string vOldType_Num,
               string vOldType_CellNum,
               string vOldType_BoxPCS,
               string vOldType_GlueModel,
               string vOldType_Other,
               string vTableMaker,
               string vChecker,
               string vEffectedDate,
               string vQCChecker,
               string vVerNO,
               string vTableNO
            )
        {
            this._ID = vID;

            this._CompanyName = vCompanyName;
            this._PN = vPN;
            this._ProdNO = vProdNO;
            this._ProdName = vProdName;
            this._NumOfBox = vNumOfBox;
            this._FileNO = vFileNO;
            this._PackageNO = vPackageNO;
            this._PackageModel = vPackageModel;
            this._GlueBoxNO = vGlueBoxNO;
            this._GlueBoxModel = vGlueBoxModel;

            this._GluePackageModel = vGluePackageModel;
            this._GluePackageNum = vGluePackageNum;
            this._LongKnifeModel = vLongKnifeModel;
            this._LongKnifeNum = vLongKnifeNum;
            this._ShortKnifeModel = vShortKnifeModel;
            this._ShortKnifeNum = vShortKnifeNum;
            this._BlockOffCardModel = vBlockOffCardModel;
            this._BlockOffCardNum = vBlockOffCardNum;
            this._FlatCardModel = vFlatCardModel;
            this._FlatCardNum = vFlatCardNum;

            this._AbsorbPlasticModel = vAbsorbPlasticModel;
            this._AbsorbPlasticNum = vAbsorbPlasticNum;
            this._Notice = vNotice;
            this._PagkagePhoto = vPagkagePhoto;
            this._PagkagePhotoType = vPagkagePhotoType;
            this._PackageType = vPackageType;
            this._CellLineNum = vCellLineNum;
            this._LineNum = vLineNum;
            this._CellPCS = vCellPCS;
            this._BoxNum = vBoxNum;
            this._TotalPCS = vTotalPCS;

            this._CellBlockOff = vCellBlockOff;
            this._FlatCard = vFlatCard;
            this._NewVer = vNewVer;
            this._ChangedVer = vChangedVer;
            this._EffectDate = vEffectDate;
            this._NewOldChangedFlag = vNewOldChangedFlag;
            this._NewOldVer = vNewOldVer;
            this._OldType = vOldType;
            this._OldType_BoxNum = vOldType_BoxNum;
            this._OldType_Num = vOldType_Num;

            this._OldType_CellNum = vOldType_CellNum;
            this._OldType_BoxPCS = vOldType_BoxPCS;
            this._OldType_GlueModel = vOldType_GlueModel;
            this._OldType_Other = vOldType_Other;
            this._TableMaker = vTableMaker;
            this._Checker = vChecker;
            this._EffectedDate = vEffectedDate;
            this._QCChecker = vQCChecker;
            this._VerNO = vVerNO;
            this._TableNO = vTableNO;
        }
        public PackageList_MDL(string likefieldname, string likefieldvalue)
        {
            this.LikeFieldName = likefieldname;
            this.LikeFieldText = likefieldvalue;
        }

        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public ArrayList IDs
        {
            get { return v_IDs; }
            set { v_IDs = value; }
        }

        public string CompanyName
        {
            get { return _CompanyName; }
            set { _CompanyName = value; }
        }

        public string PN
        {
            get { return _PN; }
            set { _PN = value; }
        }

        public string ProdNO
        {
            get { return _ProdNO; }
            set { _ProdNO = value; }
        }

        public string ProdName
        {
            get { return _ProdName; }
            set { _ProdName = value; }
        }

        public string NumOfBox
        {
            get { return _NumOfBox; }
            set { _NumOfBox = value; }
        }

        public string FileNO
        {
            get { return _FileNO; }
            set { _FileNO = value; }
        }

        public string PackageNO
        {
            get { return _PackageNO; }
            set { _PackageNO = value; }
        }

        public string PackageModel
        {
            get { return _PackageModel; }
            set { _PackageModel = value; }
        }

        public string GlueBoxNO
        {
            get { return _GlueBoxNO; }
            set { _GlueBoxNO = value; }
        }


        public string GlueBoxModel
        {
            get { return _GlueBoxModel; }
            set { _GlueBoxModel = value; }
        }

        //```````````````````````````````````````
        public string GluePackageModel
        {
            get { return _GluePackageModel; }
            set { _GluePackageModel = value; }
        }

        public string GluePackageNum
        {
            get { return _GluePackageNum; }
            set { _GluePackageNum = value; }
        }

        public string LongKnifeModel
        {
            get { return _LongKnifeModel; }
            set { _LongKnifeModel = value; }
        }

        public string LongKnifeNum
        {
            get { return _LongKnifeNum; }
            set { _LongKnifeNum = value; }
        }

        public string ShortKnifeModel
        {
            get { return _ShortKnifeModel; }
            set { _ShortKnifeModel = value; }
        }

        public string ShortKnifeNum
        {
            get { return _ShortKnifeNum; }
            set { _ShortKnifeNum = value; }
        }

        public string BlockOffCardModel
        {
            get { return _BlockOffCardModel; }
            set { _BlockOffCardModel = value; }
        }

        public string BlockOffCardNum
        {
            get { return _BlockOffCardNum; }
            set { _BlockOffCardNum = value; }
        }

        public string FlatCardModel
        {
            get { return _FlatCardModel; }
            set { _FlatCardModel = value; }
        }

        public string FlatCardNum
        {
            get { return _FlatCardNum; }
            set { _FlatCardNum = value; }
        }

        public string AbsorbPlasticModel
        {
            get { return _AbsorbPlasticModel; }
            set { _AbsorbPlasticModel = value; }
        }

        public string AbsorbPlasticNum
        {
            get { return _AbsorbPlasticNum; }
            set { _AbsorbPlasticNum = value; }
        }

        public string Notice
        {
            get { return _Notice; }
            set { _Notice = value; }
        }

        public byte[] PagkagePhoto
        {
            get { return _PagkagePhoto; }
            set { _PagkagePhoto = value; }
        }

        public object PagkagePhotoType
        {
            get { return _PagkagePhotoType; }
            set { _PagkagePhotoType = value; }
        }

        public string PackageType
        {
            get { return _PackageType; }
            set { _PackageType = value; }
        }

        public string CellLineNum
        {
            get { return _CellLineNum; }
            set { _CellLineNum = value; }
        }

        public string LineNum
        {
            get { return _LineNum; }
            set { _LineNum = value; }
        }

        public string CellPCS
        {
            get { return _CellPCS; }
            set { _CellPCS = value; }
        }

        public string BoxNum
        {
            get { return _BoxNum; }
            set { _BoxNum = value; }
        }

        //```````````````````````````````````````
        public string TotalPCS
        {
            get { return _TotalPCS; }
            set { _TotalPCS = value; }
        }

        public string CellBlockOff
        {
            get { return _CellBlockOff; }
            set { _CellBlockOff = value; }
        }

        public string FlatCard
        {
            get { return _FlatCard; }
            set { _FlatCard = value; }
        }

        public string NewVer
        {
            get { return _NewVer; }
            set { _NewVer = value; }
        }

        public string ChangedVer
        {
            get { return _ChangedVer; }
            set { _ChangedVer = value; }
        }

        public string EffectDate
        {
            get { return _EffectDate; }
            set { _EffectDate = value; }
        }

        public string NewOldChangedFlag
        {
            get { return _NewOldChangedFlag; }
            set { _NewOldChangedFlag = value; }
        }

        public string NewOldVer
        {
            get { return _NewOldVer; }
            set { _NewOldVer = value; }
        }

        public string OldType
        {
            get { return _OldType; }
            set { _OldType = value; }
        }

        public string OldType_BoxNum
        {
            get { return _OldType_BoxNum; }
            set { _OldType_BoxNum = value; }
        }

        public string OldType_Num
        {
            get { return _OldType_Num; }
            set { _OldType_Num = value; }
        }

        public string OldType_CellNum
        {
            get { return _OldType_CellNum; }
            set { _OldType_CellNum = value; }
        }

        public string OldType_BoxPCS
        {
            get { return _OldType_BoxPCS; }
            set { _OldType_BoxPCS = value; }
        }

        public string OldType_GlueModel
        {
            get { return _OldType_GlueModel; }
            set { _OldType_GlueModel = value; }
        }

        public string OldType_Other
        {
            get { return _OldType_Other; }
            set { _OldType_Other = value; }
        }

        public string TableMaker
        {
            get { return _TableMaker; }
            set { _TableMaker = value; }
        }

        public string Checker
        {
            get { return _Checker; }
            set { _Checker = value; }
        }

        public string EffectedDate
        {
            get { return _EffectedDate; }
            set { _EffectedDate = value; }
        }

        public string QCChecker
        {
            get { return _QCChecker; }
            set { _QCChecker = value; }
        }

        public string VerNO
        {
            get { return _VerNO; }
            set { _VerNO = value; }
        }

        public string TableNO
        {
            get { return _TableNO; }
            set { _TableNO = value; }
        }
    }
}
