using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Authority.Entity
{
    [Table("T_Purv_AppConfig")]
    public class Purv_AppConfig 
    {
        [Key]
        public string AppID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [Required]
        public DateTime AddDateTime { get; set; }

        public string Description { get; set; }


        public Purv_AppConfig()
        {
            AppID = Guid.NewGuid().ToString();
            AddDateTime = DateTime.Now;
        }
    }
}
