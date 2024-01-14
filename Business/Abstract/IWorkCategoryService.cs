﻿using Core.Helpers;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWorkCategoryService
    {
        IResult Add(WorkCategory workcategory);
        IResult Delete(WorkCategory workcategory);
        IResult Update(WorkCategory workcategory);
        IDataResult<WorkCategory> GetById(int id);
        IDataResult<List<WorkCategory>> GetAll();
    }
}
