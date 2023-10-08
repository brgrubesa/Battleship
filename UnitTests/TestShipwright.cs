using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Vsite.Oom.Battleship.Model;

namespace Vsite.Oom.Battleship.UnitTests
{
    [TestClass]
    public class TestShipwright
    {
        [TestMethod]
        public void CreateFleetMethodCreatesFleetWithShiplenghtdProvided()
        {
            var shipLenghts = new int[] { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
            var shipwright = new Shipwright(10, 10, shipLenghts);
            var fleet = shipwright.CreateFleet();
            Assert.AreEqual(10, fleet.Ships.Count());
            Assert.AreEqual(1, fleet.Ships.Count(s => s.Squares.Count()== 5));
            Assert.AreEqual(2, fleet.Ships.Count(s => s.Squares.Count()== 4));
            Assert.AreEqual(3, fleet.Ships.Count(s => s.Squares.Count()== 3));
            Assert.AreEqual(4, fleet.Ships.Count(s => s.Squares.Count()== 2));
        }
    }
}
