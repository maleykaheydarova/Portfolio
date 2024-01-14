using Business.Abstract;
using Core.Helpers;
using Core.Helpers.Constants;
using DataAccess.Anstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonManager : IPersonService
    {
        private readonly IPersonDAL _personDAL;

        public PersonManager(IPersonDAL personDAL)
        {
            _personDAL = personDAL;
        }
        public IResult Add(Person person, string filename, string download)
        {
            person.ImgPath = filename;
            person.CVPath = download;
            _personDAL.Add(person);
            return new SuccessResult(OperationMessage.DataAddedSuccesfly);
        }

        public IResult Update(Person person)
        {
            _personDAL.Update(person);
            return new SuccessResult(OperationMessage.DataDeletedSuccesfly);
        }

        public IDataResult<List<Person>> GetAll()
        {
            return new SuccessDataResult<List<Person>>(_personDAL.GetPersonWithPosition(x=> x.Deleted == 0));
        }

        public IDataResult<Person> GetById(int id)
        {
            return new SuccessDataResult<Person>(_personDAL.Get(x => x.Deleted == Constants.NotDeleted && x.ID == id));
        }

        public IResult Update(Person person, string filename, string download)
        {
            person.ImgPath = filename;
            person.CVPath = download;
            _personDAL.Update(person);
            return new SuccessResult(OperationMessage.DataUpdateSuccesfly);
        }
    }
}
