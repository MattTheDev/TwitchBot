using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using TwitchBot.Contracts;
using TwitchBot.Domain.Models.Bot;
using TwitchBot.Domain.Models.Twitch;

namespace TwitchBot.Accessors
{
    public class TwitchAccessor : ITwitchAccessor
    {
        private readonly BotConfig _botSettings;

        public TwitchAccessor(IOptions<BotConfig> botSettings)
        {
            _botSettings = botSettings.Value;
        }

        public async Task<T> ApiHelper<T>(string url)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                request.Headers["Client-Id"] = _botSettings.Tokens.Twitch;
                request.Accept = "application/vnd.twitchtv.v5+json";
                var response = await request.GetResponseAsync().ConfigureAwait(false);
                var responseText = "";

                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    responseText = await sr.ReadToEndAsync().ConfigureAwait(false);
                }

                return JsonConvert.DeserializeObject<T>(responseText);
            }
            catch (Exception)
            {
                // Error on the return. Return null, and handle it up the call stack.
                return default(T);
            }
        }

        public Task<TwitchStreamResponse> GetStreamById(string twitchId)
        {
            return ApiHelper<TwitchStreamResponse>($"https://api.twitch.tv/kraken/streams/{twitchId}");
        }

        public Task<TwitchChannelResponse> GetTwitchChannelById(string twitchId)
        {
            return ApiHelper<TwitchChannelResponse>($"https://api.twitch.tv/kraken/channels/{twitchId}?api_version=5");
        }

        public async Task<string> GetTwitchIdByLogin(string name)
        {
            var response = await ApiHelper<TwitchUserResponse>($"https://api.twitch.tv/kraken/users?login={name}&api_version=5");

            if (response?.users != null && response.users.Count > 0)
            {
                return response.users[0]._id;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
