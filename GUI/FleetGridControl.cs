using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

using Vsite.Oom.Battleship.Model;

namespace GUI
{
    class FleetGridControl : GridControl
    {
        public void PlaceFleet(Fleet fleet)
        {
            ResetButtonColor();
            foreach (Ship ship in fleet.Ships)
            {
                foreach (Square square in ship.Squares)
                {
                    SetButtonColor(square.Row, square.Column, shipColor);
                }
            }
        }
        static readonly Color shipColor = Color.Blue;
    }
}
