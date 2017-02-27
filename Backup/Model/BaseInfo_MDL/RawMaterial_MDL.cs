using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model.BaseInfo_MDL
{
   public class RawMaterial_MDL
    {
       private int _ID;

       private string _RawNo;

       private string _RawName;

       private string _RawModel;

       private string _RawBrand;

       private float _Spec;

       private string _RawColor;

       private string _Memo;

       public RawMaterial_MDL() { }

       public RawMaterial_MDL(string vRawNo)
       {
           this._RawNo = vRawNo;
       }

       public RawMaterial_MDL(int vID,string vRawNo,string vRawName,string vRawModel,string vRawBrand,float vSpec,string vRawColor,string vMemo )
       {
           this._ID = vID;
           this._RawNo = vRawNo;
           this._RawName = vRawName;
           this._RawModel=vRawModel;
           this._RawBrand=vRawBrand;
           this._Spec=vSpec;
           this._RawColor=vRawColor;
           this._Memo = vMemo;
       }


       public int ID
       {

           get { return _ID; }
           set { _ID = value; }
       }

       public string RawNo
       {
           get { return _RawNo; }
           set { _RawNo = value; }
       }

       public string RawName
       {
           get { return _RawName; }
           set { _RawName = value; }
       }

       public string RawModel
       {
           get { return _RawModel; }
           set { _RawModel = value; }
       }

       public string RawBrand
       {
           get { return _RawBrand; }
           set { _RawBrand = value; }
       }

       public float Spec
       {

           get { return _Spec; }
           set { _Spec = value; }
       }

       public string RawColor
       {
           get { return _RawColor; }
           set { _RawColor = value; }
       }

       public string Memo
       {
           get { return _Memo; }
           set { _Memo = value; }
       }


    }
}
