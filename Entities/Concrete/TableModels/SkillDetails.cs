using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete.TableModels
{
    public class SkillDetails: BaseEntity
    {
        public int Level { get; set; }
        public int SkillID { get; set; }
        public  Skill Skill { get; set; }

    }
}
