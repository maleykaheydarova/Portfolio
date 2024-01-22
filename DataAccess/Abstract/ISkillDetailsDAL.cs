using Core.DataAccess.Abstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Anstract
{
    public interface ISkillDetailsDAL: IRepository<SkillDetails>
    {
        List<SkillDetails> GetSkillDetailWithSkill(Expression<Func<SkillDetails, bool>> predicate = null);
    }
}
