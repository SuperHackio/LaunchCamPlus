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
        public string DisplayA = "Super Mario Galaxy Camera Editor";
        public string DisplayB = "No BCAM Loaded";
        //private static int DiscordPipe = -1;
        
        public void Initialize()
        {
            /*
            Create a discord client
            NOTE: 	If you are using Unity3D, you must use the full constructor and define
                     the pipe connection as DiscordRPC.IO.NativeNamedPipeClient
            */
            client = new DiscordRpcClient("523299319097327658");

            //Set the logger
            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

            var timer = new System.Timers.Timer(150);
            timer.Elapsed += (sender, evt) => { client.Invoke(); };
            timer.Start();

            //Connect to the RPC
            client.Initialize();
            Update();
        }

        public void Update(string MessageA = "Super Mario Galaxy Camera Editor", string MessageB = "No BCAM Loaded")
        {
            DisplayA = MessageA;
            DisplayB = MessageB;

            client.SetPresence(new RichPresence()
            {
                Details = DisplayA,
                State = DisplayB,
                Assets = new Assets()
                {
                    LargeImageKey = "launchcamplus",
                    LargeImageText = "Launch Cam Plus by Super Hackio"
                },
                Timestamps = Timestamps.Now
            });

            client.Invoke();
        }

        public void Quit()
        {
            client.Dispose();
        }
    }
}
