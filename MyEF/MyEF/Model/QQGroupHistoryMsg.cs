using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEF.Model
{
    public class QQGroupHistoryMsg
    {
        [Key,Column(Order = 1)]
        public DateTime SpeekTime { get; set; }

        public string GroupName { get; set; }

        [Key,Column(Order = 2)]
        public long SpeakerId { get; set; }

        public string Speaker { get; set; }

        public string msg { get; set; }
    }
}
