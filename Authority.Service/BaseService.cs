using Authority.Entity;
using Common.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authority.Service
{
    public class BaseService<T> where T : class
    {

        protected UnitOfWork<T, AuthorityContext> UnitWork;
        public BaseService()
        {
            UnitWork = new UnitOfWork<T, AuthorityContext>(new AuthorityContext());
        }
    }
}
