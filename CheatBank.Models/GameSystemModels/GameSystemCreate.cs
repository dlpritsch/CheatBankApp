using CheatBank.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheatBank.Models.SystemModels
{
    public class GameSystemCreate
    {
        [Required]
        public string SystemName { get; set; }

        public int?[] GamesInSystem { get; set; }
    }
}
