using ExcelCompareApp.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Src.Core.DbRespository;
using Src.Core.DbRespository.SqlServer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ExcelCompareApp
{
    public class EntComService
    {

        public string GetNickNameByWechatId()
        {
            string result = "";
            List<wx_nick_names> noNickNames = GetNoNickNameInfo();
            //获取有多少群组
            List<string> entComNames = noNickNames.Select(i => i.GroupName).Distinct().ToList();
            foreach (var item in entComNames)
            {
                var entComMemsList = noNickNames.Where(i=>i.GroupName == item).ToList();
                
                foreach (var noName in entComMemsList)
                {
                    string nickName = "";
                    string senWechatId = "";//脱敏微信号
                    string excelDesc = "";//所在文件
                    string wechatId = noName.WechatId;
                    var members = GetMembersInfo(item).Where(i=>i.WechatId.Length == wechatId.Length).ToList();//对应群组得人
                    foreach (var mem in members)
                    {
                        var index = mem.WechatId.LastIndexOf('*')+1;
                        var length = mem.WechatId.Length - mem.WechatId.LastIndexOf('*') -1;
                        string wechatStr = mem.WechatId.Substring(index, length);
                        string noNameStr = wechatId.Substring(index, length);
                        if (wechatStr == noNameStr)
                        {
                            excelDesc = mem.ExcelDesc;
                            senWechatId = mem.WechatId;
                            nickName = mem.NickName;
                            break;
                        }
                    }
                    result += $"群组:{item},=====昵称:{nickName},=====微信Id:{wechatId},=====脱敏微信号:{senWechatId},=====文件名称:{excelDesc}*\n";
                }
            }
            result = result.TrimEnd('*');
            return result;
        }

        public List<wx_nick_names> GetNoNickNameInfo()
        {
            List<wx_nick_names> nickNames = new List<wx_nick_names>();
            string path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "DataFiles", "1.txt");
            string value = File.ReadAllText(path);//未找到昵称的人
            string[] noNickNameArr = value.Split('^');
            foreach (var item in noNickNameArr)
            {
                string groupName = item.Split(',')[0].Trim();//群组名称
                string wechatId = item.Split(',')[1].Trim();//微信号
                wx_nick_names info = new wx_nick_names() { 
                    GroupName = groupName,
                    WechatId = wechatId
                };
                nickNames.Add(info);
            }
            return nickNames;
        }

        public List<job_wx_members_info> GetMembersInfo(string entComName)
        {
            var db = new SqlServerDbContext().GetDB();
            string sql = @"SELECT [id] as Id
                          ,[wechat_id] as WechatId
                          ,[nick_name] as NickName
                          ,[hospital] as Hospital
                          ,[doctor_name] as DoctorName
                          ,[ent_com_name] as EntComName
                          ,[excel_desc] as ExcelDesc
                      FROM [WxGroupDb].[dbo].[job_wx_members_info] Where ent_com_name = @entComName";
            var param = new {
                entComName = entComName
            };
            return db.Ado.SqlQuery<job_wx_members_info>(sql,param);
        }



        public string GetNickName()
        {
            string a = @"一蓑烟雨、zc、宇雨妈💗Ruby、王海源永靖县人民医院、沉默、旭日侠影、浮云shao、幸福一家人、金呈、刚好遇见你、琼、Rom.Kyle、O(∩_∩)O、超越自我！、🤍、小助教、《零度》以梦、冯医师Dr.feng、黄华强、珍惜、王者、张天炎中医主治医师、晓娟、文笔峰第一社区服务站，任明辉、任伟、刘毛毛、王东红、春风、云开雾散、汪德利、瑞雪兆丰年、敖啸孤峰、牟贵华、李从军、ღ᭄ꦿ梅꧔ꦿঞོ⁵²º᭄归·ꦿض、生命守护、嘉和、张云云、高级中医调理师梅本丽、doc.hu、青云、王、静若淡水、豆子、大山、忘机寻、Change、侯享青、延君、老杨、段兴杰、祥 c、、在水一方、郄军锋【卫生院】、渔与鱼、西河社区卫生服务站周小飞、空杯心态、依风望云、辉煌刘少华、李祖华13970185971贵溪市、Mojito。、铁山乡西岩村卫生室华林茂、A000  齐新华15932937550、臻至、陈书淼、马大夫、天高云淡、仙女有只猫、彩红、千年健、吴长兴、急诊风杨梓敬爸爸、香、_ _ 隆！、懒得取个名、穆文中、冯正林、gastronome、荀东坡、杏林一粟、碳酸钠、张步展、赵贱贵、Dr.丁、蔡楚杰、Angle、勇士、gyr、桥南开发区医院于生春13842506571、江湖、小慧慧、国平、白瑞瑞、SONG、小荷、一切依旧、孟、三色堇、小夏、家乡美、罗医生、LZ林、张志龙、健康是金、刘会来、快乐的鱼、三分空青、nut.坚果、蔡国文、柴庆通、無賴、遊心、峻川牛、非文、夏日荷声、金龙、木子李、penghI、!、熊品信18079271351、今生水起、大丰收、张军张大夫、Rehoo、啊啊、玲玲（玫）、俞珠峰、超人不会飞、吴玉、爱拼才会赢、彩色考拉、三石、孙华、陈宇、小红鱼、夏天、付、艾山江、鹏红、maggie、&- 弦、lydia、yuhui、楠楠、LadyCC、Rsj、医者仁心-庄健13807936022、杜杜、王燕、沐阳、剑锋、EVE、马丽娜、无天、徐笠、 杨娜、smileD、M。、zihua、阿亮、NLW、三寸阳光、春暖花开、水煮蛋、芜湖的渝、戴渔、4477尚、荷田田、龙昊曦、凌乱、高春杨、陶然、丘玲、崔连亭、Struggling Christian、taoer、丫倪、WHY、🌙金星 star、天秀郝、泌尿豪大夫、范蓉、Sue、悠悠、蒲公英、Cenping、大智若鱼、吉吉登登、蜡笔小妹、ACEI、戴太平13979206002、仁义草民、刘双、康巍林、小米、刘世华、小助教";
            var aa = a.Split('、');
            string ss = JsonConvert.SerializeObject(aa);
            string result = "";
            string path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "DataFiles", "1.txt");
            string value = File.ReadAllText(path);//未找到昵称的人
            string[] noNickeNameArr = value.Split('^');
            var groups = GetGroups();
            foreach (var item in noNickeNameArr)
            {
                string groupName = item.Split(',')[0].Trim();
                string wechatId = item.Split(',')[1].Trim();
                var group = groups.Where(i => i.wechatGroupName == groupName).FirstOrDefault();
                if (group != null)
                {
                    //获取群组对应的会员列表
                    var members = GetMembers(group.id);
                    int memberIndex = members.FindIndex(i => i.wechatId == wechatId);
                    string nickName = "无";
                    if (memberIndex > -1)
                    {
                        var nickNameList = group.DisplayNameList.Split('、').ToList();
                        nickName = nickNameList[memberIndex];
                    }
                    result += $"群组:{groupName},昵称:{nickName},微信Id:{wechatId}*";
                }
                else
                {
                    Console.WriteLine($"群组:{groupName}没有！");
                }
            }
            result = result.TrimEnd('*');
            return result;

        }


        public List<wx_groups> GetGroups()
        {
            var db = new SqlServerDbContext().GetDB();
            string sql = "select * from [WxGroupDb].[dbo].job_wx_group";
            List<wx_groups> groups = db.Ado.SqlQuery<wx_groups>(sql);
            return groups;
        }

        public List<wx_members> GetMembers(int groupId)
        {
            var db = new SqlServerDbContext().GetDB();
            string sql = "select * from job_wx_group_member where groupId=@groupId And status = 0";
            var param = new {
                groupId = groupId
            };
            List<wx_members> members = db.Ado.SqlQuery<wx_members>(sql,param);
            return members;
        }




    }
}
