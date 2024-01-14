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
    public class ExperienceManager : IExperienceService
    {
        private readonly IExperienceDAL _experienceDAL;
        public ExperienceManager( IExperienceDAL experienceDAL)
        {
            _experienceDAL = experienceDAL;  
        }//dependency injection
        public IResult Add (Experience experience)
        {
            _experienceDAL.Add(experience);
            return new SuccessResult(OperationMessage.DataAddedSuccesfly);
        }

        public IResult Delete(Experience experience)
        {
            _experienceDAL.Update(experience);
            return new SuccessResult(OperationMessage.DataDeletedSuccesfly);
        }

        public IDataResult<List<Experience>> GetAll()
        {
            return new SuccessDataResult<List<Experience>>(_experienceDAL.GetAll().Where(x => x.Deleted == Constants.NotDeleted).ToList());
        }

        public IDataResult<Experience> GetById(int id)
        {
            return new SuccessDataResult<Experience>(_experienceDAL.Get(x => x.Deleted == Constants.NotDeleted && x.ID == id));
        }

        public IResult Update(Experience experience)
        {
            _experienceDAL.Update(experience);
            return new SuccessResult(OperationMessage.DataUpdateSuccesfly);
        }
    }
}
