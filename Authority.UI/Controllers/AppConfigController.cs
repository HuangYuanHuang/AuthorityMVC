using Authority.Model;
using Common.ExpandMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Authority.Service;

namespace Authority.UI.Controllers
{
    public class AppConfigController : BaseController<AppConfigViewModel, string>
    {
        AppConfigService configService = new AppConfigService();
        // GET: AppConfig
        public ActionResult Index()
        {
            return View(new GridTreeDataModel() { Authoritys = LoadAutority() });
        }

        public ActionResult Create()
        {
            return View();
        }
        protected override Task<int> AddAsync(AppConfigViewModel model)
        {
            return configService.AddOrUpdateConfig(model);
        }

        protected override Task<AppConfigViewModel> DetailsAsync(string id)
        {
            return configService.GetAppConfig(id);
        }

        protected override IEnumerable<AppConfigViewModel> ListViewModel()
        {
            return configService.GetAppConfig();
        }

        protected override IEnumerable<AppConfigViewModel> ListViewModel(string id)
        {
            throw new NotImplementedException();
        }

        protected override Task<int> RemoveAsync(string id)
        {
            return configService.DeleteAppConfig(id);
        }

        protected override Task<int> UpdateAsync(AppConfigViewModel model)
        {
            return configService.AddOrUpdateConfig(model);
        }
    }
}