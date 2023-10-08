using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{

    public enum SquareState
    {
        Initial,
        Eliminated,
        Missed,
        Hit,
        Sunken
    }
    public class Square : IEquatable<Square>
    {
        public Square(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public void ChangeState(SquareState newState)
        {
            if((int)state < (int)newState)
            {
                state = newState;
            }
        }

        public SquareState SquareState
        {
            get { return state; }
        }

        public readonly int Row;
        public readonly int Column;
        private SquareState state = SquareState.Initial;

        public bool Equals(Square other)
        {
            return other != null && Row == other.Row && Column == other.Column;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            return Equals((Square) obj);
        }

    }
}
