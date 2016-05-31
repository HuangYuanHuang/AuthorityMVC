using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ExpandMVC
{
    public class BaseViewModel
    {
        /// <summary>
        /// 列表顺序NUM
        /// </summary>
        [Display(Order = -2, Name = "编号")]
        public int Index { get; set; }

        [Display(Order = -10, Name = " ")]

        public bool State { get; set; }
    }

    public class BaseTreeViewModel : BaseViewModel
    {
        [Display(AutoGenerateField = false)]
        public int ID { get; set; }

        [Display(AutoGenerateField = false)]
        public int ParentID { get; set; }


    }
}
