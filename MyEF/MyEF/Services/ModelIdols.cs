using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyEF.Tools;
using Newtonsoft.Json;
using MyEF.DTOs;

namespace MyEF.Services
{
    public class ModelIdols
    {
        public static async Task<MemberInfoLstDto> GetIdolsInfo()
        {
            string result = await WebTools.DoRequest("http://h5.snh48.com/resource/jsonp/members.php?gid=00&callback=get_members_success");
            result = result.Substring(result.IndexOf("(") + 1);
            result = result.Substring(0,result.LastIndexOf(")"));
            MemberInfoLstDto dto = JsonTool.JsonToObject<MemberInfoLstDto>(result);
            return dto;
        }
    }

    
}
