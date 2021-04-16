using System;

namespace GameTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventLoop = new EventLoop();
            var game = new Game();

            eventLoop.LeftHandler += game.MoveLeft;
            eventLoop.RightHandler += game.MoveRight;
            eventLoop.UpHandler += game.MoveUp;
            eventLoop.DownHandler += game.MoveDown;

            eventLoop.Run();
        }
    }
}
