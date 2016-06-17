using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Common.ExpandMVC;
using Common.ExpandMVC.Authority;
using Authority.Model;

namespace Authority.UI.Controllers
{
    public class AuthorityController : BaseController<AuthorityViewModel, int>
    {
        Authority.Service.AuthorityService service = new Service.AuthorityService();
        // GET: Authority
        public ActionResult Index()
        {
            return View(new GridTreeDataModel() { Authoritys = LoadAutority() });
        }

        [Authorize]
        public JsonResult ListAuhth()
        {
            return Json(service.GetAuthority(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Vail()
        {
            return View();
        }

        protected override Task<int> AddAsync(AuthorityViewModel model)
        {
            return service.AddOrUpdateAuthority(model);
        }

        protected override Task<AuthorityViewModel> DetailsAsync(int id)
        {
            return service.GetAuthority(id);
        }

        protected override IEnumerable<AuthorityViewModel> ListViewModel()
        {
            return service.GetAuthority();
        }

        protected override IEnumerable<AuthorityViewModel> ListViewModel(int id)
        {
            throw new NotImplementedException();
        }

        protected override Task<int> RemoveAsync(int id)
        {
            return service.DeletaAuthority(id);
        }

        protected override Task<int> UpdateAsync(AuthorityViewModel model)
        {
            return service.AddOrUpdateAuthority(model);
        }
    }
}