using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authority.Entity
{
    [Table("T_Purv_DepartMent")]
    public class Purv_Department : BaseEntity
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required]
        [StringLength(50)]
        public string DepartmentName { get; set; }

        public int PartendId { get; set; }

        [Required]
        public int Sort { get; set; }

        [Required]
        public bool IsDisplay { get; set; } = true;

        [Required]
        public bool IsHasChildren { get; set; }

        public virtual ICollection<Purv_UserDepartment> UserDepartments { set; get; }

        public virtual ICollection<Purv_RoleDepartment> RoleDepartments { set; get; }
    }
}
