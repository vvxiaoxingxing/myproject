using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelCompareApp.Model
{
    public class wx_members
    {
        //id, groupId, wechatId, userName, nickName, HeaderUrl, status, joinTime, outTime, lastUpdateTime
        public int groupId { get; set; }
        public string wechatId { get; set; }
        public string userName { get; set; }
    }
}
