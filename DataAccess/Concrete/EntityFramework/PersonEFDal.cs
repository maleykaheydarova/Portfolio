using Core.DataAccess.Concrete;
using Core.Helpers;
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
    public class PersonEFDal:RepositoryBase<Person, PortfolioDbContext>, IPersonDAL
    {
        private readonly PortfolioDbContext _portfolioDbContext;
        public PersonEFDal(PortfolioDbContext portfolioDbContext)
        {
            _portfolioDbContext = portfolioDbContext;
        }



        public List<Person> GetPersonWithPosition(Expression<Func<Person, bool>> predicate = null)
        {
            return predicate is null
            ?
                   _portfolioDbContext.Set<Person>().Include(x => x.Position).ToList()
            :
                  _portfolioDbContext.Set<Person>().Include(x => x.Position).Where(predicate).ToList(); ;
        }


    }
}
