using DSharpPlus;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Logging;
using static Twitchcord_Welcomer.Program;

namespace Twitchcord_Welcomer
{
    public class DiscordBot
    {
        private DiscordClient? discordClient;

        public async Task RunAsync()
        {
            DiscordConfiguration discordConfig = new()
            {
                Intents = DiscordIntents.All,
                Token = discordToken,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Critical,
                LogUnknownEvents = true,
                AlwaysCacheMembers = true,
            };

            discordClient = new DiscordClient(discordConfig);
            discordClient.Ready += OnDiscordClientReady;
            discordClient.GuildMemberAdded += OnGuildMemberAdded;

            await discordClient.ConnectAsync();
            await Task.Delay(-1);
        }

        private Task OnGuildMemberAdded(DiscordClient sender, GuildMemberAddEventArgs args)
        {
            try
            {
                twitchClient.SendMessage(twitchChannel, $"{args.Member.Username} has joined the Discord server!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed trying to send welcome message: " + ex.Message);
            }
            
            return Task.CompletedTask;
        }

        private async Task OnDiscordClientReady(DiscordClient sender, ReadyEventArgs args) => await Console.Out.WriteLineAsync("Discord Bot is running!");
    }
}
