using Core.DataAccess.Concrete;
using DataAccess.Anstract;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class PortfolioEFDal:RepositoryBase<Portfoli, PortfolioDbContext>, IPortfolioDAL
    {
        private readonly PortfolioDbContext _portfolioDbContext;
        public PortfolioEFDal(PortfolioDbContext portfolioDbContext)
        {
            _portfolioDbContext = portfolioDbContext;
        }

        public List<Portfoli> GetPortfolioWithWorkCategory(Expression<Func<Portfoli, bool>> predicate = null)
        {
            return predicate is null
              ?
                     _portfolioDbContext.Set<Portfoli>().Include(x => x.WorkCategory).ToList()
              :
                    _portfolioDbContext.Set<Portfoli>().Include(x => x.WorkCategory).Where(predicate).ToList(); ;
        }

    }
}
