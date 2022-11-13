using EldersGame.Application.Interfaces;
using EldersGame.Application.Models;
using System.Text.RegularExpressions;

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
            ValidatePrice(price);
            var game = _gameRepository.GetById(id);
            game.Price = price;
            _gameRepository.Update(game);
        }

        public void CreateNewGame(Game game)
        {
            ValidatePrice((double)game.Price);
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

        private void ValidatePrice(double price)
        {
            if (price < 0)
            {
                throw new InvalidOperationException($"The price cannot be negative.");
            }

            var pattern = new Regex(@"^\$?\d+(\.(\d{2}))?$");
            var match = pattern.Match(price.ToString());
            if (!match.Success)
            {
                throw new InvalidOperationException($"The price is not in correct format.");
            }
        }
    }
}
