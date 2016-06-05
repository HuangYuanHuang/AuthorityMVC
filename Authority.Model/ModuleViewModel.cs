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
        public string ClassName { get; set; } = "";

        [Display(Order = 3, Name = "排序")]
        public int Sort { get; set; }

        [Display(Order = 4, Name = "URL")]
        public string Url { get; set; }

        [Display(AutoGenerateField = false)]
        public long Authority { get; set; }

        [Display(Order = 5, Name = "权限")]
        public string AuthorityStr { get; set; }

        [Display(Order = 6, Name = "描述")]
        public string Description { get; set; } = "";
    }

    public static class ModuleViewModelExpand
    {
        private static string GetAuthorityStr(long value, List<string> listStr)
        {
            string res = "";
            char[] arr = Convert.ToString(value, 2).ToCharArray();
            int index = 0;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                if (arr[i] == '1')
                {
                    res += " " + listStr[index];
                }
                index++;
            }
            return res.Trim();

        }
        public static IEnumerable<ModuleViewModel> ModuleEntityToViewModel(this IEnumerable<Purv_Module> list, IEnumerable<Purv_Authority> listAuth)
        {
            var dict = listAuth.OrderBy(d => d.AuthorityValue).Select(d => d.AuthorityName).ToList();

            foreach (var item in list)
            {
                yield return new ModuleViewModel()
                {
                    Authority = item.Authority,
                    AuthorityStr = GetAuthorityStr(item.Authority, dict),
                    ClassName = item.ClassName,
                    Description = item.Description,
                    ID = item.ModuleId,
                    Name = item.ModuleName,
                    ParentID = item.ParentId,
                    Sort = item.Sort,
                    Url = item.Url
                };
            }

        }
        public static ModuleViewModel ModuleEntityToViewModel(this Purv_Module model, IEnumerable<Purv_Authority> listAuth)
        {
            return ModuleEntityToViewModel(new List<Purv_Module>() { model }, listAuth).First();

        }

        public static Purv_Module ModuleViewModelToEntity(this ModuleViewModel model)
        {
            return new Purv_Module()
            {
               // AddDateTime
            };
        }
    }
}
