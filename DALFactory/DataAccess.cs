using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Reflection;

using Admin.IDAL.Adminis_IDAL;
using Admin.IDAL.BaseInfo_IDAL;
using Admin.IDAL.Collect_IDAL;
using Admin.IDAL.Machine_IDAL;
using Admin.IDAL.Maintain_IDAL;
using Admin.IDAL.Monitor_IDAL;
using Admin.IDAL.Product_IDAL;
using Admin.IDAL.Quality_IDAL;

namespace Admin.DALFactory
{
    public sealed class DataAccess
    {
        private static readonly string path = ConfigurationManager.AppSettings["WebDAL"];
        private DataAccess() { }
        public static IUserInfo selectUserInfo()
        {
            string RealPath = path + ".Adminis_DAL.UserInfo_DAL";
            return (IUserInfo)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static IDepartment selectDepartment()
        {
            string RealPath = path + ".Adminis_DAL.Department_DAL";
            return (IDepartment)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static ISysProgramInfo selectProgramInfo()
        {
            string RealPath = path + ".Adminis_DAL.SysProgramInfo_DAL";
            return (ISysProgramInfo)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static IUserProgramMap selectUserProgramMap()
        {
            string RealPath = path + ".Adminis_DAL.UserProgramMap_DAL";
            return (IUserProgramMap)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static IGroupProgramMap selectGroupProgramMap()
        {
            string RealPath = path + ".Adminis_DAL.GroupProgramMap_DAL";
            return (IGroupProgramMap)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static ISysClassInfo selectSysClassInfo()
        {
            string RealPath = path + ".Adminis_DAL.SysClassInfo_DAL";
            return (ISysClassInfo)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static IGroupInfo selectGroupInfo()
        {
            string RealPath = path + ".Adminis_DAL.GroupInfo_DAL";
            return (IGroupInfo)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static IAlarmInfo selectAlarmInfo()
        {
            string RealPath = path + ".Monitor_DAL.AlarmInfo_DAL";
            return (IAlarmInfo)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static IMonitorMachine selectMonitorMachine()
        {
            string RealPath = path + ".Monitor_DAL.MonitorMachine_DAL";
            return (IMonitorMachine)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static IMonitorDispatchMstr selectMonitorDispatchMstr()
        {
            string RealPath = path + ".Monitor_DAL.MonitorDispatchMstr_DAL";
            return (IMonitorDispatchMstr)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static IMonitorMaterial selectMonitorMaterial()
        {
            string RealPath = path + ".Monitor_DAL.MonitorMaterial_DAL";
            return (IMonitorMaterial)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static ICustomerInfo selectCustomerInfo()
        {
            string RealPath = path + ".BaseInfo_DAL.CustomerInfo_DAL";
            return (ICustomerInfo)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static IEmployeeInfo selectEmployeeInfo()
        {
            string RealPath = path + ".BaseInfo_DAL.Employee_DAL";
            return (IEmployeeInfo)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static IBadReason selectBadReason()
        {
            string RealPath = path + ".BaseInfo_DAL.BadReason_DAL";
            return (IBadReason)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static IStopReason selectStopReason()
        {
            string RealPath = path + ".BaseInfo_DAL.StopReason_DAL";
            return (IStopReason)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static IMaintainInfo selectMaintainInfo()
        {
            string RealPath = path + ".Maintain_DAL.MaintainInfo_DAL";
            return (IMaintainInfo)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static IMachineMstr0 selectMachineMstr0()
        {
            string RealPath = path + ".Machine.MachineMstr0_DAL";
            return (IMachineMstr0)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static IMachineMstr selectMachineMstr()
        {
            string RealPath = path + ".BaseInfo_DAL.MachineMstr_DAL";
            return (IMachineMstr)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static IMouldMstr0 selectMouldMstr0()
        {
            string RealPath = path + ".Machine.MouldMstr0_DAL";
            return (IMouldMstr0)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static IMouldDetail selectMouldDetail()
        {
            string RealPath = path + ".BaseInfo_DAL.MouldDetail_DAL";
            return (IMouldDetail)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static IMouldMstr selectMouldMstr()
        {
            string RealPath = path + ".BaseInfo_DAL.MouldMstr_DAL";
            return (IMouldMstr)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static IItemMstr selectItemMstr()
        {
            string RealPath = path + ".BaseInfo_DAL.ItemMstr_DAL";
            return (IItemMstr)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static IItemMstr0 selectItemMstr0()
        {
            string RealPath = path + ".Product_DAL.ItemMstr0_DAL";
            return (IItemMstr0)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static IMPSResult selectMPSResult()
        {
            string RealPath = path + ".Product_DAL.MPSResult_DAL";
            return (IMPSResult)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static IOrderMstr selectOrderMstr()
        {
            string RealPath = path + ".Product_DAL.OrderMstr_DAL";
            return (IOrderMstr)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static IWorkOrder selectWorkOrder()
        {
            string RealPath = path + ".Product_DAL.WorkOrder_DAL";
            return (IWorkOrder)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static IDispatchOrder selectDispatchOrder()
        {
            string RealPath = path + ".Product_DAL.DispatchOrder_DAL";
            return (IDispatchOrder)Assembly.Load(path).CreateInstance(RealPath);
        }
        public static IAdjustMachine selectAdjustMachine()
        {
            string RealPath = path + ".Product_DAL.AdjustMachine_DAL";
            return (IAdjustMachine)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static IManMachineMap selectManMachineMap()
        {
            string RealPath = path + ".Product_DAL.ManMachineMap_DAL";
            return (IManMachineMap)Assembly.Load(path).CreateInstance(RealPath);
        }

        //public static IINStorage selectINStorage()
        //{
        //    string RealPath = path + ".Storage_DAL.INStorage_DAL";
        //    return (IINStorage)Assembly.Load(path).CreateInstance(RealPath);
        //}

        //public static IExtendMaterial selectExtendMaterial()
        //{
        //    string RealPath = path + ".Storage_DAL.ExtendMaterial_DAL";
        //    return (IExtendMaterial)Assembly.Load(path).CreateInstance(RealPath);
        //}

        //public static IReceiveMaterial selectReceiveMaterial()
        //{
        //    string RealPath = path + ".Storage_DAL.ReceiveMaterial_DAL";
        //    return (IReceiveMaterial)Assembly.Load(path).CreateInstance(RealPath);
        //}

        public static IErrDataInfo selectErrDataInfo()
        {
            string RealPath = path + ".Collect_DAL.ErrDataInfo_DAL";
            return (IErrDataInfo)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static ICommunicationInfo selectCommunicationInfo()
        {
            string RealPath = path + ".Collect_DAL.CommunicationInfo_DAL";
            return (ICommunicationInfo)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static IDataHistory selectDataHistory()
        {
            string RealPath = path + ".Collect_DAL.DataHistory_DAL";
            return (IDataHistory)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static IQC_Table selectQCTable()
        {
            string RealPath = path + ".Quality_DAL.QC_Table_DAL";
            return (IQC_Table)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static IQC_ThroughDefect selectQCAdjust()
        {
            string RealPath = path + ".Quality_DAL.QC_ThroughDefect_DAL";
            return (IQC_ThroughDefect)Assembly.Load(path).CreateInstance(RealPath);
        }

        public static IStandTechnicsParams selectStandTechnicsParams()
        {
            string RealPath = path + ".Quality_DAL.StandTechnicsParams_DAL";
            return (IStandTechnicsParams)Assembly.Load(path).CreateInstance(RealPath);
        }
    }
}
