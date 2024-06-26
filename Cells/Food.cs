using System;

namespace Pacman_Game
{
    internal abstract class Food : Cell
    {
        public Food()
        {
            IsWalkable= true;
        }
    }
}
