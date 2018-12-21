using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEF.Model
{
    public class Group
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GId { get; set; }

        public string GName { get; set; }

        public DateTime? LastTicketTime { get; set; }
    }
}
