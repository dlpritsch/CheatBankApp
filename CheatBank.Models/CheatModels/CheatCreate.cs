using CheatBank.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheatBank.Models.CheatModels
{
    public class CheatCreate
    {


        //public string GameSystem { get; set; }   --- don't need

        // put required over them all
        //[MinLength(2, ErrorMessage = "Please enter the title of the game.")]
        //public string TitleOfGame { get; set; }    --- don't need
        //
        [Required]
       public int GameId { get; set; }


        [MinLength(2, ErrorMessage = "Please enter cheat description.")]
        public string NameOfCheat { get; set; }

        [MinLength(2, ErrorMessage = "Please enter cheat details.")]
        public string CheatDetails { get; set; }

    }
}
