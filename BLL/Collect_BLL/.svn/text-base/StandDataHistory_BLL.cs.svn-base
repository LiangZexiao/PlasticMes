using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Admin.SQLServerDAL.Collect_DAL;

namespace Admin.BLL.Collect_BLL
{
    public class StandDataHistory_BLL
    {
        /// <summary>
        /// 获得机器编号
        /// </summary>
        /// <returns></returns>
        public DataTable selectMachineNoFromStandDataHistory()
        {
            StandDataHistory_DAL dal = new StandDataHistory_DAL();
            return dal.selectMachineNoFromStandDataHistory();
        }
        /// <summary>
        /// 模具编号
        /// </summary>
        /// <returns></returns>
        public DataTable selectMouldNoFromStandDataHistory(string MachineNo)
        {
            StandDataHistory_DAL dal = new StandDataHistory_DAL();
            return dal.selectMouldNoFromStandDataHistory(MachineNo);
        }
        /// <summary>
        /// 获得产品编号
        /// </summary>
        /// <returns></returns>
        public DataTable selectProductNoFromStandDataHistory(string MachineNo, string MouldNo)
        {
            StandDataHistory_DAL dal = new StandDataHistory_DAL();
            return dal.selectProductNoFromStandDataHistory(MachineNo, MouldNo);
        }

        /// <summary>
        /// 获得啤的序号
        /// </summary>
        /// <param name="MachineNo"></param>
        /// <param name="MouldNo"></param>
        /// <returns></returns>
        public DataTable selectActionNumFromStandDataHistory(string MachineNo, string MouldNo, string ProductNo)
        {
            StandDataHistory_DAL dal = new StandDataHistory_DAL();
            return dal.selectActionNumFromStandDataHistory(MachineNo, MouldNo, ProductNo);
        }
        /// <summary>
        /// 更新StandDataHistory,生成一笔记录为标准
        /// </summary>
        /// <param name="MachineNo"></param>
        /// <param name="MouldNo"></param>
        /// <param name="ProductNo"></param>
        /// <param name="TotalNum"></param>
        /// <returns></returns>
        public int updateStandDataHistory(string MachineNo, string MouldNo, string ProductNo, string TotalNum)
        {
            StandDataHistory_DAL dal = new StandDataHistory_DAL();
            return dal.updateStandDataHistory(MachineNo, MouldNo, ProductNo, TotalNum);
        }

        public DataTable selectGeneralField(string TechnicalPara, string MachineNo, string MouldNo, string ProductNo, string BeginDate, string EndDate, string ActionNum)
        {
            StandDataHistory_DAL dal = new StandDataHistory_DAL();
            return dal.selectGeneralField(TechnicalPara, MachineNo, MouldNo, ProductNo, BeginDate, EndDate, ActionNum);
        }

        public DataTable selectPress(string MachineNo, string MouldNo, string ProductNo, string BeginDate, string EndDate, string ActionNum)
        {
            StandDataHistory_DAL dal = new StandDataHistory_DAL();
            return dal.selectPress(MachineNo, MouldNo, ProductNo, BeginDate, EndDate, ActionNum);
        }

    }
}
