
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GUI
{
    class GridButton : System.Windows.Forms.Button
    {
        public int Row;
        public int Column;
        public GridButton(int row, int column)
        {
            Row = row;
            Column = column;
        }
        public void AnimateButtonColor(Color color)
        {
            var oldColor = BackColor;
            Task.Run(() => Animation(color, oldColor));
        }
        private void Animation(Color c1, Color c2)
        {
            for (int i = 0; i < 4; ++i)
            {
                BackColor = c1;
                Thread.Sleep(250);
                BackColor = c2;
                Thread.Sleep(250);
            }
            BackColor = c1;
        }
    }
}
