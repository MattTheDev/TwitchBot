using System.Collections.Generic;
using System.Threading.Tasks;
using TwitchBot.Domain.Models.Twitch;

namespace TwitchBot.Contracts
{
    public interface ITwitchAccessor
    {
        Task<TwitchStreamResponse> GetStreamById(string twitchId);
        Task<string> GetTwitchIdByLogin(string name);
        Task<TwitchChannelResponse> GetTwitchChannelById(string twitchId);
    }
}
