using Pacman_Game.Characters;
using Pacman_Game.Objects;
using System;
using System.Threading;

namespace Pacman_Game
{
    internal class GameEngine : ICollisions, IWin
    {
        private Pacman player;
        Board board;
        const int FPS = 4;
        private readonly object lockObject = new object(); // Object for lock

        public GameEngine()
        {
            player = new Pacman(4, 5);
            board = new Board(player);
        }

        public void ghostCollisionAction(int ghostIndex)
        {
            int[] coordinates = board.Ghosts[ghostIndex].Coordinates;
            int[] pacmanCoordinates = player.Coordinates;
            Cell currentCell = Map.MapElements[coordinates[1], coordinates[0]];

            if (currentCell.IsWalkable)
            {
                if (coordinates[0] == pacmanCoordinates[0] && coordinates[1] == pacmanCoordinates[1])
                {
                    Console.WriteLine("\x1b[1m\x1b[31mGame Over\x1b[0m\x1b[37m");
                    Environment.Exit(0);
                }
            }
            else
            {
                board.Ghosts[ghostIndex].goBack();
            }
        }

        public void playerCollisionsAction()
        {
            int[] coordinates = player.Coordinates;
            Cell currentCell = Map.MapElements[coordinates[1], coordinates[0]];

            if (currentCell.IsWalkable)
            {
                for (int i = 0; i < board.NumOfGhost; i++)
                {
                    if (coordinates[0] == board.Ghosts[i].Coordinates[0] && coordinates[1] == board.Ghosts[i].Coordinates[1])
                    {
                        Console.WriteLine("\x1b[1m\x1b[31mGame Over\x1b[0m\x1b[37m");
                        Environment.Exit(0);
                    }
                }
                if (!(currentCell is Space))
                {
                    player.eat(currentCell);
                    board.NumOfFood--;
                    Map.MapElements[player.Coordinates[1], player.Coordinates[0]] = Map.Spc;
                }
            }
            else
            {
                player.goBack();
            }
        }

        public Board Board
        {
            get { return board; }
        }

        public void start()
        {
            TimerCallback callback1 = new TimerCallback(updatePrint);
            Timer printSpeed = new Timer(callback1, null, 0, (1000 / FPS));

            GameInput.Start(player);

            Console.WriteLine("Game started...");
        }

        public bool checkWin()
        {
            if (board.NumOfFood == 0)
            {
                return true;
            }
            return false;
        }

        public void updatePrint(object state)
        {
            Console.Clear();
            board.print();
            for (int i = 0; i < board.NumOfGhost; i++)
            {
                int mapWidth = Map.MapElements.GetLength(1);
                int mapHeight = Map.MapElements.GetLength(0);

                int ghostRightIndex = (board.Ghosts[i].Coordinates[0] + 1 + mapWidth) % mapWidth;
                int ghostLeftIndex = (board.Ghosts[i].Coordinates[0] - 1 + mapWidth) % mapWidth;
                int ghostUpIndex = (board.Ghosts[i].Coordinates[1] - 1 + mapHeight) % mapHeight;
                int ghostDownIndex = (board.Ghosts[i].Coordinates[1] + 1 + mapHeight) % mapHeight;

                bool ghostRightCellAvailability = Map.MapElements[board.Ghosts[i].Coordinates[1], ghostRightIndex].IsWalkable;
                bool ghostLeftCellAvailability = Map.MapElements[board.Ghosts[i].Coordinates[1], ghostLeftIndex].IsWalkable;
                bool ghostUpCellAvailability = Map.MapElements[ghostUpIndex, board.Ghosts[i].Coordinates[0]].IsWalkable;
                bool ghostDownCellAvailability = Map.MapElements[ghostDownIndex, board.Ghosts[i].Coordinates[0]].IsWalkable;

                board.Ghosts[i].randomDirection(ghostRightCellAvailability, ghostLeftCellAvailability, ghostUpCellAvailability, ghostDownCellAvailability);
                board.Ghosts[i].move(mapWidth, mapHeight);
                ghostCollisionAction(i);
            }

            lock (lockObject)
            {
                player.move(Map.MapElements.GetLength(1), Map.MapElements.GetLength(0));
                playerCollisionsAction();
            }

            if (checkWin())
            {
                
                Console.Clear();
                Console.WriteLine("██╗   ██╗ ██████╗ ██╗   ██╗    ██╗    ██╗██╗███╗   ██╗██╗\r\n╚██╗ ██╔╝██╔═══██╗██║   ██║    ██║    ██║██║████╗  ██║██║\r\n ╚████╔╝ ██║   ██║██║   ██║    ██║ █╗ ██║██║██╔██╗ ██║██║\r\n  ╚██╔╝  ██║   ██║██║   ██║    ██║███╗██║██║██║╚██╗██║╚═╝\r\n   ██║   ╚██████╔╝╚██████╔╝    ╚███╔███╔╝██║██║ ╚████║██╗\r\n   ╚═╝    ╚═════╝  ╚═════╝      ╚══╝╚══╝ ╚═╝╚═╝  ╚═══╝╚═╝");
                Console.WriteLine($"Score: {player.Score.Value}\n");
                Console.WriteLine("PRESS ANY KEY TO EXIT...");
                GameInput.Stop();
                Console.ReadKey(false);
                Environment.Exit(0);
            }
        }

    }
}
