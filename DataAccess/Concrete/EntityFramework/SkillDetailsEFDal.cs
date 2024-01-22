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
    public class SkillDetailsEFDal:RepositoryBase<SkillDetails, PortfolioDbContext>, ISkillDetailsDAL
    {
        private readonly PortfolioDbContext _portfolioDbContext;
        public SkillDetailsEFDal(PortfolioDbContext portfolioDbContext)
        {
            _portfolioDbContext = portfolioDbContext;
        }



        public List<SkillDetails> GetSkillDetailWithSkill(Expression<Func<SkillDetails, bool>> predicate = null)
        {
            return predicate is null
            ?
                   _portfolioDbContext.Set<SkillDetails>().Include(x => x.Skill).ToList()
            :
                  _portfolioDbContext.Set<SkillDetails>().Include(x => x.Skill).Where(predicate).ToList(); 
        }
    }
}
