using System;
using System.IO;

namespace GameTask
{
    /// <summary>
    /// Console game class
    /// </summary>
    public class Game
    {
        public Game(string path)
        {
            ReadMap(path);
        }

        private int x;
        private int y;
        private char[,] map;
        private int mapHeight;

        private void ReadMap(string path)
        {
            var gameMap = File.ReadAllLines(path);
            map = new char[gameMap[0].Length, gameMap.Length];
            mapHeight = gameMap.Length;

            for (int i = 0; i < gameMap.Length; i++)
            {
                for (int j = 0; j < gameMap[0].Length; j++)
                {
                    if (gameMap[i][j] == '#')
                    {
                        map[j, i] = '#';
                        Console.SetCursorPosition(j, i);
                        Console.Write('#');
                    }
                    else if (gameMap[i][j] == '@')
                    {
                        x = j;
                        y = i;
                        Console.SetCursorPosition(j, i);
                        Console.Write('@');
                    }
                    else
                    {
                        Console.SetCursorPosition(j, i);
                        Console.Write(' ');
                    }
                }
            }
        }

        /// <summary>
        /// Moves character to the left
        /// </summary>
        public void MoveLeft(object sender, EventArgs args)
        {
            if (map[x - 1, y] != '#')
            {
                Console.SetCursorPosition(x, y);
                Console.Write(' ');
                x--;
                Console.SetCursorPosition(x, y);
                Console.Write('@');
            }
        }

        /// <summary>
        /// Moves character to the right
        /// </summary>
        public void MoveRight(object sender, EventArgs args)
        {
            if (map[x + 1, y] != '#')
            {
                Console.SetCursorPosition(x, y);
                Console.Write(' ');
                x++;
                Console.SetCursorPosition(x, y);
                Console.Write('@');
            }
        }

        /// <summary>
        /// Moves character up
        /// </summary>
        public void MoveUp(object sender, EventArgs args)
        {
            if (map[x, y - 1] != '#')
            {
                Console.SetCursorPosition(x, y);
                Console.Write(' ');
                y--;
                Console.SetCursorPosition(x, y);
                Console.Write('@');
            }
        }

        /// <summary>
        /// Moves character down
        /// </summary>
        public void MoveDown(object sender, EventArgs args)
        {
            if (map[x, y + 1] != '#')
            {
                Console.SetCursorPosition(x, y);
                Console.Write(' ');
                y++;
                Console.SetCursorPosition(x, y);
                Console.Write('@');
            }
        }

        /// <summary>
        /// Closes console
        /// </summary>
        public void EscapeKey(object sender, EventArgs args)
        {
            Console.SetCursorPosition(0, mapHeight + 1);
            Console.Write("Bye");
            Environment.Exit(0);
        }
    }
}
