using System;

namespace Pacman_Game.Characters
{
    internal class Score
    {
        int value;

        public Score()
        {
            value = 0;
        }

        public void increaseScore(int val)
        {
            value += val;
        }

        public int Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }
}
