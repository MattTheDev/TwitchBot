namespace TwitchBot.Domain.Models.Bot
{
    public class BotConfig
    {
        public Tokens Tokens { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
        public DiscordChannels DiscordChannels { get; set; }
        public string Prefix { get; set; }
        public string TwitchChannelName { get; set; }
    }

    public class Tokens
    {
        public string Discord { get; set; }
        public string Twitch { get; set; }
    }

    public class ConnectionStrings
    {
        public string BasicBotLogging { get; set; }
    }

    public class DiscordChannels
    {
        public ulong Announcements { get; set; }
    }
}