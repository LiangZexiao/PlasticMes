using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.Adminis_MDL;

namespace Admin.IDAL.Adminis_IDAL
{
    public interface IDepartment
    {
        IList<Department_MDL> selectDepartment();
        IList<Department_MDL> selectDepartment(int id);
        IList<Department_MDL> selectDepartment(int _ID, string colname, string coltext);
        IList<Department_MDL> existsDepartment(string _DeptID);

        void ChangeDepartment(Department_MDL obj, string IU);
        void deleteDepartment(int _ID);
        void cancelDepartment(ArrayList _IDList);
    }
}
