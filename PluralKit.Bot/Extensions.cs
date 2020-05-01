using DSharpPlus;
using DSharpPlus.Entities;

using System.Net.WebSockets;

namespace PluralKit.Bot
{
    static class Extensions
    {
        //Unfortunately D#+ doesn't expose the connection state of the client, so we have to test for it instead
        public static bool IsConnected(this DiscordClient client)
        {
            try
            {
                client.GetConnectionsAsync().GetAwaiter().GetResult();
            }
            catch(WebSocketException)
            {
                return false;
            }
            return true;
        }

        public static bool HasAvatar(this DiscordUser user)
        {
            return user.AvatarUrl != user.DefaultAvatarUrl;
        }
    }
}