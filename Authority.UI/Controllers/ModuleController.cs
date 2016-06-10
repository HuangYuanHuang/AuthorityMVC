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
    public class ModuleController : BaseController<ModuleViewModel, int>
    {
        ModuleService moduleService = new ModuleService();
        // GET: Module
        public ActionResult Index()
        {
            return View(new GridTreeDataModel() { TreeModels = moduleService.GetModule(), Authoritys = LoadAutority() });
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
            return Json(new object[] { moduleService.GetModule().BuildTreeView() });
        }

        protected override Task<int> AddAsync(ModuleViewModel model)
        {
           
            return moduleService.AddOrUpdateModule(model);
        }

        protected override Task<ModuleViewModel> DetailsAsync(int id)
        {
            return moduleService.GetModule(id);
        }

        protected override IEnumerable<ModuleViewModel> ListViewModel()
        {
            return moduleService.GetModule();
        }

        protected override IEnumerable<ModuleViewModel> ListViewModel(int id)
        {
            throw new NotImplementedException();
        }

        protected override Task<int> RemoveAsync(int id)
        {
            return moduleService.DeleteModule(id);
        }

        protected override Task<int> UpdateAsync(ModuleViewModel model)
        {
           
            return moduleService.AddOrUpdateModule(model);
        }
    }
}