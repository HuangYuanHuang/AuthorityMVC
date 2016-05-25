using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authority.Entity
{
    [Table("T_Purv_Module")]
    public class Purv_Module : BaseEntity
    {
        [Key]
        public int ModuleId { get; set; }


        /// <summary>
        /// 权限值
        /// </summary>
        [Required]

        public long Authority { get; set; }
        public int ParentId { get; set; }

        [Required]
        [StringLength(50)]
        public string ModuleName { set; get; }

        [Required]
        public bool IsHasChildren { get; set; }
        public string ClassName { get; set; }

        [Required]
        public int Sort { get; set; }
        [Required]
        public string Url { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Purv_UserModule> UserModules { set; get; }

        public virtual ICollection<Purv_RoleModule> RoleModules { set; get; }
    }
}
