using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEF.Model
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TId { get; set; }

        public string TName { get; set; }
    }
}
