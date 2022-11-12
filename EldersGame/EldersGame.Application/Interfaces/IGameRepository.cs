using EldersGame.Application.Models;

namespace EldersGame.Application.Interfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        void CreateNewGame(Game game);
    }
}
