using System.ComponentModel.DataAnnotations;

namespace EldersGame.Application.Models
{
    public class Game
    {
        public int Id { get; set; }

        public int GenreId { get; set; }

        public int TagId { get; set; }

        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        public double? Price { get; set; }

    }
}
