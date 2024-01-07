using DSharpPlus;
using Newtonsoft.Json;
using TwitchLib.Client;

namespace Twitchcord_Welcomer
{
    public class Program
    {
        //SETTINGS
        public static string discordToken = "";
        public static string twitchToken = "";
        public static string twitchName = ""; 
        public static string twitchChannelName = "";
        public static DiscordClient? discordClient;
        public static TwitchClient? twitchClient;
        public static string? twitchChannel;

        static async Task Main(string[] args)
        {
            string json = File.ReadAllText("config.json");

            Configuration config = JsonConvert.DeserializeObject<Configuration>(json);

            discordToken = config.DiscordToken;
            twitchToken = config.TwitchToken;
            twitchName = config.TwitchName;
            twitchChannelName = config.TwitchChannelName;

            DiscordBot bot = new();
            var discordBotTask = bot.RunAsync();

            TwitchBot twitchBot = new();
            var twitch = twitchBot.RunAsync();

            await twitch;
            await discordBotTask;
        }
    }
}