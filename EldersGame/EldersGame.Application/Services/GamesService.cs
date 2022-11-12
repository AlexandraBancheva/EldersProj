using EldersGame.Application.Interfaces;
using EldersGame.Application.Models;

namespace EldersGame.Application.Services
{
    public class GamesService : IGamesService
    {
        private readonly IGameRepository _gameRepository;

        public GamesService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public void AddGamePrice(int id, double price)
        {
            var game = _gameRepository.GetById(id);
            game.Price = price;
            _gameRepository.Update(game);
        }

        public void CreateNewGame(Game game)
        {
            _gameRepository.CreateNewGame(game);
        }

        public IEnumerable<Game> GetAllGames()
        {
            return _gameRepository.GetAll();
        }

        public Game GetGameById(int id)
        {
            var res = _gameRepository.GetById(id);
            return res;
        }
    }
}
