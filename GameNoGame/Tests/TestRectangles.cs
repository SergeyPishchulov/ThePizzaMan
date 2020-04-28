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
    class TestRectangles
    {
        [Test]
        public void CreateRectangle()
        {
            var r = new Rectangle(new Vector(0, 0), new Size(10, 10));
            var map = new Map(new List<Rectangle> { r });
            Assert.AreEqual(map.MapObjects[0], r);
        }
        [Test]
        public void NotIntersectedRectangles()
        {
            var r1 = new Rectangle(new Vector(0, 0), new Size(10, 10));
            var r2 = new Rectangle(new Vector(50, 50), new Size(10, 10));
            var actual = Rectangle.AreIntersected(r1, r2);
            Assert.IsFalse(actual);
        }
        [Test]
        public void IntersectedRectanglesByLargeArea()
        {
            var r1 = new Rectangle(new Vector(0, 0), new Size(10, 10));
            var r2 = new Rectangle(new Vector(5, 5), new Size(10, 10));
            var actual = Rectangle.AreIntersected(r1, r2);
            Assert.IsTrue(actual);
        }

        [Test]
        public void IntersectedRectanglesBy1Point()
        {
            var r1 = new Rectangle(new Vector(0, 0), new Size(10, 10));
            var r2 = new Rectangle(new Vector(9, 9), new Size(10, 10));
            var actual = Rectangle.AreIntersected(r1, r2);
            Assert.IsTrue(actual);
        }

        [Test]
        public void IntersectedRectanglesByLine()
        {
            var r1 = new Rectangle(new Vector(0, 0), new Size(10, 10));
            var r2 = new Rectangle(new Vector(9, 0), new Size(10, 10));
            var actual = Rectangle.AreIntersected(r1, r2);
            Assert.IsTrue(actual);
        }
    }
}
