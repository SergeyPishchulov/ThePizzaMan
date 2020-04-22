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
        public void TheSameLocationAfterJump()
        {
            var horizontal = new Rectangle(new Vector(0, 0), new Size(400, 100));
            var player = new Player(new Vector(-100, 200), new Size(128,128));
            var map = new Map(new List<Rectangle> { horizontal, player });
            var game = new Game(map, player);

            game.MakeGravity();
            game.Jump(player);
            Thread.Sleep(1000);


            Assert.IsTrue(player.Location.Y == 200);
            Assert.IsTrue(player.Location.X == -100);
        }

        [Test]
        public void PlayerJumpsHigherThanHisHeight()
        {
            var horizontal = new Rectangle(new Vector(0, 0), new Size(400, 100));
            var player = new Player(new Vector(-100, 200), new Size(128, 128));
            var map = new Map(new List<Rectangle> { horizontal, player });
            var game = new Game(map, player);

            var playerWasHigherThanHisHeight = false;
            game.MakeGravity();
            game.Jump(player);
            while (map.CanMove(player, new Vector(0, -1)))
            {
                if (player.Location.Y >= player.Location.Y + player.Size.Height)
                    playerWasHigherThanHisHeight = true;
            }

            Assert.IsTrue(playerWasHigherThanHisHeight);
        }
    }
}
