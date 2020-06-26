using Discord;
using Discord.WebSocket;
using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;
using TwitchBot.Contracts;
using TwitchBot.Domain.Models.Bot;
using TwitchBot.Domain.Models.Twitch;

namespace TwitchBot.Services
{
    public class TwitchService
    {
        private readonly ITwitchAccessor _twitchAccessor;
        private readonly BotConfig _botSettings;
        private readonly DiscordSocketClient _discordSocketClient;
        
        private bool IsLive { get; set; }
        private string TwitchId { get; set; }

        public TwitchService(ITwitchAccessor twitchAccessor, IOptions<BotConfig> botSettings, DiscordSocketClient discordSocketClient)
        {
            _twitchAccessor = twitchAccessor;
            _botSettings = botSettings.Value;
            _discordSocketClient = discordSocketClient;

            IsLive = false;
        }

        public async Task Init()
        {
            TwitchId = await _twitchAccessor.GetTwitchIdByLogin(_botSettings.TwitchChannelName);
            
            if(string.IsNullOrEmpty(TwitchId))
            {
                throw new ArgumentNullException("Twitch Channel isn't pulling a valid Twitch ID.");
            }

            var _twitchTimer = new Timer(async (e) => { await CheckStatus(); }, null, 0, 60000);
        }

        public async Task CheckStatus()
        {
            var stream = await _twitchAccessor.GetStreamById(TwitchId);

            if (stream?.stream != null)
            {
                if(!IsLive)
                {
                    var announcementChannel = _discordSocketClient.GetChannel(_botSettings.DiscordChannels.Announcements);
                    
                    if(announcementChannel == null)
                    {
                        throw new ArgumentNullException("Unable to find Announcement Discord Channel.");
                    }

                    await ((IMessageChannel)announcementChannel).SendMessageAsync(
                        $"{stream.stream.channel.display_name} is live with {stream.stream.game} - '{stream.stream.channel.status}' - {stream.stream.channel.url}");

                    IsLive = true;
                }
            }
            else
            {
                IsLive = false;
            }
        }
    }
}
