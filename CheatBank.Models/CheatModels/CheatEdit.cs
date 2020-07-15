using CheatBank.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheatBank.Models.CheatModels
{
    public class CheatEdit
    {
        public int CheatId { get; set; }


        public string GameSystem { get; set; }


        public string NameOfCheat { get; set; }
        public string CheatDetails { get; set; }

    }
}
