using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Vsite.Oom.Battleship.Model;

namespace Vsite.Oom.Battleship.UnitTests
{
    [TestClass]
    public class TestFleetGrid
    {
        [TestMethod]
        public void ConstructorFor10RowsAnd10ColumnsCreatesGridWith100Squares()
        {
            var grid = new FleetGrid(10, 8);
            Assert.AreEqual(10, grid.Rows);
            Assert.AreEqual(8, grid.Columns);
            Assert.AreEqual(80, grid.Squares.Count());

            Assert.IsTrue(grid.Squares.Contains(new Square(0, 0)));
            Assert.IsTrue(grid.Squares.Contains(new Square(0, 7)));
            Assert.IsTrue(grid.Squares.Contains(new Square(9, 0)));
            Assert.IsTrue(grid.Squares.Contains(new Square(9, 7)));

            Assert.IsFalse(grid.Squares.Contains(new Square(10, 10)));
        }
        [TestMethod]

        public void GetAvailablePlacementsRreturns2PlacementsForShip3SquaresLongOnGridWith1Row4Columns()
        {
            var grid = new FleetGrid(1, 4);
            var placements = grid.GetAvailablePlacements(3);
            Assert.AreEqual(2, placements.Count());
        }

        [TestMethod]

        public void GetAvailablePlacementsRreturns3PlacementsForShip3SquaresLongOnGridWith5Row5Columns()
        {
            var grid = new FleetGrid(5, 1);
            var placements = grid.GetAvailablePlacements(3);
            Assert.AreEqual(3, placements.Count());
        }
        [TestMethod]

        public void GetAvailablePlacementsRreturns3PlacementsForShip2SquaresLongOnGridWith1Row6ColumnsSquare0_2Eliminated()
        {
            var grid = new FleetGrid(1, 6);
            grid.EliminateSquare(0, 2);
            var placements = grid.GetAvailablePlacements(2);
            Assert.AreEqual(3, placements.Count());
        }

        

    }
}
