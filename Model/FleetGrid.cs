using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    using SquareSequence = IEnumerable<Square>;

    public class FleetGrid : Grid
    {
        public FleetGrid(int rows, int columns) : base(rows, columns)
        {
        }

        public void EliminateSquare(int row, int column)
        {
            squares[row, column] = null;
        }

        protected override bool IsSquareAvaliable(Square square)
        {
            return square != null ;
        }
    }
}
