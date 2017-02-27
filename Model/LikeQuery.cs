using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Model
{
   public class LikeQuery
    {
        private string _likefieldname = string.Empty;
        private string _likefieldtext = string.Empty;

        public string LikeFieldName
        {
            get { return _likefieldname; }
            set { _likefieldname = value; }
        }

        public string LikeFieldText
        {
            get { return _likefieldtext; }
            set { _likefieldtext = value; }
        }
    }
}
