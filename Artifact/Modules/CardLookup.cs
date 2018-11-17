using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Artifact.Modules
{
    public class CardLookup : ModuleBase<SocketCommandContext>
    {
        private DataBase _database;

        public CardLookup(DataBase database)
        {
            _database = database;
        }

        [Command("c", RunMode = RunMode.Async)]
        public async Task Card([Remainder] string message)
        {
            await Controllers.Card.ByName.PerformAsync(Context, message, _database);
        }
    }
}
