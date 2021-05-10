using System;
using NUnit.Framework;

namespace GameTask.Tests
{
    public class Tests
    {
        private Game game;

        [SetUp]
        public void Setup()
        {
            game = new Game("..\\..\\..\\TestMap.txt", (int x, int y) => { }, (string tempString) => { });
        }

        [Test]
        public void AfterGoingLeftCoordinateShouldDecrease()
        {
            var oldLeftCoordinate = game.Coordinates.Item1;
            game.MoveLeft(this, EventArgs.Empty);
            Assert.AreEqual(1, oldLeftCoordinate - game.Coordinates.Item1);
        }

        [Test]
        public void AfterGoingRightCoordinateShouldIncrease()
        {
            var oldLeftCoordinate = game.Coordinates.Item1;
            game.MoveRight(this, EventArgs.Empty);
            Assert.AreEqual(-1, oldLeftCoordinate - game.Coordinates.Item1);
        }

        [Test]
        public void AfterGoingUpCoordinateShouldIncrease()
        {
            var oldTopCoordinate = game.Coordinates.Item2;
            game.MoveUp(this, EventArgs.Empty);
            Assert.AreEqual(1, oldTopCoordinate - game.Coordinates.Item2);
        }

        [Test]
        public void AfterGoingDownCoordinateShouldIncrease()
        {
            var oldTopCoordinate = game.Coordinates.Item2;
            game.MoveDown(this, EventArgs.Empty);
            Assert.AreEqual(-1, oldTopCoordinate - game.Coordinates.Item2);
        }
        
        [Test]
        public void GoingToWallCoordinateNotChange()
        {
            game.MoveLeft(this, EventArgs.Empty);
            var oldLeftCoordinate = game.Coordinates.Item2;
            game.MoveLeft(this, EventArgs.Empty);
            Assert.AreEqual(oldLeftCoordinate, game.Coordinates.Item2);
        }
    }
}