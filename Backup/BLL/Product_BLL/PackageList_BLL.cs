using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Product_MDL;
using Admin.SQLServerDAL.Product_DAL;

namespace Admin.BLL.Product_BLL
{
    public class PackageList_BLL
    {
        PackageList_DAL dalPackageList = new PackageList_DAL();

        public IList<PackageList_MDL> selectPackageList(int id, string colname, string coltext)
        {
            return dalPackageList.selectPackageList(id, colname, coltext);
        }
        //public DataTable selectPackageList(PackageList_MDL dboPackageList_MDL)
        //{
        //    return dalPackageList.selectPackageList(dboPackageList_MDL);
        //}

        //public DataTable getPackageListSglRow(PackageList_MDL dboPackageList_MDL)
        //{
        //    return dalPackageList.getPackageListSglRow(dboPackageList_MDL);
        //}

        //public int insertPackageList(PackageList_MDL dboPackageList_MDL)
        //{
        //    return dalPackageList.insertPackageList(dboPackageList_MDL);
        //}

        //public int updatePackageList(PackageList_MDL dboPackageList_MDL)
        //{
        //    return dalPackageList.updatePackageList(dboPackageList_MDL);
        //}

        //public int deletePackageList(PackageList_MDL dboPackageList_MDL)
        //{
        //    return dalPackageList.deletePackageList(dboPackageList_MDL);
        //}

        //public int cancelPackageList(PackageList_MDL dboPackageList_MDL)
        //{
        //    return dalPackageList.cancelPackageList(dboPackageList_MDL);
        //}

        //public PackageList_MDL choosePackageList(PackageList_MDL dboPackageList_MDL)
        //{
        //    return dalPackageList.choosePackageList(dboPackageList_MDL);
        //}
    }
}
