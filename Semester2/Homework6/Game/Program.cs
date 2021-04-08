using System.Collections.Generic;
using GameTask;

var eventLoop = new EventLoop();
var game = new Game();
var log = new List<string>();

eventLoop.LeftHandler += game.OnLeft;
eventLoop.RightHandler += game.OnRight;
eventLoop.LeftHandler += () => log.Add("left");

eventLoop.RightHandler += () => log.Add("right");

eventLoop.Run();

eventLoop.LeftHandler -= game.OnLeft;
eventLoop.RightHandler -= game.OnRight;