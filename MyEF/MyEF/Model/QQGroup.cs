using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEF.Model
{
    public class QQGroup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long GroupId { get; set; }

        public string name { get; set; }
    }
}
