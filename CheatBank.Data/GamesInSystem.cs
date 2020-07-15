using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheatBank.Data
{
    public class GamesInSystem
    {
        [Key]
        public int GamesInSystemId { get; set; }

        [ForeignKey("GameSystem")]
        public int GameSystemId { get; set; }
        public virtual GameSystem GameSystem { get; set; }

        [ForeignKey("Game")]
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
    }
}
