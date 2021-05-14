using System;
using System.IO;

namespace GameTask
{
    /// <summary>
    /// Console game class
    /// </summary>
    public class Game
    {
        public Game(string path, Action<int, int> setCursor, Action<string> print)
        {
            this.setCursor = setCursor;
            this.print = print;
            ReadMap(path);
        }

        private int x;
        private int y;
        private Action<int, int> setCursor;
        private Action<string> print;
        private char[,] map;

        private void ReadMap(string path)
        {
            var gameMap = File.ReadAllLines(path);
            map = new char[gameMap[0].Length, gameMap.Length];

            for (int i = 0; i < gameMap.Length; i++)
            {
                for (int j = 0; j < gameMap[0].Length; j++)
                {
                    if (gameMap[i][j] == '#')
                    {
                        map[j, i] = '#';
                        setCursor(j, i);
                        print("#");
                    }
                    else if (gameMap[i][j] == '@')
                    {
                        x = j;
                        y = i;
                        setCursor(j, i);
                        print("@");
                    }
                    else
                    {
                        setCursor(j, i);
                        print(" ");
                    }
                }
            }
        }

        /// <summary>
        /// Returns pair x and y coordinate
        /// </summary>
        public (int x, int y) Coordinates => (x, y);

        private void MoveCoordinates(int xCoordinate, int yCoordinate)
        {
            if (map[x + xCoordinate, y + yCoordinate] != '#')
            {
                setCursor(x, y);
                print(" ");
                x += xCoordinate;
                y += yCoordinate;
                setCursor(x, y);
                print("@");
            }
        }

        /// <summary>
        /// Moves character to the left
        /// </summary>
        public void MoveLeft(object sender, EventArgs args)
            => MoveCoordinates(-1, 0);

        /// <summary>
        /// Moves character to the right
        /// </summary>
        public void MoveRight(object sender, EventArgs args)
            => MoveCoordinates(1, 0);

        /// <summary>
        /// Moves character up
        /// </summary>
        public void MoveUp(object sender, EventArgs args)
            => MoveCoordinates(0, -1);

        /// <summary>
        /// Moves character down
        /// </summary>
        public void MoveDown(object sender, EventArgs args)
            => MoveCoordinates(0, 1);

        /// <summary>
        /// Closes console
        /// </summary>
        public void EscapeKey(object sender, EventArgs args)
        {
            setCursor(0, map.GetLength(1) + 1);
            print("Bye");
            Environment.Exit(0);
        }
    }
}
