using EldersGame.Application.Models;

namespace EldersGame.Application.Interfaces
{
    public interface IGamesService
    {
        IEnumerable<Game> GetAllGames();
        Game GetGameById(int id);
        void CreateNewGame(Game game);
        void AddGamePrice(int id, double price);
    }
}
