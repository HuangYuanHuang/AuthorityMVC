using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authority.Entity;
using Authority.Model;
namespace Authority.Service
{
    public class AuthorityService : BaseService<Purv_Authority>
    {
        public async Task<int> AddOrUpdateAuthority(AuthorityViewModel model)
        {
            var obj = await UnitWork.ManuDbContext.PurvAuthoritys.FindAsync(model.ID);
            int count = UnitWork.ManuDbContext.PurvAuthoritys.Count();
            if (obj == null)
            {
                UnitWork.ManuDbContext.PurvAuthoritys.Add(new Purv_Authority()
                {
                    AuthorityName = model.Name,
                    AuthorityValue = Convert.ToInt64(Math.Pow(2, count)),
                    FunctionName = model.JsName,
                    Html = model.Html,
                });
            }
            else
            {
                obj.AuthorityName = model.Name;
                obj.Html = model.Html;
                obj.FunctionName = model.JsName;

            }
            return await UnitWork.Commit();
        }

        public async Task<AuthorityViewModel> GetAuthority(int id)
        {
            var obj = await UnitWork.ManuDbContext.PurvAuthoritys.FindAsync(id);
            return obj.PurvAuthorityToViewModel();
        }

        public IEnumerable<AuthorityViewModel> GetAuthority()
        {
            return UnitWork.ManuDbContext.PurvAuthoritys.PurvAuthorityToViewModel();
        }

        public async Task<int> DeletaAuthority(int id)
        {
            var obj = await UnitWork.ManuDbContext.PurvAuthoritys.FindAsync(id);
            UnitWork.ManuDbContext.PurvAuthoritys.Remove(obj);
            return await UnitWork.Commit();
        }
    }
}
