using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelCompareApp.Model
{
    public class wx_groups
    {
        //id, wechatGroupName, wechatGroupId, wechatId, wechatFriendId,
        //createDateTime, lastUpdateTime, Classification, roomname, DisplayNameList
        public int id
        {
            get;
            set;
        }
        public string wechatGroupName
        {
            get;
            set;
        }
        public string wechatGroupId
        {
            get;
            set;
        }
        public string wechatId
        {
            get;
            set;
        }
        public string wechatFriendId
        {
            get;
            set;
        }
        public string DisplayNameList
        {
            get;
            set;
        }
    }
}
