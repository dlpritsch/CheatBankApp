using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheatBank.Data
{
    public class GameSystem
    {
        [Key]
        public int SystemId { get; set; }

        [Required]
        public string SystemName { get; set; }
        public virtual ICollection<GamesInSystem> GamesInSystem { get; set; } = new List<GamesInSystem>();
    }
}
