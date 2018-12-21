using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newbe.CQP.Plugins.FirstPlugin.model
{
    public class RoomMsg
    {
        public Content content { get; set; }
    }

    public class Content
    {
        public List<Data> data { get; set; }

        public Content()
        {
            data = new List<Data>();
        }
    }

    public class Data
    {
        public long msgTime { get; set; }
        public string msgTimeStr { get; set; }
        public int msgType { get; set; }//0文字,1图片
        public string Bodys { get; set; }
        public string extInfo { get; set; }
    }

    public class ExtInfo
    {
        public string messageObject { get; set; }//翻牌还是普通房间信息
        public string faipaiContent { get; set; }//聚聚发送内容
        public string messageText { get; set; }//回复信息
        public int faipaiUserId { get; set; }
        public string text { get; set; }//普通房间信息
    }

    public class Body
    {
        public string url { get; set; }
    }
}
