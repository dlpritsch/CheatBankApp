using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheatBank.Models.GameModels
{
    public class GameEdit
    {
        public int GameId { get; set; }
        public string TitleOfGame { get; set; }
        public string GameSystem { get; set; }
    }
}
