using EldersGame.Application.Interfaces;
using System.Data;
using Dapper;

namespace EldersGame.Persistence.EldersGameDatabase
{
    public abstract class BaseRepository<T> : IRepository<T>
        where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IDbTransaction _transaction => _unitOfWork.Transaction;

        public IDbConnection _connection => _unitOfWork.Connection;

        public void Delete(T entity)
        {
            _connection.Delete(entity);
        }

        public List<T> GetAll()
        {
            return _connection.GetList<T>(null, null, _transaction).ToList();
        }

        public T GetById(int id)
        {
            var res = _connection.Get<T>(id);
            return res;
        }

        public int Insert(T entity)
        {
            var id = _connection.Insert<T>(entity, _transaction);
            return (int)id;
        }

        public void Update(T entity)
        {
            _connection.Update(entity, _transaction);
        }
    }
}
