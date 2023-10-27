using DSharpPlus;
using TwitchLib.Client;

namespace Twitchcord_Welcomer
{
    public class Program
    {
        //SETTINGS, its not recommended to save sensitive variables in the source code :)
        public static string discordToken = ""; // Discord bot Token.
        public static string twitchToken = ""; //Twitch bot's ACCESS TOKEN.
        public static string twitchName = ""; //Twitch bot's name.
        public static string twitchChannelName = ""; //Twitch name to send welcome messages in.

        //VARIABLES
        public static DiscordClient? discordClient;
        public static TwitchClient? twitchClient;
        public static string? twitchChannel;

        static async Task Main(string[] args)
        {
            DiscordBot bot = new();
            var discordBotTask = bot.RunAsync();

            TwitchBot twitchBot = new();
            var twitch = twitchBot.RunAsync();

            await twitch;
            await discordBotTask;
        }
    }
}