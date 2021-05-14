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
            var oldLeftCoordinate = game.Coordinates.x;
            game.MoveLeft(this, EventArgs.Empty);
            Assert.AreEqual(1, oldLeftCoordinate - game.Coordinates.x);
        }

        [Test]
        public void AfterGoingRightCoordinateShouldIncrease()
        {
            var oldLeftCoordinate = game.Coordinates.x;
            game.MoveRight(this, EventArgs.Empty);
            Assert.AreEqual(-1, oldLeftCoordinate - game.Coordinates.x);
        }

        [Test]
        public void AfterGoingUpCoordinateShouldIncrease()
        {
            var oldTopCoordinate = game.Coordinates.y;
            game.MoveUp(this, EventArgs.Empty);
            Assert.AreEqual(1, oldTopCoordinate - game.Coordinates.y);
        }

        [Test]
        public void AfterGoingDownCoordinateShouldIncrease()
        {
            var oldTopCoordinate = game.Coordinates.y;
            game.MoveDown(this, EventArgs.Empty);
            Assert.AreEqual(-1, oldTopCoordinate - game.Coordinates.y);
        }
        
        [Test]
        public void GoingToWallCoordinateNotChange()
        {
            game.MoveLeft(this, EventArgs.Empty);
            var oldLeftCoordinate = game.Coordinates.y;
            game.MoveLeft(this, EventArgs.Empty);
            Assert.AreEqual(oldLeftCoordinate, game.Coordinates.y);
        }
    }
}