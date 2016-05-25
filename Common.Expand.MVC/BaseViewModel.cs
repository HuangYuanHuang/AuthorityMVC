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
        [Display(Order = 0, Name = "编号")]
        public int Index { get; set; }
    }
}
