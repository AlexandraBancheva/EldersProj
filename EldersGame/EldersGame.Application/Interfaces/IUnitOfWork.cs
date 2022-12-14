using System.Data;

namespace EldersGame.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        void Begin();
        void Commit();
        void RollBack();
    }
}
