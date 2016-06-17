using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Common.ExpandMVC;
using Common.ExpandMVC.Authority;
using HanatechAlarm.Models;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;

namespace HanatechAlarm.Controllers
{
    [Authorize]
    public class AlarmController : BaseController<Models.AlarmViewModel, int>
    {
        protected override string GetTokenUrl()
        {
            return "http://192.168.200.123/authority/token";
        }

        // GET: Alarm
        public ActionResult Index()
        {
            return View(new GridTreeDataModel()
            {
                Authoritys = OauthAuthority()
            });
        }

        protected override Task<int> AddAsync(AlarmViewModel model)
        {
            throw new NotImplementedException();
        }

        protected override Task<AlarmViewModel> DetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        private BaseAuthority OauthAuthority()
        {
            string url = "http://192.168.200.123/authority/authority/ListAuhth";
            HttpClient httpclient = new HttpClient();

            httpclient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", GetAccessToken());
            var respone = httpclient.PostAsync(url, new FormUrlEncodedContent(new Dictionary<string, string>{
                { "username","name"}
            })).Result;
            string res = respone.Content.ReadAsStringAsync().Result;
            JArray arrays = JArray.Parse(res);
            List<AuthorityButton> listButts = new List<AuthorityButton>();
            foreach (var item in arrays)
            {
                listButts.Add(new AuthorityButton()
                {
                    ClassName = item["Html"].Value<string>(),
                    ClickName = item["JsName"].Value<string>(),
                    Title = item["Name"].Value<string>()
                });
            }

            return new BaseAuthority() { ListAuthButtons = listButts };
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