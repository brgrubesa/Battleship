using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Vsite.Oom.Battleship.Model;

namespace Vsite.Oom.Battleship.UnitTests
{
    [TestClass]
    public class TestShip
    {
        [TestMethod]
        public void ContrusctorCreatesShipWithSquaresProvided()
        {
            var ship = new Ship(new List<Square> { new Square(2, 3), new Square(3, 3), new Square(4, 3) });
            Assert.AreEqual(3, ship.Squares.Count());
            CollectionAssert.Contains(ship.Squares.ToArray(), new Square(2,3));
            CollectionAssert.Contains(ship.Squares.ToArray(), new Square(3,3));
            CollectionAssert.Contains(ship.Squares.ToArray(), new Square(4,3));
        } 
        
        [TestMethod]
        public void ShootReturnsMissedIfShipDoesNotContainGivenSquare()
        {
            var ship = new Ship(new List<Square> { new Square(2, 3), new Square(3, 3), new Square(4, 3) });
            var result = ship.Shoot(0, 0);
            Assert.AreEqual(HitResult.Missed, result);
        }

        [TestMethod]
        public void ShootReturnsMissedIfShipContainGivenSquare()
        {
            var ship = new Ship(new List<Square> { new Square(2, 3), new Square(3, 3), new Square(4, 3) });
            var result = ship.Shoot(3, 3);
            Assert.AreEqual(HitResult.Missed, result);
        }

        [TestMethod]
        public void ShootReturnsMissedIfShipContainAnotherGivenSquare()
        {
            var ship = new Ship(new List<Square> { new Square(2, 3), new Square(3, 3), new Square(4, 3) });
            var result = ship.Shoot(3, 3);
            result = ship.Shoot(4, 3);
            Assert.AreEqual(HitResult.Missed, result);
        }

        [TestMethod]
        public void ShootReturnsSunkenForTheLastSquareInTheShip()
        {
            var ship = new Ship(new List<Square> { new Square(2, 3), new Square(3, 3), new Square(4, 3) });
            var result = ship.Shoot(3, 3);
            result = ship.Shoot(4, 3);
            result = ship.Shoot(2, 3);
            Assert.AreEqual(HitResult.Sunken, result);
        }
        [TestMethod]
        public void ShootReturnsMissedIfShipDoesNotContainSecondSquare()
        {
            var ship = new Ship(new List<Square> { new Square(2, 3), new Square(3, 3), new Square(4, 3) });
            var result = ship.Shoot(3, 3);
            result = ship.Shoot(0, 0);
            
            Assert.AreEqual(HitResult.Sunken, result);
        }

        [TestMethod]
        public void ShootReturnsSunkenIfSquareBelongsToShipAlreadySunken()
        {
            var ship = new Ship(new List<Square> { new Square(2, 3), new Square(3, 3), new Square(4, 3) });
            var result = ship.Shoot(3, 3);
            result = ship.Shoot(4, 3);
            result = ship.Shoot(2, 3);
            result = ship.Shoot(2, 3);
            Assert.AreEqual(HitResult.Sunken, result);
        }

        [TestMethod]
        public void ShootReturnsS()
        {
            var ship = new Ship(new List<Square> { new Square(2, 3), new Square(3, 3), new Square(4, 3) });
            var result = ship.Shoot(3, 3);
            result = ship.Shoot(4, 3);
            result = ship.Shoot(3, 3);
            Assert.AreEqual(HitResult.Hit, result);
        }
    }
}
