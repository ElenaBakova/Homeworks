using System;
using NUnit.Framework;

namespace GameTask.Tests
{
    public class Tests
    {
        Game game;

        [SetUp]
        public void Setup()
        {
            game = new Game("..\\..\\..\\TestMap.txt", (int x, int y) => { }, (string tempString) => { });
        }

        [Test]
        public void AfterGoingLeftCoordinateShouldDecrease()
        {
            var oldLeftCoordinate = game.LeftCoordinate;
            game.MoveLeft(this, EventArgs.Empty);
            Assert.AreEqual(1, oldLeftCoordinate - game.LeftCoordinate);
        }

        [Test]
        public void AfterGoingRightCoordinateShouldIncrease()
        {
            var oldLeftCoordinate = game.LeftCoordinate;
            game.MoveRight(this, EventArgs.Empty);
            Assert.AreEqual(-1, oldLeftCoordinate - game.LeftCoordinate);
        }

        [Test]
        public void AfterGoingUpCoordinateShouldIncrease()
        {
            var oldTopCoordinate = game.TopCoordinate;
            game.MoveUp(this, EventArgs.Empty);
            Assert.AreEqual(1, oldTopCoordinate - game.TopCoordinate);
        }

        [Test]
        public void AfterGoingDownCoordinateShouldIncrease()
        {
            var oldTopCoordinate = game.TopCoordinate;
            game.MoveDown(this, EventArgs.Empty);
            Assert.AreEqual(-1, oldTopCoordinate - game.TopCoordinate);
        }
        
        [Test]
        public void GoingToWallCoordinateNotChange()
        {
            game.MoveLeft(this, EventArgs.Empty);
            var oldLeftCoordinate = game.LeftCoordinate;
            game.MoveLeft(this, EventArgs.Empty);
            Assert.AreEqual(oldLeftCoordinate, game.LeftCoordinate);
        }
    }
}