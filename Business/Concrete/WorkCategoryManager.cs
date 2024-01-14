using Business.Abstract;
using Core.Helpers;
using Core.Helpers.Constants;
using DataAccess.Anstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WorkCategoryManager : IWorkCategoryService
    {
        private readonly IWorkCategoryDAL _workcategoryDAL;

        public WorkCategoryManager(IWorkCategoryDAL workcategoryDAL)
        {
            _workcategoryDAL = workcategoryDAL;
        }
        public IResult Add(WorkCategory workcategory)
        {
            _workcategoryDAL.Add(workcategory);
            return new SuccessResult(OperationMessage.DataAddedSuccesfly);
        }

        public IResult Delete(WorkCategory workcategory)
        {
            _workcategoryDAL.Update(workcategory);
            return new SuccessResult(OperationMessage.DataDeletedSuccesfly);
        }

        public IDataResult<List<WorkCategory>> GetAll()
        {
            return new SuccessDataResult<List<WorkCategory>>(_workcategoryDAL.GetAll().Where(x => x.Deleted == Constants.NotDeleted).ToList());
        }

        public IDataResult<WorkCategory> GetById(int id)
        {
            return new SuccessDataResult<WorkCategory>(_workcategoryDAL.Get(x => x.Deleted == Constants.NotDeleted && x.ID == id));
        }

        public IResult Update(WorkCategory workcategory)
        {
            _workcategoryDAL.Update(workcategory);
            return new SuccessResult(OperationMessage.DataUpdateSuccesfly);
        }
    }
}
