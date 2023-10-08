using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class Shipwright
    {
        public Shipwright(int rows, int columns, IEnumerable<int> shipLenghts)
        {
            this.rows = rows;
            this.columns = columns;
            this.shipLenghts = shipLenghts;
        }

        private readonly int rows;
        private readonly int columns;
        private readonly IEnumerable<int> shipLenghts;
        public Fleet CreateFleet()
        {
            for (int retry = 0;retry < 3; ++retry)
            {
                var grid = new FleetGrid(rows, columns);
                var fleet = new Fleet();
                var squareEliminator = new SquareEliminator(rows, columns);
                var selector = new Random();
                foreach (int lenght in shipLenghts)
                {
                    var avaliable = grid.GetAvailablePlacements(lenght);
                    if (avaliable.Count() == 0)
                        break;
                    var index = selector.Next(0, avaliable.Count());
                    var selected = avaliable.ElementAt(index);
                    fleet.CreateShip(selected);
                    var toEliminate = squareEliminator.ToEliminate(selected);
                    foreach (var square in toEliminate)
                        grid.EliminateSquare(square.Row, square.Column);
                }
                return fleet;
            }
            throw new InvalidOperationException();
        }
    }
}
