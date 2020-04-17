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
    class TestPlayer
    {
        //[Test]
        //public void TestMovePLayerToRight()
        //{
        //    var player = new Player(new Vector(100, 100));
        //    player.Move(new Vector(128, 0));

        //    var expected = new Vector(228, 100);
        //    Assert.AreEqual(expected, player.Location);
        //}

        //[Test]
        //public void TestMovePLayerToLeft()
        //{
        //    var player = new Player(new Vector(100, 100));
        //    Map.Move(player,new Vector(-10, 0);

        //    var expected = new Vector(90, 100);
        //    Assert.AreEqual(expected, player.Location);
        //}

        [Test]
        public void TestPlayerIsAlive()
        {
            var player = new Player(new Vector(100, 100));
            Assert.AreEqual(true, player.IsAlive());
        }        
    }
}
