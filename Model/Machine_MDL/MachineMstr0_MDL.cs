using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.Machine_MDL
{
    public class MachineMstr0_MDL:LikeQuery
    {
        private ArrayList _IDList;
        private int _ID;
        private string _Machine_Code;
        private string _Machine_NameCH;
        private string _Machine_NameEN;
        private string _Machine_Type;
        private string _Machine_Manufacturer;
        private string _Machine_Model;
        private string _Machine_Brand;
        private string _Machine_PurchaseDate;
        private string _Machine_MadeDate;
        private string _Machine_Power;

        private string _Machine_MouldCapacity;
        private string _Machine_MinLockPower;
        private string _Machine_MaxLockPower;
        private string _Machine_ShotQty;
        private string _Machine_MaintainCycle;
        private string _Machine_Price;
        private string _Machine_RentCost;
        private string _Machine_SeatCode;
        private string _Machine_MaterialChgTime;
        private string _Machine_MaterialChgCost;

        private string _Machine_MaterialChgAmt;
        private byte[] _Machine_Photo;
        private object _Machine_PhotoType;
        private string _Bearings;
        private string _ScrewDiameter;
        private string _InjectionPress;
        private string _MachineVolume;
        private string _SerialNo;
        private string _TackOut;
        private string _Screw;      

        private string _Condition;
        private string _MinMouldThick;
        private string _MaxMouldThick;
        private string _LoadMouldMaxLenght;
        private string _LoadMouldMaxWidth;
        private string _PushDistance;
        private string _PushStress;
        private string _OpenMouldDistance;

        private string _Robort;
        private string _Note;

        public MachineMstr0_MDL(){}
        public MachineMstr0_MDL(ArrayList pIDList){this._IDList = pIDList;}
        public MachineMstr0_MDL(int pID,           

           string pMachine_Code,
           string pMachine_NameCH,
           string pMachine_NameEN,
           string pMachine_Type,
           string pMachine_Manufacturer,
           string pMachine_Model,
           string pMachine_Brand,
           string pMachine_PurchaseDate,
           string pMachine_MadeDate,
           string pMachine_Power,

           string pMachine_MouldCapacity,
           string pMachine_MinLockPower,
           string pMachine_MaxLockPower,
           string pMachine_ShotQty,
           string pMachine_MaintainCycle,
           string pMachine_Price,
           string pMachine_RentCost,
           string pMachine_SeatCode,
           string pMachine_MaterialChgTime,
           string pMachine_MaterialChgCost,

          string pMachine_MaterialChgAmt,
          byte[] pMachine_Photo,
          object pMachine_PhotoType,
          string pBearings,
          string pScrewDiameter,
          string pInjectionPress,
          string pMachineVolume,
          string pSerialNo,
          string pTackOut,
          string pScrew,          

          string pCondition,            
          string pMinMouldThick,
          string pMaxMouldThick,
          string pLoadMouldMaxLenght,
          string pLoadMouldMaxWidth,
          string pPushDistance,
          string pPushStress,
          string pOpenMouldDistance,
          string pRobort,
          string pNote)
        {
            this._ID = pID;

            this._Machine_Code = pMachine_Code;
            this._Machine_NameCH = pMachine_NameCH;
            this._Machine_NameEN = pMachine_NameEN;
            this._Machine_Type = pMachine_Type;
            this._Machine_Manufacturer = pMachine_Manufacturer;
            this._Machine_Model = pMachine_Model;
            this._Machine_Brand = pMachine_Brand;
            this._Machine_PurchaseDate = pMachine_PurchaseDate;
            this._Machine_MadeDate = pMachine_MadeDate;
            this._Machine_Power = pMachine_Power;

            this._Machine_MouldCapacity = pMachine_MouldCapacity;
            this._Machine_MinLockPower = pMachine_MinLockPower;
            this._Machine_MaxLockPower = pMachine_MaxLockPower;
            this._Machine_ShotQty = pMachine_ShotQty;
            this._Machine_MaintainCycle = pMachine_MaintainCycle;
            this._Machine_Price = pMachine_Price;
            this._Machine_RentCost = pMachine_RentCost;
            this._Machine_SeatCode = pMachine_SeatCode;
            this._Machine_MaterialChgTime = pMachine_MaterialChgTime;
            this._Machine_MaterialChgCost = pMachine_MaterialChgCost;

            this._Machine_MaterialChgAmt = pMachine_MaterialChgAmt;
            this._Machine_Photo = pMachine_Photo;
            this._Machine_PhotoType = pMachine_PhotoType;
            this._Bearings = pBearings;
            this._ScrewDiameter = pScrewDiameter;
            this._InjectionPress = pInjectionPress;
            this._MachineVolume = pMachineVolume;
            this._SerialNo = pSerialNo;
            this._TackOut = pTackOut;
            this._Screw = pScrew;

            this._Condition = pCondition;
            this._MinMouldThick = pMinMouldThick;
            this._MaxMouldThick = pMaxMouldThick;
            this._LoadMouldMaxLenght = pLoadMouldMaxLenght;
            this._LoadMouldMaxWidth = pLoadMouldMaxWidth;
            this._PushDistance = pPushDistance;
            this._PushStress = pPushStress;
            this._OpenMouldDistance = pOpenMouldDistance;
            this._Robort = pRobort;
            this._Note = pNote;
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
        //```````````````````````````````````````
        public string Machine_Code
        {
            get { return _Machine_Code; }
            set { _Machine_Code = value; }
        }

        public string Machine_NameCH
        {
            get { return _Machine_NameCH; }
            set { _Machine_NameCH = value; }
        }

        public string Machine_NameEN
        {
            get { return _Machine_NameEN; }
            set { _Machine_NameEN = value; }
        }

        public string Machine_Type
        {
            get { return _Machine_Type; }
            set { _Machine_Type = value; }
        }

        public string Machine_Manufacturer
        {
            get { return _Machine_Manufacturer; }
            set { _Machine_Manufacturer = value; }
        }

        public string Machine_Model
        {
            get { return _Machine_Model; }
            set { _Machine_Model = value; }
        }

        public string Machine_Brand
        {
            get { return _Machine_Brand; }
            set { _Machine_Brand = value; }
        }

        public string Machine_PurchaseDate
        {
            get { return _Machine_PurchaseDate; }
            set { _Machine_PurchaseDate = value; }
        }

        public string Machine_MadeDate
        {
            get { return _Machine_MadeDate; }
            set { _Machine_MadeDate = value; }
        }

        public string Machine_Power
        {
            get { return _Machine_Power; }
            set { _Machine_Power = value; }
        }

        //```````````````````````````````````````
        public string Machine_MouldCapacity
        {
            get { return _Machine_MouldCapacity; }
            set { _Machine_MouldCapacity = value; }
        }

        public string Machine_MinLockPower
        {
            get { return _Machine_MinLockPower; }
            set { _Machine_MinLockPower = value; }
        }
        public string Machine_MaxLockPower
        {
            get { return _Machine_MaxLockPower; }
            set { _Machine_MaxLockPower = value; }
        }

        public string Machine_ShotQty
        {
            get { return _Machine_ShotQty; }
            set { _Machine_ShotQty = value; }
        }

        public string Machine_MaintainCycle
        {
            get { return _Machine_MaintainCycle; }
            set { _Machine_MaintainCycle = value; }
        }

        public string Machine_Price
        {
            get { return _Machine_Price; }
            set { _Machine_Price = value; }
        }

        public string Machine_RentCost
        {
            get { return _Machine_RentCost; }
            set { _Machine_RentCost = value; }
        }

        public string Machine_SeatCode
        {
            get { return _Machine_SeatCode; }
            set { _Machine_SeatCode = value; }
        }

        public string Machine_MaterialChgTime
        {
            get { return _Machine_MaterialChgTime; }
            set { _Machine_MaterialChgTime = value; }
        }

        public string Machine_MaterialChgCost
        {
            get { return _Machine_MaterialChgCost; }
            set { _Machine_MaterialChgCost = value; }
        }
        //```````````````````````````````````````
        public string Machine_MaterialChgAmt
        {
            get { return _Machine_MaterialChgAmt; }
            set { _Machine_MaterialChgAmt = value; }
        }

        public byte[] Machine_Photo
        {
            get { return _Machine_Photo; }
            set { _Machine_Photo = value; }
        }

        public object Machine_PhotoType
        {
            get { return _Machine_PhotoType; }
            set { _Machine_PhotoType = value; }
        }

        public string Bearings
        {
            get { return _Bearings; }
            set { _Bearings = value; }
        }

        public string ScrewDiameter
        {
            get { return _ScrewDiameter; }
            set { _ScrewDiameter = value; }
        }

        public string InjectionPress
        {
            get { return _InjectionPress; }
            set { _InjectionPress = value; }
        }

        public string MachineVolume
        {
            get { return _MachineVolume; }
            set { _MachineVolume = value; }
        }

        public string SerialNo
        {
            get { return _SerialNo; }
            set { _SerialNo = value; }
        }

        public string TackOut
        {
            get { return _TackOut; }
            set { _TackOut = value; }
        }
               
        public string Screw
        {
            get { return _Screw; }
            set { _Screw = value; }
        }

        public string Robort
        {
            get { return _Robort; }
            set { _Robort = value; }
        }
        //```````````````````````````````````````
        public string Condition
        {
            get { return _Condition; }
            set { _Condition = value; }
        }

        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }
    }
}
