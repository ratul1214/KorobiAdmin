using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Newweb.Models
{
    public class WriterList
    {
        [Key]
        public int id { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string name { get; set; }
        [Column(TypeName = "int")]
        public int rank { get; set; }
    }
}
