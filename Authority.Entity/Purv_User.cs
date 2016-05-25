using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authority.Entity
{

    public class BaseEntity
    {
        public DateTime AddDateTime { get; set; }

        public string AppID { get; set; }
    }

    [Table("T_Purv_User")]
    public class Purv_User : BaseEntity
    {

        public Purv_User()
        {
            UserId = Guid.NewGuid().ToString();
            AddDateTime = DateTime.Now;
        }
        [Key]
        public string UserId { get; set; }

        [Required]
        [MaxLength(32)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(32)]
        public string Password { get; set; }

        public bool Status { get; set; }

        public DateTime LastLoginTime { get; set; }

        public virtual ICollection<Purv_UserModule> UserModules { set; get; }

         public virtual ICollection<Purv_UserDepartment> UserDepartments { set; get; }

        public virtual ICollection<Purv_Role> Roles { set; get; }
    }
}
