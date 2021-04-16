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
            var oldLeftCoordinate = game.GetLeftCoordinate();
            game.MoveLeft(this, EventArgs.Empty);
            Assert.AreEqual(1, oldLeftCoordinate - game.GetLeftCoordinate());
        }

        [Test]
        public void AfterGoingRightCoordinateShouldIncrease()
        {
            var oldLeftCoordinate = game.GetLeftCoordinate();
            game.MoveRight(this, EventArgs.Empty);
            Assert.AreEqual(-1, oldLeftCoordinate - game.GetLeftCoordinate());
        }

        [Test]
        public void AfterGoingUpCoordinateShouldIncrease()
        {
            var oldTopCoordinate = game.GetTopCoordinate();
            game.MoveUp(this, EventArgs.Empty);
            Assert.AreEqual(1, oldTopCoordinate - game.GetTopCoordinate());
        }

        [Test]
        public void AfterGoingDownCoordinateShouldIncrease()
        {
            var oldTopCoordinate = game.GetTopCoordinate();
            game.MoveDown(this, EventArgs.Empty);
            Assert.AreEqual(-1, oldTopCoordinate - game.GetTopCoordinate());
        }
        
        [Test]
        public void GoingToWallCoordinateNotChange()
        {
            game.MoveLeft(this, EventArgs.Empty);
            var oldLeftCoordinate = game.GetLeftCoordinate();
            game.MoveLeft(this, EventArgs.Empty);
            Assert.AreEqual(oldLeftCoordinate, game.GetLeftCoordinate());
        }
    }
}