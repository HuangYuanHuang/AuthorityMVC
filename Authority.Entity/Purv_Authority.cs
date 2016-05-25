using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authority.Entity
{
    [Table("T_Purv_Authority")]
    public class Purv_Authority
    {
        public Purv_Authority()
        {
            Creatime = DateTime.Now;
        }
        [Key]
        public int AuthorityID { get; set; }

        [Required]
        [StringLength(50)]
        public string AuthorityName { get; set; }

        [Required]
        [Index("Index_Value", IsUnique = true)]
        public int AuthorityValue { get; set; }

        public string Html { get; set; }

        [Required]
        public DateTime Creatime { get; set; }
    }
}
