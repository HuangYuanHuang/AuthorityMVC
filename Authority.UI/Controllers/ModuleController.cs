using Authority.Model;
using Common.ExpandMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace Authority.UI.Controllers
{
    public class ModuleController : BaseController<ModuleViewModel, int>
    {
        // GET: Module
        public ActionResult Index()
        {
            return View(new GridTreeDataModel() { TreeModels = LoadTreeDate(), Authoritys = LoadAutority() });
        }
        public ActionResult Create()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult ModuleTree()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult Tree()
        {
            return Json(new object[] { LoadTreeDate().BuildTreeView() });
        }
        protected IEnumerable<BaseTreeViewModel> LoadTreeDate()
        {
            List<ModuleViewModel> list = new List<ModuleViewModel>()
            {
                new ModuleViewModel() { ID=0,Name="父节点",ParentID=-1,AuthorityStr="添加 修改 删除",Url="/Module/Index"},
                new ModuleViewModel() { ID=1,Name="子节点-1",ParentID=0,AuthorityStr="添加 修改 删除",Url="/Module/Index"},
                new ModuleViewModel() { ID=2,Name="子节点-1",ParentID=0,AuthorityStr="添加 修改 删除",Url="/Module/Index"},
                new ModuleViewModel() { ID=3,Name="子节点-1-1",ParentID=2,AuthorityStr="添加 修改 删除",Url="/Module/Index"},
            };
            return list;
        }
        protected override Task<int> AddAsync(ModuleViewModel model)
        {
            throw new NotImplementedException();
        }

        protected override Task<ModuleViewModel> DetailsAsync(int id)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<ModuleViewModel> ListViewModel()
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<ModuleViewModel> ListViewModel(int id)
        {
            throw new NotImplementedException();
        }

        protected override Task<int> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        protected override Task<int> UpdateAsync(ModuleViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}