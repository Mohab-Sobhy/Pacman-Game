using System;

namespace Pacman_Game.Characters
{
    internal abstract class Character : IPrintable
    {
        protected Directions currentDirection;
        protected Speed currentSpeed;// cell per second
        protected int[] coordinates;
        protected int[] prevCoordinates;

        public Character(int coordinateX, int coordinateY)
        {
            currentSpeed = Speed.Regular;
            coordinates = new int[2] { coordinateX, coordinateY };
            prevCoordinates = new int[2] { coordinateX, coordinateY };
            currentDirection = Directions.Right;
        }

        public void move(int mapWidth, int mapHeight)
        {
            prevCoordinates[0] = coordinates[0];
            prevCoordinates[1] = coordinates[1];

            switch (currentDirection)
            {
                case Directions.Left:
                    coordinates[0]--;
                    break;
                case Directions.Right:
                    coordinates[0]++;
                    break;
                case Directions.Up:
                    coordinates[1]--;
                    break;
                case Directions.Down:
                    coordinates[1]++;
                    break;
            }

            // Ensure coordinates stay within the map bounds
            coordinates[0] = (coordinates[0] + mapWidth) % mapWidth;
            coordinates[1] = (coordinates[1] + mapHeight) % mapHeight;
        }

        public void setDirectionByKey(ConsoleKeyInfo keyInfo)
        {
            switch (keyInfo.Key)
            {
                case ConsoleKey.A:
                    currentDirection = Directions.Left;
                    break;
                case ConsoleKey.D:
                    currentDirection = Directions.Right;
                    break;
                case ConsoleKey.W:
                    currentDirection = Directions.Up;
                    break;
                case ConsoleKey.S:
                    currentDirection = Directions.Down;
                    break;
            }
        }

        public void goBack()
        {
            coordinates[0] = prevCoordinates[0];
            coordinates[1] = prevCoordinates[1];
        }

        public Directions CurrentDirection
        {
            get { return currentDirection; }
            set { currentDirection = value; }
        }

        public Speed CurrentSpeed
        {
            get { return currentSpeed; }
            set { currentSpeed = value; }
        }

        public int[] Coordinates
        {
            get { return coordinates; }
            set { coordinates = value; }
        }

        public int[] PrevCoordinates
        {
            get { return prevCoordinates; }
            set { prevCoordinates = value; }
        }

        public virtual void print(int lineNo)
        {
        }
    }
}