using System;

namespace Pacman_Game.Objects
{
    internal static class Map
    {
        static Wall wal = new Wall();
        static Space spc = new Space();
        static Dot dot = new Dot();
        static Fruit frt = new Fruit();
        static PowerPellet ppt = new PowerPellet();
        const int numOfFood = 68;

        static Cell[,] mapElements = {
            { wal, wal, wal, wal, wal, wal, wal, wal, wal, wal, wal, wal },
            { wal, dot, dot, dot, wal, dot, dot, dot, dot, dot, frt, wal },
            { wal, dot, wal, dot, wal, dot, wal, wal, wal, dot, wal, wal },
            { wal, dot, wal, dot, wal, dot, dot, dot, dot, dot, dot, wal },
            { wal, dot, wal, dot, wal, dot, wal, wal, dot, wal, dot, wal },
            { spc, dot, dot, dot, dot, dot, dot, dot, dot, dot, dot, spc },
            { wal, dot, wal, wal, wal, wal, wal, wal, wal, wal, dot, wal },
            { wal, dot, dot, dot, dot, dot, dot, dot, dot, dot, dot, wal },
            { wal, dot, wal, dot, wal, wal, ppt, wal, wal, dot, wal, wal },
            { wal, dot, wal, dot, dot, dot, dot, dot, wal, dot, dot, wal },
            { wal, dot, dot, dot, wal, frt, wal, dot, dot, dot, dot, wal },
            { wal, wal, wal, wal, wal, wal, wal, wal, wal, wal, wal, wal }
        };

        public static Cell[,] MapElements
        {
            get { return mapElements; }
        }

        public static Space Spc
        {
            get { return spc; }
        }

        public static int NumOfFood
        {
            get { return numOfFood; }
        }
    }
}
