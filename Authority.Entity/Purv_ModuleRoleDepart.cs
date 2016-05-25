using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authority.Entity
{
    [Table("T_Purv_UserModule")]
    public class Purv_UserModule : BaseEntity
    {
        public string UserId { get; set; }
        public int ModuleId { get; set; }
        public long Authority { get; set; }

        public virtual Purv_Module PurvModule { get; set; }
        public virtual Purv_User PurvUser { get; set; }


    }

    [Table("T_Purv_RoleModule")]
    public class Purv_RoleModule : BaseEntity
    {
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
        public long Authority { get; set; }

        public virtual Purv_Module PurvModule { get; set; }
        public virtual Purv_Role PurvRole { get; set; }
    }

    [Table("T_Purv_UserDepartment")]
    public class Purv_UserDepartment : BaseEntity
    {
        public string UserId { get; set; }

        public int DepartmentId { get; set; }

        public virtual Purv_User PurvUser { get; set; }

        public virtual Purv_Department PurvDepartment { get; set; }
    }

    [Table("T_Purv_RoleDepartment")]
    public class Purv_RoleDepartment : BaseEntity
    {
        public int RoleId { get; set; }

        public int DepartmentId { get; set; }

        public virtual Purv_Role PurvRole { get; set; }

        public virtual Purv_Department PurvDepartment { get; set; }
    }

}
