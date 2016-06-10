using Authority.Entity;
using Authority.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authority.Service
{
    public class AppConfigService : BaseService<Purv_AppConfig>
    {
        public async Task<int> AddOrUpdateConfig(AppConfigViewModel model)
        {
            var obj = await UnitWork.ManuDbContext.PurvAppConfigs.FindAsync(model.ID);
            if (obj == null)
            {
                UnitWork.ManuDbContext.PurvAppConfigs.Add(new Purv_AppConfig()
                {
                    Description = model.Description,
                    Name = model.Name
                });
            }
            else
            {
                obj.Name = model.Name;
                obj.Description = model.Description;
            }
            return await UnitWork.Commit();
        }

        public async Task<AppConfigViewModel> GetAppConfig(string id)
        {
            var obj = await UnitWork.ManuDbContext.PurvAppConfigs.FindAsync(id);
            return obj.AppConfigEntityToViewModel();
        }

        public IEnumerable<AppConfigViewModel> GetAppConfig()
        {
            return UnitWork.ManuDbContext.PurvAppConfigs.AppConfigEntityToViewModel();
        }

        public async Task<int> DeleteAppConfig(string id)
        {
            var obj = await UnitWork.ManuDbContext.PurvAppConfigs.FindAsync(id);
            UnitWork.ManuDbContext.PurvAppConfigs.Remove(obj);
            return await UnitWork.Commit();
        }
    }
}
