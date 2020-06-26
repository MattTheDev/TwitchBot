using System.Collections.Generic;

namespace TwitchBot.Domain.Models.Twitch
{
    public class TwitchUserResponse
    {
        public class User
        {
            public string display_name { get; set; }
            public string _id { get; set; }
            public string name { get; set; }
            public string type { get; set; }
            public string bio { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public string logo { get; set; }
        }

        public int _total { get; set; }
        public List<User> users { get; set; }
    }
}