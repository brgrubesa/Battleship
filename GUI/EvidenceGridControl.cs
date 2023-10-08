using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vsite.Oom.Battleship.Model;
using System.Drawing;
namespace GUI
{
    class EvidenceGridControl : GridControl
    {
        public void PlaceFleet(Fleet fleet)
        {
            ResetButtonColor();
            foreach (Ship ship in fleet.Ships)
            {
                foreach (Square square in ship.Squares)
                {
                    SetButtonColorEvidence(square.Row, square.Column, shipColor);
                }
            }
        }
        static readonly Color shipColor = default(Color);
    }  
}
