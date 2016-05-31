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
            return View();
        }

        protected override IEnumerable<BaseTreeViewModel> LoadTreeDate()
        {
            List<ModuleViewModel> list = new List<ModuleViewModel>()
            {
                new ModuleViewModel() { ID=0,Name="父节点",ParentID=-1},
                new ModuleViewModel() { ID=1,Name="子节点-1",ParentID=0},
                 new ModuleViewModel() { ID=2,Name="子节点-1",ParentID=0},
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