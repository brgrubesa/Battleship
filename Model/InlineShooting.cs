using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    using SquareSequence = IEnumerable<Square>;

    public class InlineShooting : INextTarget
    {
        public InlineShooting(EnemyGrid grid, List<Square> squaresHit, int shipLength)
        {
            this.grid = grid;
            this.squaresHit = squaresHit;
            this.shipLength = shipLength;
        }

        EnemyGrid grid;
        List<Square> squaresHit;
        int shipLength;
        Random random = new Random();

        public Square NextTarget()
        {
            squaresHit.Sort((s1, s2) => s1.Row + s1.Column - s2.Row - s2.Column);
            var first = squaresHit.First();
            var last = squaresHit.Last();
            List<SquareSequence> sequances = new List<SquareSequence>();
            if (first.Row == last.Row)
            {
                var left = grid.GetAvaliableSquares(first.Row, first.Column, Direction.Leftwards);
                if (left.Count() > 0)
                {
                    sequances.Add(left);
                }
                var right = grid.GetAvaliableSquares(last.Row, last.Column, Direction.Rightwards);
                if (right.Count() > 0)
                {
                    sequances.Add(right);
                }
            }
            else
            {
                var up = grid.GetAvaliableSquares(first.Row, first.Column, Direction.Upwards);
                if (up.Count() > 0)
                {
                    sequances.Add(up);
                }
                var down = grid.GetAvaliableSquares(last.Row, last.Column, Direction.Downwards);
                if (down.Count() > 0)
                {
                    sequances.Add(down);
                }
            }
            int index = random.Next(sequances.Count());
            return sequances[index].First();
            
        }
    }
}
