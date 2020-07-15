using CheatBank.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheatBank.Models.GameModels
{
    public class GameDetail
    {
        public int GameId { get; set; }
        public string TitleOfGame { get; set; }


        public string GameSystem { get; set; }

  

        public virtual ICollection<Cheat> Cheats { get; set; } = new List<Cheat>();  //this should be a CheatListItem, but leave that for 2.0
    }


}
