using CheatBank.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheatBank.Models.SystemModels
{
    public class GameSystemEdit
    {
        public int SystemId { get; set; }

        public string SystemName { get; set; }
        public int?[] GamesInSystem { get; set; }
    }
}
