using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Vsite.Oom.Battleship.Model;

namespace Vsite.Oom.Battleship.UnitTests
{
    [TestClass]
    public class TestRandomShooting
    {
        [TestMethod]
        public void NextTargetMethodReturnsOneOfAvailableSquares()
        {
            EnemyGrid grid = new EnemyGrid(10, 10);
            var shooting = new RandomShooting(grid, 2);
            var target = shooting.NextTarget();
            Assert.IsTrue(grid.Squares.Contains(target));

        }
    }
}
