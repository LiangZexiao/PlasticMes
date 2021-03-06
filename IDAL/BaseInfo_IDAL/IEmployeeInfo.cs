﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Admin.Model.BaseInfo_MDL;
using System.Data;

namespace Admin.IDAL.BaseInfo_IDAL
{
    public interface IEmployeeInfo
    {
        IList<Employee_MDL> selectEmployee();
        IList<Employee_MDL> selectEmployee(int id);
        IList<Employee_MDL> selectEmployee(int _ID, string colname, string coltext);
        DataTable selectEmployee(string colname, string coltext);
        IList<Employee_MDL> selectEmployee(int _ID, string colname, string coltext,bool flag);
        IList<Employee_MDL> existsEmployee(string _EmployeeID);
        int ChangeEmployee(Employee_MDL obj, string IU);
        void deleteEmployee(int _ID);
        void cancelEmployee(ArrayList _IDList);
    }
}
