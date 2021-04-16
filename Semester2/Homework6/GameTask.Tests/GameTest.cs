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
            game = new Game("..\\..\\..\\TestMap.txt");
        }

        [Test]
        public void AfterGoingLeftCoordinateShouldDecrease()
        {
            var oldLeftCoordinate = game.GetLeftCoordinate();
            game.MoveLeft(this, EventArgs.Empty);
            Assert.AreEqual(1, oldLeftCoordinate - 2)
        }
    }
}