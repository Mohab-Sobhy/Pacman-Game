using System;

namespace Pacman_Game
{
    internal interface ICollisions
    {
        void playerCollisionsAction();
        void ghostCollisionAction(int ghostIndex);
    }
}
