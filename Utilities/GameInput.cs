using Pacman_Game.Characters;
using System;
using System.Threading;

namespace Pacman_Game
{
    internal static class GameInput
    {
        private static Thread inputThread;
        private static bool running;
        private static readonly object lockObject = new object();
        private static Pacman player;

        public static void Start(Pacman gamePlayer)
        {
            player = gamePlayer;
            running = true;
            inputThread = new Thread(ReadInput);
            inputThread.Start();
        }

        public static void Stop()
        {
            running = false;
            inputThread.Join();
        }

        private static void ReadInput()
        {
            while (running)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    lock (lockObject)
                    {
                        player.setDirectionByKey(keyInfo);
                    }
                }
                Thread.Sleep(10); // Reduce CPU usage
            }
        }
    }
}
