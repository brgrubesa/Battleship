using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Vsite.Oom.Battleship.Model;

namespace Vsite.Oom.Battleship.UnitTests
{
    [TestClass]
    public class TestGunnery
    {
        [TestMethod]
        public void InitialCurrentTacticsIsRandom()
        {
            var g = new Gunnery(10, 10, new List<int> { 5, 3 });
            Assert.AreEqual(ShootingTactics.Random, g.CurrentTactics);
        }
        
        [TestMethod]
        public void CurrentTacticsChangesFromRandomToSurroundingAfterFirstSquareIsHit()
        {
            var g = new Gunnery(10, 10, new List<int> { 5, 3 });
            g.ProcessShootingResult(HitResult.Hit);
            Assert.AreEqual(ShootingTactics.Surrounding, g.CurrentTactics);
        }

        [TestMethod]
        public void CurrentTacticsRemainsSurroundingIfSquareIsMissed()
        {
            var g = new Gunnery(10, 10, new List<int> { 5, 3 });
            g.ProcessShootingResult(HitResult.Hit);
            g.ProcessShootingResult(HitResult.Missed);
            Assert.AreEqual(ShootingTactics.Surrounding, g.CurrentTactics);
        }

        [TestMethod]
        public void CurrentTacticsChangesFromSurroundingToInlineAfterSecondSquareIsHit()
        {
            var g = new Gunnery(10, 10, new List<int> { 5, 3 });
            g.ProcessShootingResult(HitResult.Hit);
            g.ProcessShootingResult(HitResult.Missed);
            g.ProcessShootingResult(HitResult.Hit);
            Assert.AreEqual(ShootingTactics.Inline, g.CurrentTactics);
        }

        [TestMethod]
        public void CurrentTacticsChangesFromRandomToInlineAfterSecondSquareIsSunken()
        {
            var g = new Gunnery(10, 10, new List<int> { 5, 3 });
            g.ProcessShootingResult(HitResult.Hit);
            g.ProcessShootingResult(HitResult.Missed);
            g.ProcessShootingResult(HitResult.Sunken);
            Assert.AreEqual(ShootingTactics.Random, g.CurrentTactics);
        }

        [TestMethod]
        public void CurrentTacticsRemainInlineIfSquareIsMissed()
        {
            var g = new Gunnery(10, 10, new List<int> { 5, 3 });
            g.ProcessShootingResult(HitResult.Hit);
            g.ProcessShootingResult(HitResult.Hit);
            g.ProcessShootingResult(HitResult.Missed);
            Assert.AreEqual(ShootingTactics.Inline, g.CurrentTactics);
        }

        [TestMethod]
        public void CurrentTacticsRemainInlineIfSquareIsHit()
        {
            var g = new Gunnery(10, 10, new List<int> { 5, 3 });
            g.ProcessShootingResult(HitResult.Hit);
            g.ProcessShootingResult(HitResult.Hit);
            g.ProcessShootingResult(HitResult.Hit);
            Assert.AreEqual(ShootingTactics.Inline, g.CurrentTactics);
        }

        [TestMethod]
        public void CurrentTacticsChangesFromInlineToRandomIfSquareIsSunken()
        {
            var g = new Gunnery(10, 10, new List<int> { 5, 3 });
            g.ProcessShootingResult(HitResult.Hit);
            g.ProcessShootingResult(HitResult.Hit);
            g.ProcessShootingResult(HitResult.Sunken);
            Assert.AreEqual(ShootingTactics.Random, g.CurrentTactics);
        }

    }
}
