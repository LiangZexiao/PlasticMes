using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model
{
    /// <summary>
    /// 停机记录实体类//090718吴礼政
    /// </summary>
    public class StopReason
    {
        /// <summary>
        /// 停机编号
        /// </summary>
        private string _ReasonID;
        /// <summary>
        /// 停机描述
        /// </summary>
        private string _ReasonName;

        public StopReason(string vReasonID, string vReasonName)
        {
            this._ReasonID = vReasonID;
            this._ReasonName = vReasonName;
        }
        public string ReasonID
        {
            get { return this._ReasonID; }
            set { this._ReasonID = value; }
        }

        public string ReasonName
        {
            get { return this._ReasonName; }
            set { this._ReasonName = value; }
        }
    }
}
