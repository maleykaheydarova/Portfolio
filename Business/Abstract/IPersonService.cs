using Core.Helpers;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPersonService
    {
        IResult Add(Person person, string filename, string download);
        IResult Update(Person person);
        IResult Update(Person person, string filename, string download);
        IDataResult<Person> GetById(int id);
        IDataResult<List<Person>> GetAll();
    }
}
