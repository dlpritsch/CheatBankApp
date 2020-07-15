using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheatBank.Models.GamesInSystemModels
{
    public class GamesInSystemEdit
    {

        public int GamesInSystemId { get; set; } //take in a junction object id
        public int OldGameSystemId { get; set; }// the original game system
        public int OldGameId { get; set; }// original game
        public int NewGameSystemId { get; set; } // if you are moving to a new system, change this to the system ID you want to move to
        public int NewGameId { get; set; } // vice versa if you are changing the game instead of the system


        //most of the time you would probably just delete the junction object and make a new one, but this is okay
    }
}
