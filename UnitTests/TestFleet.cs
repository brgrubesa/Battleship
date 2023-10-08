using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Vsite.Oom.Battleship.Model;

namespace Vsite.Oom.Battleship.UnitTests
{
    [TestClass]
    public class TestFleet
    {
        [TestMethod]
        public void CreateShipAddsNewShipToFleet()
        {
            var fleet = new Fleet();
            Assert.AreEqual(0, fleet.Ships.Count());

            fleet.CreateShip(new List<Square> { new Square(2, 3), new Square(3, 3), new Square(4, 3) });
            Assert.AreEqual(1, fleet.Ships.Count());

            fleet.CreateShip(new List<Square> { new Square(5, 5), new Square(5, 6), new Square(5, 7) });
            Assert.AreEqual(2, fleet.Ships.Count());
        }
    }
}
