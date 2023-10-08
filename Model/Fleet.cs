using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class Fleet
    {
        public void CreateShip(IEnumerable<Square> squares)
        {
            var ship = new Ship(squares);
            ships.Add(ship);
        }

        public HitResult Shoot(int row, int column)
        {
            foreach (var ship in ships)
            {
               var result = ship.Shoot(row, column);
               if(result != HitResult.Missed)
                {
                    return result;
                }
            }
            return HitResult.Missed;
        }

        public IEnumerable<Ship> Ships
        {
            get { return ships; }
        }

       

        private List<Ship> ships = new List<Ship>();
    }
}
