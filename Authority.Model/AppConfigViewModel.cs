using Common.ExpandMVC;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authority.Model
{
    public class AppConfigViewModel : BaseGridViewModel
    {
        [Display(AutoGenerateField = false)]
        public string ID { get; set; }

        [Display(Order = 1, Name = "APP名称")]

        public string Name { get; set; }
        [Display(AutoGenerateField = false)]
        public DateTime CreateTime { get; set; }
        [Display(Order = 8, Name = "创建时间")]

        public string TimeStr
        {
            get { return CreateTime.ToString("yyyy-MM-dd HH:mm:ss"); }
        }

        [Display(Order = 6, Name = "描述")]

        public string Description { get; set; }
    }

    public static class AppConfigViewModelExpand
    {
        public static IEnumerable<AppConfigViewModel> AppConfigEntityToViewModel(this IEnumerable<Authority.Entity.Purv_AppConfig> list)
        {
            int index = 1;
            foreach (var item in list)
            {
                yield return new AppConfigViewModel()
                {
                    CreateTime = item.AddDateTime,
                    Description = item.Description,
                    Index = index++,
                    Name = item.Name,
                    ID = item.AppID
                };
            }
        }
        public static AppConfigViewModel AppConfigEntityToViewModel(this Authority.Entity.Purv_AppConfig model)
        {
            return new AppConfigViewModel()
            {
                CreateTime = model.AddDateTime,
                Description = model.Description,

                Name = model.Name,
                ID = model.AppID
            };
        }

    }
}
