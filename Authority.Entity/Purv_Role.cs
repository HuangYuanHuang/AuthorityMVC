using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authority.Entity
{
    [Table("T_Purv_Role")]
    public class Purv_Role : BaseEntity
    {
        [Key]
        public int RoleID { get; set; }

        public int ParentId { get; set; }
        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }

        [Required]
        public int Sort { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Purv_RoleModule> RoleModules { set; get; }

        public virtual ICollection<Purv_User> Users { set; get; }

        public virtual ICollection<Purv_RoleDepartment> RoleDepartments { set; get; }
    }
}
