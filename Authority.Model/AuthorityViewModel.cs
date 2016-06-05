using Common.ExpandMVC;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace Authority.Model
{
    public class AuthorityViewModel : BaseGridViewModel
    {
        [Display(AutoGenerateField = false)]
        public int ID { get; set; }

        [Display(Order =1,Name ="权限名称")]
       
        public string Name { get; set; }

        [Display(Order = 2, Name = "权限值")]
        public long Value { get; set; }

        [Display(Order =3, Name = "图标")]
        public string Html { get; set; }
        [Display(AutoGenerateField = false)]
        public DateTime CreateTime { get; set; }
        [Display(Order = 5, Name = "创建时间")]
    
        public string TimeStr { get { return CreateTime.ToString("yyyy-MM-dd HH:mm:ss"); } }

        [Display(Order =4,Name ="JavaScript名称")]
        public string JsName { get; set; }
    }

    public static class AuthorityViewModelExpad
    {
        public static IEnumerable<AuthorityViewModel> PurvAuthorityToViewModel(this IEnumerable<Authority.Entity.Purv_Authority> list)
        {
            int index = 1;
            foreach (var item in list)
            {
                yield return new AuthorityViewModel()
                {
                    CreateTime = item.Creatime,
                    Html = item.Html,
                    ID = item.AuthorityID,
                    Index = index++,
                    Name = item.AuthorityName,
                    Value = item.AuthorityValue,
                    JsName=item.FunctionName
                };
            }
        }

        public static AuthorityViewModel PurvAuthorityToViewModel(this Authority.Entity.Purv_Authority item)
        {


            return new AuthorityViewModel()
            {
                CreateTime = item.Creatime,
                Html = item.Html,
                ID = item.AuthorityID,
                Name = item.AuthorityName,
                Value = item.AuthorityValue,
                JsName=item.FunctionName
            };
        }
    }

}
