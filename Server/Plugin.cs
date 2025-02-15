using HogWarp.Replicated;
using HogWarpChat;
using HogWarpSdk.Game;
using HogWarpSdk.Systems;
using System.Numerics;

namespace HogWarpChat
{

    public class Plugin
    {
        public Plugin()
        {
            var chat = new Chat();
        }
    }

    public class Chat 
    {
        enum House
        {
            Gryffindor,
            Hufflepuff,
            Ravenclaw,
            Slytherin,
            Unaffiliated
        }

        private static Logger log = new HogWarpSdk.Systems.Logger("HogWarpChat");
        public static event Action<Player, string>? OnChatMessage;
        private float sayDist = 400;
        private float shoutDist = 1000;
        private float whisperDist = 100;
        private static BP_HogWarpChat? chatActor;
        public static bool chatMsgOverride = false;
        private static Dictionary<string, Action<Player, string>> commands = new Dictionary<string, Action<Player, string>>();

        public Chat()
        {
            OnChatMessage += Chat_OnChatMessage;
            chatActor = HogWarpSdk.Server.World.Spawn<BP_HogWarpChat>()!;

            AddCommand("/me", SlashMe);
            AddCommand("/house", SlashHouse);
            AddCommand("/say", SlashDistMsg);
            AddCommand("/shout", SlashDistMsg);
            AddCommand("/whisper", SlashDistMsg);
        }

        public static void AddCommand(string command, Action<Player, string> action)
        {
            if (!commands.TryAdd(command, action))
            {
                log.Warn($"{command} command already exists!");
            }
        }

        public static void ReceiveMessage(Player player, string msg)
        {
            if (OnChatMessage != null)
                OnChatMessage.Invoke(player, msg);
        }

        public static void SendMessage(Player player, string msg)
        {
            if (chatActor != null)
                chatActor.RecieveMsg(player, msg);
        }

        private void SlashMe(Player player, string msg)
        {
            foreach (var p in HogWarpSdk.Server.PlayerSystem.Players)
            {
                SendMessage(p, "<Server>" + player.Username + msg.Substring(3) + "</>");
            }
        }

        private void SlashHouse(Player player, string msg)
        {
            foreach (var p in HogWarpSdk.Server.PlayerSystem.Players.Where(p => p.House == player.House))
            {
                SendMessage(p, "<img id=\"" + (House)player.House + "\"/><" + (House)player.House + ">" + player.Username + ": " + msg.Substring(7) + "</>");
            }
        }

        private void SlashDistMsg(Player player, string msg)
        {
            float msgDist = 0;
            int msgSub = 0;

            if (msg.StartsWith("/say")) { msgDist = sayDist; msgSub = 5; }
            else if (msg.StartsWith("/shout")) { msgDist = shoutDist; msgSub = 7; }
            else { msgDist = whisperDist; msgSub = 9; }

            foreach (var p in HogWarpSdk.Server.PlayerSystem.Players)
            {
                Vector3 plyPos = new Vector3(player.Position.X, player.Position.Y, player.Position.Z);
                Vector3 pPos = new Vector3(p.Position.X, p.Position.Y, p.Position.Z);

                if (Vector3.DistanceSquared(pPos, plyPos) <= msgDist)
                {
                    SendMessage(p, player.Username + ": " + msg.Substring(msgSub));
                }
            }
        }

        private void BuildMessage(Player player, string msg)
        {
            log.Info(player.Username + ": " + msg);

            if (commands.ContainsKey(msg.Split(" ")[0]))
            {
                commands[msg.Split(" ")[0]].DynamicInvoke(player, msg);
            }
            else
            {
                foreach (var p in HogWarpSdk.Server.PlayerSystem.Players)
                {
                    SendMessage(p, "<img id=\"" + (House)player.House + "\"/><" + (House)player.House + ">" + player.Username + ": </>" + msg);
                }
            } 
        }
        private void Chat_OnChatMessage(Player player, string msg)
        {
            if(!chatMsgOverride)
                BuildMessage(player, msg);
        }
    }
}

namespace HogWarp.Replicated
{
    public partial class BP_HogWarpChat
    {
        public partial void SendMsg(Player player, string Message)
        {
            Chat.ReceiveMessage(player, Message);
        }
    }
}
