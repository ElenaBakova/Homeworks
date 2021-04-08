using System;

namespace GameTask
{
    public class EventLoop
    {
        public event Action LeftHandler;
        public event Action RightHandler;
        
        public void Run()
        {
            while (true)
            {
                var key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if (LeftHandler != null)
                            LeftHandler();
                        break;
                    case ConsoleKey.RightArrow:
                        if (RightHandler != null)
                            RightHandler();
                        break;
                }
            }
        }
    }
}
