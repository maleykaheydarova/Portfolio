using Business.Abstract;
using Core.Helpers;
using Core.Helpers.Constants;
using DataAccess.Anstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PortfolioManager : IPortfolioService
    {
        private readonly IPortfolioDAL _portfolioDAL;

        public PortfolioManager(IPortfolioDAL portfolioDAL)
        {
            _portfolioDAL = portfolioDAL;
        }
        public IResult Add(Portfolio portfolio)
        {

            _portfolioDAL.Add(portfolio);
            return new SuccessResult(OperationMessage.DataAddedSuccesfly);
        }

        public IResult Delete(Portfolio portfolio)
        {
            _portfolioDAL.Update(portfolio);
            return new SuccessResult(OperationMessage.DataDeletedSuccesfly);
        }

        public IDataResult<List<Portfolio>> GetAll()
        {
            return new SuccessDataResult<List<Portfolio>>(_portfolioDAL.GetAll().Where(x => x.Deleted == Constants.NotDeleted).ToList());
        }

        public IDataResult<Portfolio> GetById(int id)
        {
            return new SuccessDataResult<Portfolio>(_portfolioDAL.Get(x => x.Deleted == Constants.NotDeleted && x.ID == id));
        }

        public IResult Update(Portfolio portfolio)
        {
            _portfolioDAL.Update(portfolio);
            return new SuccessResult(OperationMessage.DataUpdateSuccesfly);
        }
    }
}
