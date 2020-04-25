using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameNoGame.Tests
{
    [TestFixture]
    class TestJump
    {
        [Test]
        public void PLayerCanJump()
        {
            var player = new Player(new Vector(100, 480), new Size(128, 128));
            var map = new Map(new List<Rectangle>
            {
                new Rectangle(new Vector(150, 700), new Size(1500, 300)),
                new Rectangle(new Vector(1600, 700), new Size(1000, 300)),
                new Rectangle(new Vector(600, 400), new Size(220, 340)),
                player

            });
            var game = new Game(map, player);

            game.Jump(player, new Vector(0, -30));
            var expectedLocation = new Vector(100, 450);

            Assert.AreEqual(expectedLocation, player.Location);
        }

        [Test]
        public void PLayerCanNotJump_IfPlayerAlreadyJumped()
        {
            var player = new Player(new Vector(100, 400), new Size(128, 128));
            var map = new Map(new List<Rectangle>
            {
                new Rectangle(new Vector(150, 700), new Size(1500, 300)),
                new Rectangle(new Vector(1600, 700), new Size(1000, 300)),
                new Rectangle(new Vector(600, 400), new Size(220, 340)),
                player

            });
            var game = new Game(map, player);

            game.Jump(player, new Vector(0, -30));
            var expectedLocation = new Vector(100, 400);

            Assert.AreEqual(expectedLocation, player.Location);
        }
    }
}
