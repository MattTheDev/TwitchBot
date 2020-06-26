# TwitchBot

![.NET Core](https://github.com/MattTheDev/TwitchBot/workflows/.NET%20Core/badge.svg)

Have you heard of [CouchBot](https://couch.bot), but want to run your own version? Well - CouchBot isn't open source or available to run on your own ..  HOWEVER! I wanted to provide you something to let you announce your own streams, on your own server, with your own bot. Interested? Welp - let's see what we can do to make that happen!

Windows Installation:

1. Download the [latest release](https://github.com/MattTheDev/TwitchBot/releases).
2. Download the BasicBotLogging.db file from the releases page.
3. Create directory C:\TwitchBot
4. Unzip the release zip file to C:\TwitchBot and move BasicBotLogging.db to the same directory.
5. Create a [New Twitch Application](https://dev.twitch.tv/console/apps/create) - Save the Client ID
6. Create a [New Discord Bot](https://discord.com/developers/applications) - Save the Bot Token AND the ID of the Bot
7. Create a [Discord Channel On Your Server and Get the Id of the Channel](https://discordia.me/en/developer-mode) - Save the ID
8. Edit C:\TwitchBot\BotConfig.json ... 

```json
{
  "Tokens": {
    "Discord": "NEW BOT TOKEN GOES HERE",
    "Twitch": "NEW TWITCH APP CLIENT ID GOES HERE"
  },
  "DiscordChannels": {
    "Announcements": THE ID OF THE DISCORD CHANNEL GOES HERE
  },
  "TwitchChannelName": "THE TWITCH CHANNEL YOU WANT TO ANNOUNCE GOES HERE",
  "Prefix": "&",
  "ConnectionStrings": {
    "BasicBotLogging": "C:\TwitchBot\BasicBotLogging.db"
  }
}
```

9. Invite the bot to your server - https://discord.com/oauth2/authorize?client_id=DISCORD_BOT_ID_GOES_HERE_&scope=bot&permissions=158720
10. Run TwitchBot.Bot.exe

The bot will check for your live status every 60 seconds. When live? It'll announce. 

THIS IS THE INITIAL RELEASE ...  I will clean up this documentation and make it easier to configure in later iterations.

Want to support this project AND CouchBot? [Support Me On Patreon](https://patreon.com/CouchBot)
