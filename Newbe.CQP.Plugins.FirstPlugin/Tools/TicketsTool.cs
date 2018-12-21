using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Newbe.CQP.Plugins.FirstPlugin.Tools
{
    public class TicketsTool
    {
        /// <summary>
        /// 北京票务信息
        /// </summary>
        /// <returns></returns>
        public static async Task<List<BEJTicketModel>> GetBEJTicketInfo()
        {          
            var result = await WebTools.DoPostRequest("http://www.bej48.com/index/ticket/category_data.html", "time=null&team=null");
            List<BEJTicketModel> tickets = JsonTool.JsonToObject<List<BEJTicketModel>>(result);
            foreach (var ticket in tickets)
            {
                switch (ticket.category_id)
                {
                    case "34":
                        ticket.category_name = "B队";
                        break;
                    case "35":
                        ticket.category_name = "E队";
                        break;
                    case "36":
                        ticket.category_name = "J队";
                        break;
                    case "37":
                        ticket.category_name = "联合公演";
                        break;
                }
            }

            return tickets;
        }

        public static async Task<List<SNHTicketModel>> GetSNHTicketInfo()
        {
            string body = DateTime.Now.AddDays(12).Year.ToString() + "-" + DateTime.Now.AddDays(12).Month.ToString();
            var result = await WebTools.DoPostRequestForSNH("http://www.snh48.com/ticketsinfo.php?act=recent", body);
            List<SNHTicketModel> tickets = JsonTool.JsonToObject<List<SNHTicketModel>>(result);

            return tickets;
        }

        public static async Task<List<SNHTicketModel>> GetGNZTicketInfo()
        {
            string body = DateTime.Now.AddDays(12).Year.ToString() + "-" + DateTime.Now.AddDays(12).Month.ToString();
            var result = await WebTools.DoPostRequestForSNH("http://www.gnz48.com/ticket/ticketsinfo.php?act=recent", body);
            List<SNHTicketModel> tickets = JsonTool.JsonToObject<List<SNHTicketModel>>(result);

            return tickets;
        }
    }

    public class BEJTicketModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime time { get; set; }
        public string price { get; set; }
        public string description { get; set; }
        public string category_id { get; set; }
        public string category_name { get; set; }
        public long create_time { get; set; }
        public long update_time { get; set; }
        public int status { get; set; }
        public int auction_is_on_sale { get; set; }
        public string auction_url { get; set; }
        public int vip_is_on_sale { get; set; }
        public string vip_url { get; set; }
        public int common_is_on_sale { get; set; }
        public string common_url { get; set; }
        public int stand_is_on_sale { get; set; }
        public string stand_url { get; set; }
    }

    public class SNHTicketModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateTime addTime { get; set; }
        public string tickets_price { get; set; }
        public string theme { get; set; }
        public string category_id { get; set; }
        public string category_name { get; set; }
        public long create_time { get; set; }
        public long update_time { get; set; }
        public int acstatus { get; set; }
        public int vstatus { get; set; }
        public int cstatus { get; set; }
        public int sstatus { get; set; }
        public int type { get; set; }
        public string special { get; set; }
        public int auction_is_on_sale { get; set; }
        public string auction_url { get; set; }
        public int vip_is_on_sale { get; set; }
        public string vip_url { get; set; }
        public int common_is_on_sale { get; set; }
        public string common_url { get; set; }
        public int stand_is_on_sale { get; set; }
        public string stand_url { get; set; }
        public string teamname { get; set; }
        public long pretime { get; set; }
        public int team_id { get; set; }
        public int oversea { get; set; }
        public int style { get; set; }
    }
}
