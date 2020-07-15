using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheatBank.Data
{
    public class Cheat
    {
        [Key]
        public int CheatId { get; set; }

        [ForeignKey("Game")]
        public int GameId { get; set; }
        public virtual Game Game {get; set;}

        public string TitleOfGame { get; set; }

        public string NameOfCheat { get; set; }

        public string CheatDetails { get; set; }

    }
}
