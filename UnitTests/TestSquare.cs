using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using Vsite.Oom.Battleship.Model;

namespace UnitTests
{
    [TestClass]
    public class TestSquare
    {
        [TestMethod]
        public void ConstructorCreatesSquareWithGivenRowAndColumn()
        {
            var square = new Square(3, 4);
            Assert.AreEqual(3, square.Row);
            Assert.AreEqual(4, square.Column);
        }
        
        [TestMethod]
        public void ConstructorCreatesSquareWithInitialState()
        {
            var square = new Square(3, 4);
            Assert.AreEqual(SquareState.Initial, square.SquareState);
        }

        [TestMethod]
        public void SetSquareStateChangesSquareState()
        {
            var square = new Square(3, 4);
            square.ChangeState(SquareState.Hit);
            Assert.AreEqual(SquareState.Hit, square.SquareState);
        }
        [TestMethod]
        public void SquareSortingReturnsHorizontalSquaresWithLeftMostSquareFirst()
        {
            var squares = new List<Square> { new Square(3, 4), new Square(3, 5), new Square(3, 3) };
            squares.Sort((s1, s2) => s1.Row + s1.Column - s2.Row - s2.Column);
            Assert.AreEqual(new Square(3,3), squares.First());
            Assert.AreEqual(new Square(3,5), squares.Last());
        }
        [TestMethod]
        public void SquareSortingReturnsVerticalalSquaresWithLeftMostSquareFirst()
        {
            var squares = new List<Square> { new Square(4, 3), new Square(5, 3), new Square(3, 3) };
            squares.Sort((s1, s2) => s1.Row + s1.Column - s2.Row - s2.Column);
            Assert.AreEqual(new Square(3, 3), squares.First());
            Assert.AreEqual(new Square(5, 3), squares.Last());
        }
    }
}
