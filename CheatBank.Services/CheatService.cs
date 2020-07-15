using CheatBank.Data;
using CheatBank.Models.CheatModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheatBank.Services
{
    public class CheatService
    {
        private readonly Guid _userId;

        public CheatService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCheat(CheatCreate model)
        {
            var entity =
                new Cheat()
                {
                    NameOfCheat = model.NameOfCheat,
                    CheatDetails = model.CheatDetails
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Cheats.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        public IEnumerable<CheatListItem> GetCheats()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Cheats
                        .Select(
                            e =>
                            new CheatListItem
                            {
                                CheatId = e.CheatId,
                                TitleOfGame = e.TitleOfGame,
                                NameOfCheat = e.NameOfCheat,
                                CheatDetails = e.CheatDetails
                            }); 

                return query.ToArray();
            }
        }

        public CheatDetail GetCheatById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cheats
                        .Single(e => e.CheatId == id);
                return
                    new CheatDetail
                    {
                        CheatId = entity.CheatId,
                        NameOfCheat = entity.NameOfCheat,
                        CheatDetails = entity.CheatDetails
                    };
            }
        }
        
        public bool UpdateCheat(CheatEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cheats
                        .Single(e => e.CheatId == model.CheatId);

                entity.CheatId = model.CheatId;
                entity.NameOfCheat = model.NameOfCheat;
                entity.CheatDetails = model.CheatDetails;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCheat(int cheatId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Cheats
                        .Single(e => e.CheatId == cheatId);

                ctx.Cheats.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
