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
        public IResult Add(Portfoli portfolio, string fileName)
        {
            portfolio.WorkImgPath = fileName;
            _portfolioDAL.Add(portfolio);
            return new SuccessResult(OperationMessage.DataAddedSuccesfly);
        }

        public IResult Delete(Portfoli portfolio)
        {
            _portfolioDAL.Update(portfolio);
            return new SuccessResult(OperationMessage.DataDeletedSuccesfly);
        }

        public IDataResult<List<Portfoli>> GetAll()
        {
            return new SuccessDataResult<List<Portfoli>>(_portfolioDAL.GetPortfolioWithWorkCategory().Where(x => x.Deleted == Constants.NotDeleted).ToList());
        }

        public IDataResult<Portfoli> GetById(int id)
        {
            return new SuccessDataResult<Portfoli>(_portfolioDAL.Get(x => x.Deleted == Constants.NotDeleted && x.ID == id));
        }

        public IResult Update(Portfoli portfolio, string fileName)
        {
            portfolio.WorkImgPath = fileName;
            _portfolioDAL.Update(portfolio);
            return new SuccessResult(OperationMessage.DataUpdateSuccesfly);
        }
    }
}
