using Core.Helpers;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
        public interface ISkillDetailsService
        {
            IResult Add(SkillDetails skilldetails);
            IResult Delete(SkillDetails skilldetails);
            IResult Update(SkillDetails skilldetails);
            IDataResult<SkillDetails> GetById(int id);
            IDataResult<List<SkillDetails>> GetAll();
        }
    
}
