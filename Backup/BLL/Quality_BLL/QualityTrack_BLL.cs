using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Admin.SQLServerDAL.Quality_DAL;

namespace Admin.BLL.Quality_BLL
{
    public class QualityTrack_BLL
    {
        /// <summary>
        /// 标准周期
        /// </summary>
        /// <param name="ProductNo"></param>
        /// <returns></returns>
        public DataTable selectStandCycle(string ProductNo)
        {
            QualityTrack_DAL dalStandCycle = new QualityTrack_DAL();
            return dalStandCycle.selectStandCycle(ProductNo);
        }

        /// <summary>
        /// 标准机器周期
        /// </summary>
        /// <param name="ProductNo"></param>
        /// <returns></returns>
        public DataTable selectStandMachineCycle(string ProductNo)
        {
            QualityTrack_DAL dalStandCycle = new QualityTrack_DAL();
            return dalStandCycle.selectStandMachineCycle(ProductNo);
        }

        public DataTable selectStandShotTemp(string MachineNo, string MouldNo, string ProductNo)
        {
            QualityTrack_DAL dal = new QualityTrack_DAL();
            return dal.selectStandShotTemp(MachineNo, MouldNo, ProductNo);
        }


        /// <summary>
        /// 注塑压力
        /// </summary>
        /// <param name="MaterialNo"></param>
        /// <param name="MouldNo"></param>
        /// <param name="ProductNo"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>
        public DataTable selectPress(string DispatchOrder,string MaterialNo, string MouldNo, string ProductNo, string bDate, string eDate, string[] TotalNum)
        {
            QualityTrack_DAL dalStandPress = new QualityTrack_DAL();
            return dalStandPress.selectPress(DispatchOrder,MaterialNo, MouldNo, ProductNo, bDate, eDate, TotalNum);
        }
        /// <summary>
        /// 统合查询5大工艺参数
        /// </summary>
        /// <param name="MaterialNo"></param>
        /// <param name="MouldNo"></param>
        /// <param name="ProductNo"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <returns></returns>

        public DataTable selectUnifyField(string DispatchOrder,string MachineNo, string MouldNo, string ProductNo, string bDate, string eDate, string[] TotalNum)
        {
            QualityTrack_DAL dalStandPress = new QualityTrack_DAL();
            return dalStandPress.selectUnifyField(DispatchOrder,MachineNo, MouldNo, ProductNo, bDate, eDate, TotalNum);
        }
    }
}
