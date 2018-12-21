using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEF.DTOs
{
    public class MemberInfoLstDto
    {
        public int total { get; set; }
        public List<MemberInfoDto> rows { get; set; }
    }

    public class MemberInfoDto
    {
        public string abbr { get; set; }
        public string birth_day { get; set; }
        public string birth_place { get; set; }
        public string blood_type { get; set; }
        public string catch_phrase { get; set; }
        public string company { get; set; }
        public string experience { get; set; }
        public string fname { get; set; }
        public string gcolor { get; set; }
        public int gid { get; set; }
        public string gname { get; set; }
        public double height { get; set; }
        public string hobby { get; set; }
        public string join_day { get; set; }
        public string nickname { get; set; }
        public int pid { get; set; }
        public string pinyin { get; set; }
        public string pname { get; set; }
        public int sid { get; set; }
        public string sname { get; set; }
        public string speciality { get; set; }
        public string star_sign_12 { get; set; }
        public string star_sign_48 { get; set; }
        public int status { get; set; }
        public string tcolor { get; set; }
        public int tid { get; set; }
        public string tieba_kw { get; set; }
        public string tname { get; set; }
        public long weibo_uid { get; set; }
        public string weibo_verifier { get; set; }
    }
}
