using Common.ExpandMVC;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authority.Model
{
    public class ModuleViewModel : BaseTreeViewModel
    {
        [Display(Order = 1, Name = "模块名称")]
        public string Name { get; set; }


    }
}
