using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEF.Model
{
    public class Idols
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]//非自增长
        public int SId { get; set; }

        public string Name { get; set; }
        
        public string BirthDay { get; set; }

        public string BirthPlace { get; set; }

        public double Height { get; set; }

        /// <summary>
        /// 兴趣爱好
        /// </summary>
        public string Hobby { get; set; }

        /// <summary>
        /// 特长
        /// </summary>
        public string Speciality { get; set; }

        public string Catch_phrase { get; set; }

        public string Join_day { get; set; }

        /// <summary>
        /// 外号
        /// </summary>
        public string NickName { get; set; }

        public int status { get; set; }

        /// <summary>
        /// 血型
        /// </summary>
        public string BloodType { get; set; }

        public long Weibo_uid { get; set; }

        public string Weibo_verifier { get; set; }

        /// <summary>
        /// 所属何团
        /// </summary>
        [ForeignKey("Group")]
        public int GId { get; set; }
        public virtual Group Group { get; set; }

        /// <summary>
        /// 所属何队
        /// </summary>
        [ForeignKey("Team")]
        public int TId { get; set; }
        public virtual Team Team { get; set; }

        /// <summary>
        /// 几期生
        /// </summary>
        [ForeignKey("Period")]
        public int PId { get; set; }
        public virtual Period Period { get; set; }
    }
}
