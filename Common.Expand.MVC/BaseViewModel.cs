using Common.ExpandMVC.Authority;
using Common.ExpandMVC.Support;
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


        [Display(Order = -10, Name = " ")]
        [RadioState]

        public bool State { get; set; }
    }

    public class BaseGridViewModel : BaseViewModel
    {
        /// <summary>
        /// 列表顺序NUM
        /// </summary>
        [Display(Order = -2, Name = "编号")]
        public int Index { get; set; }
    }

    public class BaseTreeViewModel : BaseViewModel
    {
        [Display(AutoGenerateField = false)]
        public int ID { get; set; }

        [Display(AutoGenerateField = false)]
        public int ParentID { get; set; }

        [Display(AutoGenerateField = false)]
        public string ParentName { get; set; }

    }

    public class TreeViewJsonModel
    {
        public int nodeId { get; set; }

        public int parent { get; set; }
        public string text { get; set; }

        public string href { get; set; }

        public List<TreeViewJsonModel> nodes { get; set; } = new List<TreeViewJsonModel>();
    }

    public class SelectTreeJsonModel
    {
        public int id { get; set; }

        public string text { get; set; }
    }
    public class GridTreeDataModel
    {
        public BaseAuthority Authoritys { get; set; }

        public IEnumerable<BaseGridViewModel> GridModels { get; set; }

        public IEnumerable<BaseTreeViewModel> TreeModels { get; set; }
    }
}
