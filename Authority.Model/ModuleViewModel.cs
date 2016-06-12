using Common.ExpandMVC;
using Common.ExpandMVC.Support;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authority.Entity;
namespace Authority.Model
{

    public class ModuleViewModel : BaseTreeViewModel
    {

        [Display(Order = 1, Name = "模块名称")]
        [TreeText]
        public string Name { get; set; }

        [Display(Order = 2, Name = "图标")]
        [ClassName]
        public string ClassName { get; set; } = "";

        [Display(Order = 3, Name = "排序")]
        public int Sort { get; set; }

        [Display(AutoGenerateField = false)]
        public long[] ArrayAuth { get; set; }

        [Display(Order = 4, Name = "子级菜单")]
        public string SubMenu { get { return HasChildren == "on" ? "是" : "否"; } }

        [Display(Order = 4, Name = "URL")]
        public string Url { get; set; }

        [Display(AutoGenerateField = false)]
        public long Authority { get; set; }

        [Display(AutoGenerateField = false)]
        public string HasChildren { get; set; }

        [Display(Order = 5, Name = "权限")]
        public string AuthorityStr { get; set; } = "";

        [Display(Order = 6, Name = "描述")]
        public string Description { get; set; } = "";

        [Display(AutoGenerateField = false)]
        public string AppID { get; set; } = "";

        [Display(Order = 1, Name = "APP名称")]
        public string AppName { get; set; } = "";
    }

    public static class ModuleViewModelExpand
    {
        private static Tuple<string, long[]> GetAuthorityStr(long value, List<Tuple<string,long>> listStr)
        {
            string res = "";
            char[] arr = Convert.ToString(value, 2).ToCharArray();
            int index = 0;
            List<long> listAuth = new List<long>();
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] == '1')
                {
                    res += " " + listStr[index].Item1;
                    listAuth.Add(listStr[index].Item2);
                }
                index++;
            }
            return new Tuple<string, long[]>(res.Trim(), listAuth.ToArray());

        }
        public static IEnumerable<ModuleViewModel> ModuleEntityToViewModel(this IEnumerable<Purv_Module> list, IEnumerable<Purv_Authority> listAuth, IEnumerable<Purv_AppConfig> configs)
        {
            var dict = listAuth.OrderBy(d => d.AuthorityValue).Select(d => new Tuple<string, long>(d.AuthorityName, d.AuthorityValue)).ToList();

            foreach (var item in list)
            {
                var temp = GetAuthorityStr(item.Authority, dict);
                yield return new ModuleViewModel()
                {
                    Authority = item.Authority,
                    AuthorityStr = temp.Item1,
                    ClassName = item.ClassName,
                    ArrayAuth = temp.Item2,
                    Description = item.Description,
                    ID = item.ModuleId,
                    Name = item.ModuleName,
                    ParentID = item.ParentId,
                    Sort = item.Sort,
                    Url = item.Url,
                    AppID = item.AppID,
                    AppName = configs.FirstOrDefault(d => d.AppID == item.AppID)?.Name,
                    HasChildren = item.IsHasChildren ? "on" : "off"

                };
            }

        }
        public static ModuleViewModel ModuleEntityToViewModel(this Purv_Module model, IEnumerable<Purv_Authority> listAuth, IEnumerable<Purv_AppConfig> configs)
        {
            return ModuleEntityToViewModel(new List<Purv_Module>() { model }, listAuth, configs).First();

        }

        public static Purv_Module ModuleViewModelToEntity(this ModuleViewModel model)
        {
            return new Purv_Module()
            {
                AppID = model.AppID,
                Authority = model.Authority,
                ClassName = model.ClassName,
                Description = model.Description,
                ModuleName = model.Name,
                ParentId = model.ParentID,
                Sort = model.Sort,
                Url = model.Url,
                IsHasChildren = model.HasChildren == "on"
            };
        }
    }
}
