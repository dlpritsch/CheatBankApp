using CheatBank.Data;
using CheatBank.Models.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheatBank.Models.SystemModels
{
    public class GameSystemDetail
    {
        public int SystemId { get; set; }

        public string SystemName { get; set; }
        public List<GameListItem> GamesInSystem { get; set; }
    }
}
