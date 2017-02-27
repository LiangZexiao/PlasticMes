using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Product_MDL;

namespace Admin.IDAL.BaseInfo_IDAL
{
    public interface IItemMstr
    {
        //IList<ItemMstr_JH_MDL> selectItemMstr();

        IList<ItemMstr_MDL> selectItemMstr(int _ID, string colname, string coltext);
        IList<ItemMstr_MDL> selectItemMstrDetail(int id, string colname, string coltext, string colname2, string coltxt2);
        IList<ItemMstr_MDL> existsItemMstr(string vItem_Code);
        int ChangeItemMstr(ItemMstr_MDL obj, string IU); 
        int ChangeItemMstrDetail(ItemMstr_MDL obj, string IU);
        int cancelItemMstr(ArrayList _idlist);
        int cancelItemMstrDetail(string itemcode);
       
    }
}
