using System;
using System.IO;

namespace GameTask
{
    /// <summary>
    /// Console game class
    /// </summary>
    public class Game
    {
        public Game(string path, Action<int, int> SetCursor, Action<string> Print)
        {
            this.SetCursor = SetCursor;
            this.Print = Print;
            ReadMap(path);
        }

        private int x;
        private int y;
        private Action<int, int> SetCursor;
        private Action<string> Print;
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
                        SetCursor(j, i);
                        Print("#");
                    }
                    else if (gameMap[i][j] == '@')
                    {
                        x = j;
                        y = i;
                        SetCursor(j, i);
                        Print("@");
                    }
                    else
                    {
                        SetCursor(j, i);
                        Print(" ");
                    }
                }
            }
        }

        /// <returns>Current left coordinate of character</returns>
        public int GetLeftCoordinate()
            => x;
        
        /// <returns>Current top coordinate of character</returns>
        public int GetTopCoordinate()
            => y;

        /// <summary>
        /// Moves character to the left
        /// </summary>
        public void MoveLeft(object sender, EventArgs args)
        {
            if (map[x - 1, y] != '#')
            {
                SetCursor(x, y);
                Print(" ");
                x--;
                SetCursor(x, y);
                Print("@");
            }
        }

        /// <summary>
        /// Moves character to the right
        /// </summary>
        public void MoveRight(object sender, EventArgs args)
        {
            if (map[x + 1, y] != '#')
            {
                SetCursor(x, y);
                Print(" ");
                x++;
                SetCursor(x, y);
                Print("@");
            }
        }

        /// <summary>
        /// Moves character up
        /// </summary>
        public void MoveUp(object sender, EventArgs args)
        {
            if (map[x, y - 1] != '#')
            {
                SetCursor(x, y);
                Print(" ");
                y--;
                SetCursor(x, y);
                Print("@");
            }
        }

        /// <summary>
        /// Moves character down
        /// </summary>
        public void MoveDown(object sender, EventArgs args)
        {
            if (map[x, y + 1] != '#')
            {
                SetCursor(x, y);
                Print(" ");
                y++;
                SetCursor(x, y);
                Print("@");
            }
        }

        /// <summary>
        /// Closes console
        /// </summary>
        public void EscapeKey(object sender, EventArgs args)
        {
            SetCursor(0, mapHeight + 1);
            Print("Bye");
            Environment.Exit(0);
        }
    }
}
