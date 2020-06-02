using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameNoGame.Tests
{
    [TestFixture]
    class TestWalls
    {
        [Test]
        public void PlayerCanNOTGoThroughWall()
        {
            var horizontal = new Rectangle(new Vector(0, 0), new Size(400, 100));
            var vertical = new Rectangle(new Vector(200, 0), new Size(2, 1000));
            var player = new Player(new Vector(-100, 200), new Size(128, 128));
            var map = new Map(new List<Rectangle> { horizontal, vertical,player });
            var actually=map.CanMove((Rectangle)player,new Vector(300, 0));
            
            Assert.IsFalse(actually);
        }

        [Test]
        public void PlayerCanGoThroughMonster()
        {
            var horizontal = new Rectangle(new Vector(0, 0), new Size(400, 100));
            var player = new Player(new Vector(-100, 200),new Size(128,128));
            var monster = new Monster(new Vector(200, 200));
            var map = new Map(new List<Rectangle> { horizontal, monster, player });
            var actually = map.CanMove((Rectangle)player, new Vector(300, 0));

            Assert.IsTrue(actually);
        }

    }
}
