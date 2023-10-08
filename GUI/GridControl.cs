using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class GridControl : UserControl
    {
        public event EventHandler ButtonClick;

        private readonly GridButton[,] buttons = new GridButton[Rows, Columns];
        private readonly Label[] verticalLabels = new Label[Rows];
        private readonly Label[] horizontalLabels = new Label[Columns];

        private const int Rows = 10;
        private const int Columns = 10;


        public GridControl()
        {
            CreateButtons();
            AddLabels();
            InitializeComponent();
        }
        public void SetButtonColor(int row, int column, Color color)
        {
            buttons[row, column].BackColor = color;
        }
        public void SetButtonColorEvidence(int row, int column, Color color)
        {
            buttons[row, column].BackColor = color;
            buttons[row, column].UseVisualStyleBackColor = true;
        }
        public void ResetButtonColor()
        {
            foreach (var button in buttons)
            {
                button.BackColor = default(Color);
                button.UseVisualStyleBackColor = true;
            }
        }
        public void AnimateColor(int row, int column, Color color)
        {
            buttons[row, column].AnimateButtonColor(color);
        }

        private void AddLabels()
        {
            for (int r = 0; r < Rows; ++r)
            {
                Label rowL = new Label { Text = (r + 1).ToString(), TextAlign = ContentAlignment.MiddleCenter };
                verticalLabels[r] = rowL;
                Controls.Add(rowL);
            }
            for (int c = 0; c < Columns; ++c)
            {
                Label colL = new Label { Text = ((char)(c + 'a')).ToString(), TextAlign = ContentAlignment.MiddleCenter };
                horizontalLabels[c] = colL;
                Controls.Add(colL);
            }
        }
        private void CreateButtons()
        {
            for (int r = 0; r < Rows; ++r)
            {
                for (int c = 0; c < Columns; ++c)
                {
                    var button = new GridButton(r, c);
                    button.Click += Button_Click; 
                    buttons[r, c] = button;
                    Controls.Add(button);
                }

            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            ResizeButtons();
        }
        private void ResizeButtons()
        {
            int buttonW = Width / (Columns + 1);
            int buttonH = Height / (Rows + 1);
            int top = buttonH;
            for (int r = 0; r < Rows; ++r)
            {
                int left = buttonW;
                for (int c = 0; c < Columns; ++c)
                {
                    var button = buttons[r, c];
                    button.Left = left;
                    button.Top = top;
                    button.Width = buttonW;
                    button.Height = buttonH;
                    left += buttonW;
                }
                top += buttonH;
            }
            AddLabels(buttonW, buttonH);
        }

        private void AddLabels(int buttonW, int buttonH)
        {
            int x = buttonW;
            int y = 0;
            for (int c = 0; c < Columns; ++c)
            {
                horizontalLabels[c].Width = buttonW;
                horizontalLabels[c].Height = buttonH;
                horizontalLabels[c].Left = x;
                horizontalLabels[c].Top = y;
                x += buttonW;
            }
            x = 0;
            y = buttonH;
            for (int r = 0; r < Rows; ++r)
            {
                verticalLabels[r].Width = buttonW;
                verticalLabels[r].Height = buttonH;
                verticalLabels[r].Left = x;
                verticalLabels[r].Top = y;
                y += buttonH;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            ButtonClick?.Invoke(sender, e);
        }
    }
}
