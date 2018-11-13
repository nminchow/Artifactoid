using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Artifact.Controllers
{
    class JoinedGuild
    {
        public static Func<SocketGuild, Task> Joined(DataBase db)
        {
            Func<SocketGuild, Task> convert = async delegate (SocketGuild guild)
            {
                Guild.FindOrCreate.Perform(guild, db);
                db.SaveChanges();

                var view = Views.Info.JoinedGuild.Response();
                await guild.TextChannels.First().SendMessageAsync(text: view.Item1, embed: view.Item2);

                //AuthDiscordBotListApi DblApi = new AuthDiscordBotListApi(425833927517798420, token);
                //var me = await DblApi.GetMeAsync();
                //await me.UpdateStatsAsync(db.Guilds.Count());
            };

            return convert;
        }
    }
}
