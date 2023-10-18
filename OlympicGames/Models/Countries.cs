using System.ComponentModel.DataAnnotations;

namespace OlympicGames.Models
{
    public class Countries
    {
        [Key]
        public string CountryID { get; set; }
        public string CountryName { get; set; }
        public Game Game { get; set; }
        public Category Category { get; set; }
        public string FlagImage { get; set; }

    }
}
