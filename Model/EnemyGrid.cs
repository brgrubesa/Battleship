using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    using SquareSequence = IEnumerable<Square>;

    public class EnemyGrid : Grid
    {
        public EnemyGrid(int rows, int columns) : base(rows, columns)
        {
        }
        public void ChangeSquareState(int row, int column, SquareState newstate)
        {
            squares[row, column].ChangeState(newstate);
        }

        public SquareSequence GetAvaliableSquares(int row, int column, Direction direction)
        {
            int deltaRow = 0;
            int deltaColumn = 0;
            int counter = 0;
            switch (direction)
            {
                case Direction.Upwards:
                    deltaRow = -1;
                    counter = row;
                    break;
                case Direction.Downwards:
                    deltaRow = +1;
                    counter = Rows - row - 1;
                    break;
                case Direction.Leftwards:
                    deltaColumn = -1;
                    counter = column;
                    break;
                case Direction.Rightwards:
                    deltaColumn = +1;
                    counter = Columns - column - 1;
                    break;

            }
            var result = new List<Square>();
            for (int i = 0; i < counter; ++i)
            {
                row += deltaRow;
                column += deltaColumn;
                if (squares[row, column].SquareState == SquareState.Initial)
                {
                    result.Add(squares[row, column]);
                }
                else
                {
                    break;
                }
            }
            return result;
        }

        protected override bool IsSquareAvaliable(Square square)
        {
            return square.SquareState == SquareState.Initial;
        }
    }
}
