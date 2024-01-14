using Business.Abstract;
using Core.Helpers;
using Core.Helpers.Constants;
using DataAccess.Anstract;
using Entities.Concrete.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PositionManager : IPositionService
    {
        private readonly IPositionDAL _positionDAL;
        public PositionManager(IPositionDAL positionDAL)
        {
            _positionDAL = positionDAL;
        }

        public IResult Add(Position position)
        {
            _positionDAL.Add(position);
            return new SuccessResult(OperationMessage.DataAddedSuccesfly);
        }

        public IResult Delete(Position position)
        {
            _positionDAL.Update(position);
            return new SuccessResult(OperationMessage.DataDeletedSuccesfly);
        }

        public IDataResult<List<Position>> GetAll()
        {
            return new SuccessDataResult<List<Position>>(_positionDAL.GetAll().Where(x => x.Deleted == Constants.NotDeleted).ToList());
        }

        public IDataResult<Position> GetById(int id)
        {
            return new SuccessDataResult<Position>(_positionDAL.Get(x => x.Deleted == Constants.NotDeleted && x.ID == id));
        }

        public IResult Update(Position position)
        {
            _positionDAL.Update(position);
            return new SuccessResult(OperationMessage.DataUpdateSuccesfly);
        }
    }
}
