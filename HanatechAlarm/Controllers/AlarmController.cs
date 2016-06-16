using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Common.ExpandMVC;
using Common.ExpandMVC.Authority;
using HanatechAlarm.Models;

namespace HanatechAlarm.Controllers
{
    public class AlarmController : BaseController<Models.AlarmViewModel, int>
    {
        // GET: Alarm
        public ActionResult Index()
        {
            return View(new GridTreeDataModel() { Authoritys = LoadAutority() });
        }

        protected override Task<int> AddAsync(AlarmViewModel model)
        {
            throw new NotImplementedException();
        }

        protected override Task<AlarmViewModel> DetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        protected override BaseAuthority LoadAutority()
        {
            var obj = base.LoadAutority();
            obj.ListAuthButtons = obj.ListAuthButtons.Take(new Random().Next(1,4)).ToList();
            return obj;
        }
        protected override IEnumerable<AlarmViewModel> ListViewModel()
        {
            return new List<AlarmViewModel>()
            {
                new AlarmViewModel() { AlarmCount=207890,Index=1,Plant="芳烃部"},
                new AlarmViewModel() { AlarmCount=53420,Index=2,Plant="烯烃部"},
                new AlarmViewModel() { AlarmCount=34520,Index=3,Plant="炼油部"}
            };
        }

        protected override IEnumerable<AlarmViewModel> ListViewModel(int id)
        {
            throw new NotImplementedException();
        }

        protected override Task<int> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        protected override Task<int> UpdateAsync(AlarmViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}