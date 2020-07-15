using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheatBank.Data
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        
        [Required]
        public string TitleOfGame { get; set; }

        public string GameSystem { get; set; } // we are going to remove this, because we hold the info about the system for the game in the GemesInSystem

      
        public virtual ICollection<Cheat> Cheats { get; set; } = new List<Cheat>();

        public virtual ICollection<GamesInSystem> GamesInSystem { get; set; } = new List<GamesInSystem>();
    }
}
