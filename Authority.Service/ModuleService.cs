using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authority.Entity;
using Authority.Model;
namespace Authority.Service
{
    public class ModuleService : BaseService<Purv_Module>
    {
        public async Task<int> AddOrUpdateModule(ModuleViewModel model)
        {
            var obj = await UnitWork.ManuDbContext.PurvModules.FindAsync(model.ID);
            if (obj == null)
            {
                UnitWork.ManuDbContext.PurvModules.Add(model.ModuleViewModelToEntity());
            }
            else
            {
                obj.AppID = model.AppID;
                obj.Authority = model.Authority;
                obj.ClassName = model.ClassName;
                obj.Description = model.Description;
                obj.IsHasChildren = model.HasChildren=="on";
                obj.ModuleName = model.Name;
                obj.ParentId = model.ParentID;
                obj.Sort = model.Sort;
                obj.Url = model.Url;
            }
            return await UnitWork.Commit();
        }

        public async Task<ModuleViewModel> GetModule(int id)
        {
            var obj = await UnitWork.ManuDbContext.PurvModules.FindAsync(id);
            return obj.ModuleEntityToViewModel(UnitWork.ManuDbContext.PurvAuthoritys,UnitWork.ManuDbContext.PurvAppConfigs);
        }
        public IEnumerable<ModuleViewModel> GetModule()
        {

            return UnitWork.ManuDbContext.PurvModules.ModuleEntityToViewModel(UnitWork.ManuDbContext.PurvAuthoritys, UnitWork.ManuDbContext.PurvAppConfigs);
        }

        public async Task<int> DeleteModule(int id)
        {
            var obj = await UnitWork.ManuDbContext.PurvModules.FindAsync(id);
            UnitWork.ManuDbContext.PurvModules.Remove(obj);
            return await UnitWork.Commit();
        }
    }
}
