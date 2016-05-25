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
        // GET: Authority
        public ActionResult Index()
        {
            return View();
        }

        protected override string LoadAutority()
        {
            BaseAuthority model = new BaseAuthority();
            model.ListAuthButtons.Add(new AuthorityButton());
            model.ListAuthButtons.Add(new AuthorityButton()
            {
                ClassName = "glyphicon-edit",
                Title = "修改",
            });
            return model.ToString();
        }
        protected override Task<int> AddAsync(AuthorityViewModel model)
        {
            throw new NotImplementedException();
        }

        protected override Task<AuthorityViewModel> DetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<AuthorityViewModel> ListViewModel()
        {
            List<AuthorityViewModel> list = new List<AuthorityViewModel>()
            {
                new AuthorityViewModel() { Index=1,CreateTime=DateTime.Now,Html="",Name="添加",Value=1},
                 new AuthorityViewModel() { Index=2,CreateTime=DateTime.Now,Html="",Name="修改",Value=2}
            };
            return list;
        }

        protected override IEnumerable<AuthorityViewModel> ListViewModel(int id)
        {
            throw new NotImplementedException();
        }

        protected override Task<int> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        protected override Task<int> UpdateAsync(AuthorityViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}