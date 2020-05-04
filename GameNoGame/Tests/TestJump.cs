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
        //[Test]
        //public void PLayerCanJump()
        //{
        //    var player = new Player(new Vector(100, 480), new Size(128, 128));
        //    var map = new Map(new List<Rectangle>
        //    {
        //        new Rectangle(new Vector(150, 700), new Size(1500, 300)),
        //        new Rectangle(new Vector(1600, 700), new Size(1000, 300)),
        //        new Rectangle(new Vector(600, 400), new Size(220, 340)),
        //        player

        //    });
        //    var game = new Game(map, player);

        //    game.Jump(player);
        //    var expectedLocation = new Vector(100, 480);

        //    Assert.AreEqual(expectedLocation, player.LeftTopLocation);
        //}

        //[Test]
        //public void PLayerCanNotJump_IfPlayerAlreadyJumped()
        //{
        //    var player = new Player(new Vector(100, 400), new Size(128, 128));
        //    var map = new Map(new List<Rectangle>
        //    {
        //        new Rectangle(new Vector(150, 700), new Size(1500, 300)),
        //        new Rectangle(new Vector(1600, 700), new Size(1000, 300)),
        //        new Rectangle(new Vector(600, 400), new Size(220, 340)),
        //        player

        //    });
        //    var game = new Game(map, player);

        //    game.Jump(player);
        //    var expectedLocation = new Vector(100, 400);

        //    Assert.AreEqual(expectedLocation, player.LeftTopLocation);
        //}

        [Test]
        public void PlayerFallsAfterStepFromPlatform()
        {
            var player = new Player(new Vector(0, 572), new Size(128, 128));
            var monster = new Monster(new Vector(10, 10), new Size(10, 10));
            var map = new Map(new List<Rectangle>
            {
                new Rectangle(new Vector(0, 700), new Size(128, 128)),
                new Rectangle(new Vector(0, 828), new Size(1000, 128)),
                player
            });
            var game = new Game(map, player, monster);
            var needJump = false;
            game.OnTick(new Vector(5, 0), needJump, Vector.Zero);

            for (var i = 1; i <= 12; i++)
                game.OnTick(Vector.Zero, needJump, Vector.Zero);
            var expectedLocation = new Vector(150, 700);

            Assert.AreEqual(expectedLocation, player.LeftTopLocation);
        }

        [Test]
        public void PlayerInTheSameLocationAfterJump()
        {
            var player = new Player(new Vector(0, 572), new Size(128, 128));
            var monster = new Monster(new Vector(10, 10), new Size(10, 10));
            var map = new Map(new List<Rectangle>
            {
                new Rectangle(new Vector(0, 700), new Size(1500, 300)),
                player
            });
            var game = new Game(map, player, monster);
            var needJump = true;
            game.OnTick(Vector.Zero, needJump, Vector.Zero);
            for (var i = 1; i <= 12; i++)
                game.OnTick(Vector.Zero, false, Vector.Zero);
            var expectedLocation = new Vector(0, 572);

            Assert.AreEqual(expectedLocation, player.LeftTopLocation);
        }

        [Test]
        public void PLayerFallsFromLessThanHalfHisHeight()
        {
            var player = new Player(new Vector(0, 566), new Size(128, 128));
            var monster = new Monster(new Vector(10, 10), new Size(10, 10));
            var map = new Map(new List<Rectangle>
            {
                new Rectangle(new Vector(0, 700), new Size(1500, 300)),
                player
            });
            var game = new Game(map, player, monster);
            game.OnTick(Vector.Zero, false, Vector.Zero);
            var expectedLocation = new Vector(0, 572);

            Assert.AreEqual(expectedLocation, player.LeftTopLocation);
        }

        [Test]
        public void PLayerFalls2Ticks()
        {
            var player = new Player(new Vector(0, 555), new Size(128, 128));
            var monster = new Monster(new Vector(10, 10), new Size(10, 10));
            var map = new Map(new List<Rectangle>
            {
                new Rectangle(new Vector(0, 700), new Size(1500, 300)),
                player
            });
            var game = new Game(map, player, monster);
            game.OnTick(Vector.Zero, false, Vector.Zero);//за 1 тик смещение должно быть 10 пикселей
            game.OnTick(Vector.Zero, false, Vector.Zero);
            var expectedLocation = new Vector(0, 572);

            Assert.AreEqual(expectedLocation, player.LeftTopLocation);
        }

        [Test]
        public void PLayerFallsFrom4HisHeight()
        {
            var player = new Player(new Vector(0, 0), new Size(128, 128));
            var monster = new Monster(new Vector(10, 10), new Size(10, 10));
            var map = new Map(new List<Rectangle>
            {
                new Rectangle(new Vector(0, 700), new Size(1500, 300)),
                player
            });
            var game = new Game(map, player, monster);
            for (var i = 1; i <= 58; i++)
                game.OnTick(Vector.Zero, false, Vector.Zero);
            var expectedLocation = new Vector(0, 572);

            Assert.AreEqual(expectedLocation, player.LeftTopLocation);
        }
    }
}
