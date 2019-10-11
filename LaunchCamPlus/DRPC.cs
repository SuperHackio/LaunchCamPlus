using DiscordRPC;
using DiscordRPC.Logging;
using System;
using System.Text;
using System.Threading;

namespace DiscordRichPresence
{
    class DRPC
    {
        public DiscordRpcClient client;
        //public string DisplayA = "LCP Debugging Unit";
        public string DisplayA = "Super Mario Galaxy 1/2 Camera Editor";
        public string DisplayB = "No Cameras Loaded";
        //private static int DiscordPipe = -1;
        
        public void Initialize()
        {
            /*
            Create a discord client
            NOTE: 	If you are using Unity3D, you must use the full constructor and define
                     the pipe connection as DiscordRPC.IO.NativeNamedPipeClient
            */
            client = new DiscordRpcClient("523299319097327658")
            {
                //Set the logger
                Logger = new ConsoleLogger() { Level = LogLevel.Warning }
            };

            var timer = new System.Timers.Timer(150);
            timer.Elapsed += (sender, evt) => { client.Invoke(); };
            timer.Start();

            //Connect to the RPC
            client.Initialize();
            Update();
        }

        public void Update(string MessageA = "Super Mario Galaxy 1/2 Camera Editor", string MessageB = "No Cameras Loaded", string SmallImageKey = "active", string SmallImageMessage = "Active", bool IsDev = true)
        {
            if (IsDev)
                DisplayA = "LCP Debugging Unit";
            else
                DisplayA = MessageA;
            DisplayB = MessageB;

            client.SetPresence(new RichPresence()
            {
                Details = DisplayA,
                State = DisplayB,
                Assets = new Assets()
                {
                    LargeImageKey = "launchcamplus",
                    LargeImageText = "Launch Cam Plus V" + System.Windows.Forms.Application.ProductVersion + " by Super Hackio",
                    SmallImageKey = SmallImageKey,
                    SmallImageText = SmallImageMessage
                },
            });

            client.Invoke();
        }

        public void Quit()
        {
            client.Dispose();
        }
    }
}
