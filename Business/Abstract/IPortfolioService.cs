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
        IResult Add(Portfoli portfolio, string fileName);
        IResult Delete(Portfoli portfolio);
        IResult Update(Portfoli portfolio, string fileName);
        IDataResult<Portfoli> GetById(int id);
        IDataResult<List<Portfoli>> GetAll();
    }
}
