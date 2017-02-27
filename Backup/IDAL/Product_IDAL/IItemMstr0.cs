using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Product_MDL;

namespace Admin.IDAL.Product_IDAL
{
    public interface IItemMstr0
    {
        IList<ItemMstr0_MDL> selectItemMstr();
        IList<ItemMstr0_MDL> selectItemMstr(int _ID, string colname, string coltext);
        IList<ItemMstr0_MDL> existsItemMstr(string vItem_Code);
        void insertItemMstr(
             string vItem_Code, string vItem_NameCH, string vItem_NameEN, string vMouldNo, string vItem_UOM, string vItem_Color,
             string vItem_PreTime, string vItem_Weight, string vItem_WaterGapScale, string vItem_WaterGapWeight, string vItem_Ration,
             string vItem_PreBadness, string vItem_LossRate, string vItem_SetUpTime, string vItem_InjectCycle, string vItem_MinInjectCycle,
             string vItem_MaxInjectCycle, string vCreater, string vVerNo, string vCreateDate, string vRemark);

        void updateItemMstr(int vID,
             string vItem_Code, string vItem_NameCH, string vItem_NameEN, string vMouldNo, string vItem_UOM, string vItem_Color,
             string vItem_PreTime, string vItem_Weight, string vItem_WaterGapScale, string vItem_WaterGapWeight, string vItem_Ration,
             string vItem_PreBadness, string vItem_LossRate, string vItem_SetUpTime, string vItem_InjectCycle, string vItem_MinInjectCycle,
             string vItem_MaxInjectCycle, string vCreater, string vVerNo, string vCreateDate, string vRemark);

        void deleteItemMstr(int _id);
        void cancelItemMstr(ArrayList _idlist);
    }
}
