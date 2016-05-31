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
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Vail()
        {
            return View();
        }
        protected override string LoadAutority()
        {
            BaseAuthority model = new BaseAuthority(); //glyphicon glyphicon-trash
            model.ListAuthButtons.Add(new AuthorityButton());
            model.ListAuthButtons.Add(new AuthorityButton()
            {
                ClassName = "glyphicon glyphicon-edit",
                Title = "修改",
                ClickName = "EditModel"
            });
            model.ListAuthButtons.Add(new AuthorityButton()
            {
                ClassName = "glyphicon glyphicon-trash",
                Title = "删除",
                ClickName = "RemoveModel"
            });
            return model.ToString();
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