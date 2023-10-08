﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Vsite.Oom.Battleship.Model;
using System.Linq;
using System.Collections.Generic;

namespace Vsite.Oom.Battleship.UnitTests
{
    [TestClass]
    public class TestSquareEliminator
    {
        [TestMethod]
        public void ToEliminateReturns18ShipSquaresAndSurroundigSquaresForSquares4x3_4x6()
        {
            var eliminator = new SquareEliminator(10, 10);
            var squares = new List<Square> { new Square(4, 3), new Square(4, 4), new Square(4, 5), new Square(4, 6) };
            var toEliminate = eliminator.ToEliminate(squares);
            Assert.AreEqual(18, toEliminate.Count());
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(3, 2));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(5, 2));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(3, 7));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(5, 7));
        }

        [TestMethod]
        public void ToEliminateReturns8ShipSquaresAndSurroundigSquaresForSquares0x3_0x4()
        {
            var eliminator = new SquareEliminator(10, 10);
            var squares = new List<Square> { new Square(0, 3), new Square(0, 4) };
            var toEliminate = eliminator.ToEliminate(squares);
            Assert.AreEqual(8, toEliminate.Count());
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(0, 2));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(1, 2));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(0, 5));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(1, 5));
        }

        [TestMethod]
        public void ToEliminateReturns12ShipSquaresAndSurroundigSquaresForSquares7x5_9x5()
        {
            var eliminator = new SquareEliminator(10, 10);
            var squares = new List<Square> { new Square(7, 5), new Square(8, 5), new Square(9, 5) };
            var toEliminate = eliminator.ToEliminate(squares);
            Assert.AreEqual(12, toEliminate.Count());
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(6, 4));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(9, 4));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(6, 6));
            CollectionAssert.Contains(toEliminate.ToArray(), new Square(9, 6));
        }
    }
}
