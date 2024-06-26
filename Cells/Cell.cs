using System;

namespace Pacman_Game
{
    internal abstract class Cell:IPrintable
    {
        private bool isWalkable;
        private int score;

        public bool IsWalkable { get { return isWalkable; } set { isWalkable = value; } }
        public int Score { get { return score; } set { score = value; } }
        public virtual void print(int lineNo) { }
    }
}
