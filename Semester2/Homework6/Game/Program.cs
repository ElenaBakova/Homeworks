namespace GameTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventLoop = new EventLoop();
            var game = new Game(args[0]);

            eventLoop.LeftHandler += game.MoveLeft;
            eventLoop.RightHandler += game.MoveRight;
            eventLoop.UpHandler += game.MoveUp;
            eventLoop.DownHandler += game.MoveDown;
            eventLoop.EscapeHandler += game.EscapeKey;

            eventLoop.Run();
        }
    }
}
