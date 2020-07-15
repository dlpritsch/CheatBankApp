using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheatBank.Models.GameModels
{
    public class GameListItem
    {
        public int GameId { get; set; }
        public string TitleOfGame { get; set; }

        [ForeignKey("GameSystem")]
        public int SystemId { get; set; }
        
    }
}
