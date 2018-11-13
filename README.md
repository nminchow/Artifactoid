# Artifactoid
Artifactoid shows artifact card data within your discord channels.

#### Usage

To get started type `!a help`.

#### Configuration

Artifactoid has a couple of configuration options which can be viewied and modified by the `!a config` command.

[Official Artifactoid Discord](https://discord.gg/KxNzKFN)

## Built With

* [Discord.net](https://github.com/RogueException/Discord.Net) - Bot Framework

## Contributing

Pull requests are welcome!

To get running locally:
1. Create a [discord bot user](https://discordapp.com/developers/applications/)
2. Set up a sql database
3. Create a appsettings.json file within the project's "Artifact" directory (see example below)
4. Run migrations
5. Be excellent to eachother

```json
// appsettings.json
{
  "discordAppToken": "F5OCongcjYOMXmEgrTmGDFy1Te5CUZy5ignm2DLoUUwJ1QsbfqEeOpyWBhe",
  "ConnectionStrings": {
    "sql": "Server=(localdb)\\mssqllocaldb;Database=Artifact;Trusted_Connection=True;"
  }
}
```

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details
