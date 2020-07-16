using CheatBank.Data;
using CheatBank.Models.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheatBank.Services
{
    public class GameService
    {
        

        public bool CreateGame(GameCreate model)
        {
            var entity =
                new Game()
                {
                    TitleOfGame = model.TitleOfGame,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<GameListItem> GetGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Games
                        .Select(
                            e =>
                                new GameListItem
                                {
                                    GameId = e.GameId,
                                    TitleOfGame = e.TitleOfGame,
                                    //SystemId = e.
                                }
                                );
                return query.ToArray();
            }
        }
        public GameDetail GetGameById(int id)
        {
            List<Cheat> CheatList = new List<Cheat>();
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameId == id);
                foreach (var cheat in entity.Cheats)
                {
                    CheatList.Add(cheat);
                } 
                return
                    new GameDetail
                    {
                        GameId = entity.GameId,
                        TitleOfGame = entity.TitleOfGame,
                        GameSystem = entity.GameSystem,
                        Cheats = CheatList
                    };
            }
        }
        public bool UpdateGame(GameEdit model) // change model to just have info we are going to edit, may have cascading effects on validation in controller... but maybe not
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameId == model.GameId);

                entity.TitleOfGame = model.TitleOfGame;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGame(int gameId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Games
                        .Single(e => e.GameId == gameId);

                ctx.Games.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
