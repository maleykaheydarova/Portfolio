using Core.Helpers;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPortfolioService
    {
        IResult Add(Portfolio portfolio);
        IResult Delete(Portfolio portfolio);
        IResult Update(Portfolio portfolio);
        IDataResult<Portfolio> GetById(int id);
        IDataResult<List<Portfolio>> GetAll();
    }
}
