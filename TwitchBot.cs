using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;
using static Twitchcord_Welcomer.Program;

namespace Twitchcord_Welcomer
{
    public class TwitchBot
    {
        public async Task RunAsync()
        {
            ConnectionCredentials credentials = new ConnectionCredentials(twitchName, twitchToken);
            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 750,
                ThrottlingPeriod = TimeSpan.FromSeconds(30)
            };

            WebSocketClient customClient = new WebSocketClient(clientOptions);
            twitchClient = new TwitchClient(customClient);
            twitchClient.Initialize(credentials, twitchName);

            twitchClient.OnConnected += OnConnectedTwitch;
            twitchClient.OnJoinedChannel += TwitchClient_OnJoinedChannel;

            twitchClient.Connect();
            await Task.Delay(-1);
        }

        private void TwitchClient_OnJoinedChannel(object? sender, OnJoinedChannelArgs e) => twitchChannel = e.Channel;

        private async void OnConnectedTwitch(object? sender, OnConnectedArgs e) => await Console.Out.WriteLineAsync("Twitch Bot is running!");
    }
}
