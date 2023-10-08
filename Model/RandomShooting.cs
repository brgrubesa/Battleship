using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class RandomShooting : INextTarget
    {
        public RandomShooting(EnemyGrid targetGrid, int shipLength)
        {
            this.targetGrid = targetGrid;
            this.shipLength = shipLength;
        }

        private EnemyGrid targetGrid;
        private int shipLength;
        private Random random = new Random();
        public Square NextTarget()
        {
            var placements = targetGrid.GetAvailablePlacements(shipLength);
            var candidates = placements.SelectMany(s => s);
            var index = random.Next(candidates.Count());
            return candidates.ElementAt(index);
        }
    }
}
