
# Twitchcord Welcomer

Integration of Discord to Twitch. Welcomes new Discord Members through Twitch chat.

# Installation

Follow these steps to set up the Discord bot and Twitch integration:

1. Create a Discord bot profile on the [Discord Developer Portal](https://discord.com/developers/applications).
2. In the `Bot` tab, enable all Privileged Gateway Intents.
3. Invite the bot to your Discord server.
4. Copy the `TOKEN` from the `Bot` tab and update the `discordToken` variable in `program.cs`.
5. Create a Twitch account on [Twitch](https://www.twitch.tv/).
6. To obtain an `ACCESS TOKEN`, visit [twitchtokengenerator.com](https://twitchtokengenerator.com/) and sign in with your Twitch account.
7. Scroll down to find `Available Token Scopes` and enable the scopes `chat:read` and `chat:edit`, then click `Generate Token!`.
8. In the `Generated Tokens` section, copy the `ACCESS TOKEN`.
9. Update the `twitchToken` variable in `program.cs` with the copied access token.
10. Replace the `twitchName` variable in `program.cs` with your Twitch account's username.
11. Replace the `twitchChannelName` variable in `program.cs` with the Twitch username where you want to send welcome messages.
12. Build the project.
