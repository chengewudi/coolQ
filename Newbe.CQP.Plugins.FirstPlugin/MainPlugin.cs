using Newbe.CQP.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEF;
using Newbe.CQP.Plugins.FirstPlugin.Tools;
using MyEF.Model;
using System.Threading;
using System.Net;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using Newbe.CQP.Plugins.FirstPlugin.model;

namespace Newbe.CQP.Plugins.FirstPlugin
{
    public class MainPlugin : PluginBase
    {
        public MainPlugin(ICoolQApi coolQApi) : base(coolQApi)
        {

        }

        public override string AppId => "Newbe.CQP.Plugins.FirstPlugin";

        MyDBContext db = new MyDBContext();

        public List<QQGroup> qGroups;
        public List<long> qGroupIds;

        public string token;
        public static long lastMsgTime;

        public override int Enabled()
        {
            #region 初始化参数
            qGroups = db.QQGroups.ToListAsync().GetAwaiter().GetResult();
            qGroupIds = qGroups.Select(a => a.GroupId).ToList();
            token = GetToken();
            lastMsgTime = GetLastMsg().content.data.OrderByDescending(a => a.msgTime).FirstOrDefault().msgTime;
            #endregion
            
            new Task(() =>
            {
                while (true)
                {
                    RoomMsg roomMsg = GetLastMsg();
                    Data data = roomMsg.content.data.OrderByDescending(a => a.msgTime).FirstOrDefault();//最新一条信息
                    ExtInfo extInfo = JsonConvert.DeserializeObject<ExtInfo>(data.extInfo);
                    Body body = JsonConvert.DeserializeObject<Body>(data.Bodys);
                    if (data.msgTime > lastMsgTime)//发布了新房间信息
                    {
                        lastMsgTime = data.msgTime;

                        if (data.msgType == 0)//文字信息
                        {
                            if (extInfo.messageObject == "text")//
                            {
                                string content = "叮~颜沁发布了一条房间信息:\n"
                                + data.msgTimeStr + "\n"
                                + extInfo.text;

                                CoolQApi.SendGroupMsg(861182880, content);
                            }
                            else if (extInfo.messageObject == "faipaiText")
                            {
                                string content = "叮~颜沁翻牌了:\n"
                                + data.msgTimeStr + "\n"
                                + "翻牌内容:" + extInfo.faipaiContent + "。" + "\n"
                                + "回复:" + extInfo.messageText + "。";

                                CoolQApi.SendGroupMsg(861182880, content);
                            }
                        }
                        else if (data.msgType == 1)
                        {
                            string content = "叮~颜沁发布了新的图片:" + "\n"
                            + data.msgTimeStr + "\n"
                            + body.url;

                            CoolQApi.SendGroupMsg(861182880, content);
                        }
                    }
                    Thread.Sleep(20 * 1000);
                }
            }).Start();

            return base.Enabled();
        }

        /// <summary>
        /// 当收到私聊时的响应
        /// </summary>
        /// <param name="subType"></param>
        /// <param name="sendTime"></param>
        /// <param name="fromQq"></param>
        /// <param name="msg"></param>
        /// <param name="font"></param>
        /// <returns></returns>
        public override int ProcessPrivateMessage(int subType, int sendTime, long fromQq, string msg, int font)
        {
            return base.ProcessPrivateMessage(subType, sendTime, fromQq, msg, font);
        }

        public override int ProcessGroupMessage(int subType, int sendTime, long fromGroup, long fromQq, string fromAnonymous, string msg, int font)
        {
            if (msg == "getLastMsgTime")
            {
                CoolQApi.SendGroupMsg(fromGroup, lastMsgTime.ToString());
            }

            //记录群聊天信息
            if (qGroupIds.Contains(fromGroup))
            {
                db.QQGroupHistoryMsgs.Add(new QQGroupHistoryMsg
                {
                    GroupName = qGroups.Where(a => a.GroupId == fromGroup).FirstOrDefault().name,
                    msg = msg,
                    Speaker = QQInfo.GetQQName(fromQq).GetAwaiter().GetResult(),
                    SpeakerId = fromQq,
                    SpeekTime = DateTime.Now
                });
                db.SaveChangesAsync().GetAwaiter().GetResult();
            }

            return base.ProcessGroupMessage(subType, sendTime, fromGroup, fromQq, fromAnonymous, msg, font);
        }

        public static void Main(string[] args)
        {

        }

        public string GetToken()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://puser.48.cn/usersystem/api/user/v1/login/phone");
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Headers.Add("version", "5.3.2");
            request.Headers.Add("os", "Android");
            request.Headers.Add("IMEI", "0");

            JObject jsonBody = new JObject(
                    new JProperty("latitude", 0),
                    new JProperty("longitude", 0),
                    new JProperty("account", 18705191702),
                    new JProperty("password", "wodejia1")
                );

            string body = jsonBody.ToString();
            byte[] postData = Encoding.UTF8.GetBytes(body);
            request.ContentLength = postData.Length;
            Stream streamReq = request.GetRequestStream();

            streamReq.Write(postData, 0, postData.Length);
            streamReq.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string result = reader.ReadToEnd();

            return JsonConvert.DeserializeObject<Token>(result).content.token;
        }

        public RoomMsg GetLastMsg()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://pjuju.48.cn/imsystem/api/im/v1/member/room/message/chat");
            request.Method = "POST";
            request.Headers.Add("IMEI", "0");
            request.Headers.Add("version", "5.3.2");
            request.UserAgent = "Mobile_Pocket";
            request.ContentType = "application/json";
            request.Headers.Add("os", "Android");
            request.Headers.Add("token", token);

            JObject jsonBody = new JObject(
                new JProperty("roomId", 59535290),
                new JProperty("chatType", 0),
                new JProperty("lastTime", 0),
                new JProperty("limit", 5)
            );

            string body = jsonBody.ToString();

            byte[] postData = Encoding.UTF8.GetBytes(body);
            request.ContentLength = postData.Length;
            Stream streamReq = request.GetRequestStream();

            streamReq.Write(postData, 0, postData.Length);
            streamReq.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            string result = reader.ReadToEnd();

            return JsonConvert.DeserializeObject<RoomMsg>(result);
        }
    }
}
