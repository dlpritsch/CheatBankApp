using CheatBank.Data;
using CheatBank.Models.GameModels;
using CheatBank.Models.GamesInSystemModels;
using CheatBank.Models.SystemModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheatBank.Services
{
    public class GameSystemService
    {

        public bool CreateGameSystem(GameSystemCreate model)
        {
            // just build a basic create method like in Game
            var entity =
                new GameSystem()
                {
                    SystemName = model.SystemName
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.GameSystems.Add(entity);
                return ctx.SaveChanges() == 1;
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
        {  //The only thing we can change about a system is its name... it's games are a completely different object, though connected, they are separate and have separate crud
            using (var ctx = new ApplicationDbContext())
            {
                    var entity =
                      ctx
                          .GameSystems
                          .Single(e => e.SystemId == model.SystemId);
                    if (entity == null)
                        return false;

                    entity.SystemName = model.SystemName;

                    return ctx.ChangeTracker.HasChanges();  //read into HasChanges a little bit, don't just use it!
                     
            }
           
        }

        public bool UpdateGamesInSystem(GamesInSystemEdit model)  // see the notes we wrote in the model
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .GamesInSystems
                        .Single(e => e.GameSystemId == model.GamesInSystemId);

                entity.GamesInSystemId = model.GamesInSystemId;
                entity.GameSystemId = model.OldGameSystemId;
                entity.GameSystemId = model.NewGameSystemId;
                entity.GameId = model.OldGameId;
                entity.GameId = model.NewGameId;

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
        public GameSystemDetail GetGameSystemById(int id)  //this is where we will expose the list of games we get access to via our Junction Object
        {
            using (var ctx = new ApplicationDbContext())
            {
                var listOfGames = new List<GameListItem>(); //create an empty list
                var entity =
                    ctx
                        .GameSystems
                        .Single(e => e.SystemId == id);
                foreach (var game in entity.GamesInSystem) //foreach through our entity's collection of games,
                {
                    var gameInSystem =
                        new GameListItem()      // create a new listItem
                        {
                            TitleOfGame = game.Game.TitleOfGame,
                            GameId = game.Game.GameId,
                        };
                    listOfGames.Add(gameInSystem);
                }
                return
                    new GameSystemDetail
                    {
                        SystemId = entity.SystemId,
                        SystemName = entity.SystemName,
                        GamesInSystem = listOfGames                      
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
