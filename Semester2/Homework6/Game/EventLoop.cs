using System;

namespace GameTask
{
    /// <summary>
    /// Class that generates events on pressing cursor buttons
    /// </summary>
    public class EventLoop
    {
        public EventHandler<EventArgs> LeftHandler = (sender, args) => { };
        public EventHandler<EventArgs> RightHandler = (sender, args) => { };
        public EventHandler<EventArgs> UpHandler = (sender, args) => { };
        public EventHandler<EventArgs> DownHandler = (sender, args) => { };
        public EventHandler<EventArgs> EscapeHandler = (sender, args) => { };
        
        public void Run()
        {
            while (true)
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        LeftHandler(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.RightArrow:
                        RightHandler(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.UpArrow:
                        UpHandler(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.DownArrow:
                        DownHandler(this, EventArgs.Empty);
                        break;
                    case ConsoleKey.Escape:
                        EscapeHandler(this, EventArgs.Empty);
                        break;
                }
            }
        }
    }
}
