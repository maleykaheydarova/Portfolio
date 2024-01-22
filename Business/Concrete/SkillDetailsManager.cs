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
    public class SkillDetailsManager : ISkillDetailsService
    {
        private readonly ISkillDetailsDAL _skilldetailsDAL;

        public SkillDetailsManager(ISkillDetailsDAL skilldetailsDAL)
        {
            _skilldetailsDAL = skilldetailsDAL;
        }

        public IResult Add(SkillDetails skilldetails)
        {
            _skilldetailsDAL.Add(skilldetails);
            return new SuccessResult(OperationMessage.DataAddedSuccesfly);

        }

        public IResult Delete(SkillDetails skilldetails)
        {
            _skilldetailsDAL.Update(skilldetails);
            return new SuccessResult(OperationMessage.DataDeletedSuccesfly);
        }

        public IDataResult<List<SkillDetails>> GetAll()
        {
            return new SuccessDataResult<List<SkillDetails>>(_skilldetailsDAL.GetSkillDetailWithSkill().Where(x => x.Deleted == Constants.NotDeleted).ToList());
        }

        public IDataResult<SkillDetails> GetById(int id)
        {
            return new SuccessDataResult<SkillDetails>(_skilldetailsDAL.Get(x => x.Deleted == Constants.NotDeleted && x.ID == id));
        }

        public IResult Update(SkillDetails skilldetails)
        {
            _skilldetailsDAL.Update(skilldetails);
            return new SuccessResult(OperationMessage.DataUpdateSuccesfly);
        }
    }
}
