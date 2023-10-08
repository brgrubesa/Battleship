using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{

    public enum HitResult
    {
        Missed,
        Hit,
        Sunken
    }
    public class Ship
    {
        public Ship(IEnumerable<Square> squares)
        {
            Squares = squares;
        }

        public HitResult Shoot(int row, int column)
        {
            // TODO: implement this
            var found = Squares.FirstOrDefault(s => s.Row == row && s.Column == column);
            if (found == null)
                return HitResult.Missed;
            if (found.SquareState == SquareState.Sunken)
                return HitResult.Sunken;
            found.ChangeState(SquareState.Hit);
            if(Squares.All(s => s.SquareState == SquareState.Hit))
            {
                foreach(var s in Squares)
                {
                    s.ChangeState(SquareState.Sunken);
                }
                return HitResult.Sunken;
            }
            return HitResult.Hit;

          
        }

        public readonly IEnumerable<Square> Squares;
    }
}
