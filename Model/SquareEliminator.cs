using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class SquareEliminator
    {
        private readonly int rows;
        private readonly int columns;
        public SquareEliminator(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
        }

        
        public IEnumerable<Square> ToEliminate(IEnumerable<Square> shipSquares)
        {
            
            int rowStart = shipSquares.First().Row;
            if (rowStart > 0)
                --rowStart;
            int columnStart = shipSquares.First().Column;
            if (columnStart > 0)
                --columnStart;
            int rowEnd = shipSquares.Last().Row;
            if (rowEnd < rows - 1)
                ++rowEnd;
            int columnEnd = shipSquares.Last().Column;
            if (columnEnd < columns - 1)
                ++columnEnd;
            List<Square> squares = new List<Square>();
            for(int r = rowStart; r<= rowEnd; ++r)
            {
                for(int c = columnStart; c <= columnEnd; ++c)
                {
                    squares.Add(new Square(r, c));
                }
            }
            return squares;
        }
    }
}
