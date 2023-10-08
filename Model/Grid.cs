using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    using SquareSequence = IEnumerable<Square>;

    public enum Direction
    {
        Upwards,
        Rightwards,
        Downwards,
        Leftwards
    }

    public abstract class Grid
    {
        
        public Grid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            squares = new Square[Rows, Columns];
            for (int r = 0; r < Rows; ++r)
            {
                for (int c = 0; c < Columns; ++c)
                {
                    squares[r, c] = new Square(r, c);
                }
            }
        }

        public IEnumerable<SquareSequence> GetAvailablePlacements(int lenght)
        {
            return GetHorizontalPlacements(lenght).Concat(GetVerticalPlacements(lenght));
        }

        public IEnumerable<SquareSequence> GetHorizontalPlacements(int lenght)
        {
            List<SquareSequence> result = new List<SquareSequence>();
            for (int r = 0; r < Rows; ++r)
            {
                int availableSquares = 0;
                for (int c = 0; c < Columns; ++c)
                {
                    if(IsSquareAvaliable(squares[r,c]))
                    //if (squares[r, c] != null && squares[r,c].SquareState == SquareState.Initial)
                    {
                        ++availableSquares;
                        if (availableSquares >= lenght)
                        {
                            List<Square> s = new List<Square>();
                            for (int cc = c - lenght + 1; cc <= c; ++cc)
                            {
                                s.Add(squares[r, cc]);
                            }
                            result.Add(s);
                        }
                    }
                    else
                    {
                        availableSquares = 0;
                    }
                }
            }
            return result;
        }

        public IEnumerable<SquareSequence> GetVerticalPlacements(int lenght)
        {
            List<SquareSequence> result = new List<SquareSequence>();
            for (int c = 0; c < Columns; c++)
            {
                int availableSquares = 0;
                for (int r = 0; r < Rows; ++r)
                {
                    if (IsSquareAvaliable(squares[r, c]))
                    //if (squares[r, c] != null && squares[r, c].SquareState == SquareState.Initial)
                    {
                        ++availableSquares;
                        if (availableSquares >= lenght)
                        {
                            List<Square> s = new List<Square>();
                            for (int rr = r - lenght + 1; rr <= r; ++rr)
                            {
                                s.Add(squares[rr, c]);
                            }
                            result.Add(s);
                        }
                    }
                    else
                    {
                        availableSquares = 0;
                    }
                }
            }
            return result;
        }

        protected abstract bool IsSquareAvaliable(Square square);

        public SquareSequence Squares
        {
            get { return squares.Cast<Square>().Where(s => s != null); }
        }

        
        public readonly int Rows;
        public readonly int Columns;

        protected Square[, ] squares;
    }
}
