﻿using Core.DataAccess.Abstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Anstract
{
    public interface IPersonDAL:IRepository<Person>
    {
        List<Person> GetPersonWithPosition(Expression<Func<Person, bool>> predicate = null);
    }
}
