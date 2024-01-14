using Core.DataAccess.Concrete;
using DataAccess.Anstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
   public class ExperienceEFDal:RepositoryBase<Experience, PortfolioDbContext>, IExperienceDAL
    {
    }
}
