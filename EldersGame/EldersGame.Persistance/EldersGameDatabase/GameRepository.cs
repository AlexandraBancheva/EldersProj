using Dapper;
using EldersGame.Application.Interfaces;
using EldersGame.Application.Models;

namespace EldersGame.Persistence.EldersGameDatabase
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(IUnitOfWork unitOfWork) : 
            base(unitOfWork)
        {
        }

        public void CreateNewGame(Game game)
        {
            var newGame = new Game
            {
               TagId = game.TagId,
               GenreId = game.GenreId,
                Price = game.Price
            };

            _connection.Insert(newGame);
        }
    }
}
