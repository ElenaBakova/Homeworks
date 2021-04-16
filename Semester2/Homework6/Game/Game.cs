using System;

namespace GameTask
{
    public class Game
    {
        private int x;
        private int y;



        public void MoveLeft(object sender, EventArgs args) 
            => Console.WriteLine("Going left");

        public void MoveRight(object sender, EventArgs args)
            => Console.WriteLine("Going right");
        
        public void MoveUp(object sender, EventArgs args) 
            => Console.WriteLine("Going up");

        public void MoveDown(object sender, EventArgs args)
            => Console.WriteLine("Going down");
    }
}
