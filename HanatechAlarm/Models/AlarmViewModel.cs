using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HanatechAlarm.Models
{
    public class AlarmViewModel : Common.ExpandMVC.BaseGridViewModel
    {
        [Display(Name ="装置",Order =1)]
        public string Plant { get; set; }

        [Display(Name = "报警数", Order = 2)]
        public int AlarmCount { get; set; }

        [Display(Name = "时间", Order = 3)]
        public string TimeStr { get { return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); } }
    }
}