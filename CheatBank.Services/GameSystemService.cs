using CheatBank.Data;
using CheatBank.Models.GameModels;
using CheatBank.Models.GamesInSystemModels;
using CheatBank.Models.SystemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheatBank.Services
{
    public class GameSystemService
    {

        public bool CreateGameSystem(GameSystemCreate model)
        {
            try
            {
                bool allWentWell = false;
                var entity =
                    new GameSystem()
                    {
                        SystemName = model.SystemName
                    };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.GameSystems.Add(entity);
                    var success = ctx.SaveChanges() == 1;

                    foreach (var gameInSystem in model.GamesInSystem)
                    {
                        var game =
                            new GamesInSystemCreate()
                            {
                                SystemId = entity.SystemId,
                                GameId = Convert.ToInt32(gameInSystem)
                            };
                        var succeeded = CreateGamesInSystem(game);
                        //break the code or decide what you'll do if succeeded == false;
                        // if succeeded is false, return allWentWell
                    }
                    allWentWell = true;
                }
                return allWentWell;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CreateGamesInSystem(GamesInSystemCreate gameModel)
        {
            var entity =
                new GamesInSystem()
                {
                    GameSystemId = gameModel.SystemId,
                    GameId = gameModel.GameId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.GamesInSystems.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateGameSystem(GameSystemEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    var entity =
                      ctx
                          .GameSystems
                          .Single(e => e.SystemId == model.SystemId);
                    if (entity == null)
                        return false;

                   //foreach game in entity.GamesInSystem
                   foreach (var game in entity.GamesInSystem)
                    {
                        var gameInSystem =
                            new GameListItem()
                            {
                                TitleOfGame = game.Game.TitleOfGame,
                                GameId = game.Game.GameId,

                            };
                    }
                   // create a new gameListItem model
                   // Name = game.Game.Name      and for all the other properties, probably excluding the Cheats
              

                   // foreach (var oldGames in ctx.GamesInSystems)
                    //{
                   //     var happy = ctx.GamesInSystems.Remove(oldGames);
                   // }
                    //ctx.SaveChanges();
                    //var succeed = ctx.IngredientsInDish.Count() == 0;

                    entity.SystemName = model.SystemName;

                    foreach (var newGames in model.GamesInSystem)
                    {
                        var game =
                            new GamesInSystemCreate()
                            {
                                SystemId = entity.SystemId,
                                GameId = newGames.Value
                            };
                        var succeeded = CreateGamesInSystem(game);
                    }
                    ctx.SaveChanges();
                }
                catch (Exception e)
                {
                    return false;
                }
            }
            return true;
        }

        public bool UpdateGamesInSystem(GamesInSystemEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GamesInSystems
                        .Single(e => e.GameSystemId == model.GamesInSystemId);

                entity.GamesInSystemId = model.GamesInSystemId;
                entity.GameSystemId = model.GamesInSystemId;
                entity.GameId = model.GameId;

                return ctx.SaveChanges() == 1;
            }
        }


        public IEnumerable<GameSystemListItem> GetGameSystems()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .GameSystems
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new GameSystemListItem
                                {
                                    SystemId = e.SystemId,
                                    SystemName = e.SystemName
                                }
                                );
                return query.ToArray();
            }
        }
        public GameSystemDetail GetGameSystemById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GameSystems
                        .Single(e => e.SystemId == id);
                
                return
                    new GameSystemDetail
                    {
                        SystemId = entity.SystemId,
                        SystemName = entity.SystemName
                    };
            }
        }

        public bool DeleteGameSystem(int SystemId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GameSystems
                        .Single(e => e.SystemId == SystemId);

                ctx.GameSystems.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
