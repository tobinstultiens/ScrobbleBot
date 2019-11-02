# ScrobbleBot
ScrobbleBot is a LastFM discord bot. 

## Getting Started
These instruction will give you a copy of this project to run for development purposes.

### Prerequisites
You will need the following tools:

* [Visual Studio 2019](https://www.visualstudio.com/downloads/)
* [.NET Core SDK 3.0](https://www.microsoft.com/net/download/dotnet-core/3.0)

### Setup
1. Clone the repository
2. Change the `appSettings.json` file at the root of the Scrobblebot.CLI layer with your bot key and api key.
```json
{
  "LastFmApiKey": "EXAMPLE_LASTFM_KEY",
  "DiscordApiKey": "EXAMPLE_DISCORD_KEY",
  "Prefix": "!"
}
```
3. Next, go to `Tools > NuGet Package Manager > Package Manager Console` in visual studio, To restore all dependencies:
```
dotnet restore
```
Followed by:
```
dotnet build
```
To make sure all dependencies were added succesfully, it should build without dependency warnings else you have probably not installed .NET core 3.0 SDK.

## Authors

* **Glovali** - *Initial work* - [Metalglove](https://github.com/metalglove)
* **Tobin** - *Initial work* - [Tobinstultiens](https://github.com/tobinstultiens)
