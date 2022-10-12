using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelCompareApp.Model
{
    public class job_wx_members_info
    {
        //id, wechat_id, nick_name, hospital, doctor_name, ent_com_name
        public long Id { get; set; }
        public string WechatId { get; set; }
        public string NickName { get; set; }
        public string Hospital { get; set; }
        public string DoctorName { get; set; }
        public string EntComName { get; set; }
        public string ExcelDesc { get; set; }
    }
}
