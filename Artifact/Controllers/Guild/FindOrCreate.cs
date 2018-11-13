using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artifact.Controllers.Guild
{
    class FindOrCreate
    {
        public static Models.Guild Perform(SocketGuild guild, DataBase db)
        {
            var dbGuild = db.Guilds.FirstOrDefault(u => u.DiscordId == guild.Id.ToString());
            if (dbGuild == null)
            {
                dbGuild = new Models.Guild { DiscordId = guild.Id.ToString() };
                db.Guilds.Add(dbGuild);
                db.SaveChanges();
            }
            return dbGuild;
        }
    }
}
