using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEF.Model
{
    public class Period
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PId { get; set; }

        public string PName { get; set; }
    }
}
