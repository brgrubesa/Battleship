using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vsite.Oom.Battleship.Model;
namespace GUI
{
    public partial class FormMain : Form
    {
        private static readonly Shipwright shipwright = new Shipwright(10, 10, new int[] { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 });
        private Gunnery gunnery;
        private Fleet enemyFleet;
        private Fleet myFleet;
        static readonly Random rnd = new Random();
        private int myShipsLeft = 10, enemyShipsLeft = 10;
        List<String> playerToStart = new List<String>() { "Person", "Computer" };
        
        public FormMain()
        {
            InitializeComponent();
        }
        private void CreateFleet() 
        {
            gunnery = new Gunnery(10, 10, new int[] { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 });
            myFleet = shipwright.CreateFleet();
            enemyFleet = shipwright.CreateFleet();
        }
        private void StartGame()
        {
            CurrentScore();
            int firstPlayer = rnd.Next(0, 2);
            if (playerToStart[firstPlayer].Equals("Person"))
            {
                MessageBox.Show("Your turn, SHOOT!");
            }
            else
            {
                MessageBox.Show("Computer shots first!");
                ComputerShots();
            }
            PlayGame.Enabled = false;
        }
        private void CurrentScore()
        {
            myShips.Text = myShipsLeft.ToString();
            enemyShips.Text = enemyShipsLeft.ToString();

        }
        private void ResetScore()
        {
            myShipsLeft = 10;
            enemyShipsLeft = 10;
            CurrentScore();
        }

        private void GenerateFleet_Click(object sender, EventArgs e)
        {

            CreateFleet();
            fleetGridControl1.PlaceFleet(myFleet);
            evidenceGridControl1.PlaceFleet(enemyFleet);
        }

        void ComputerShots()
        {

            var square = gunnery.NextTarget();
            var hitResult = myFleet.Shoot(square.Row, square.Column);
            gunnery.ProcessShootingResult(hitResult); 
                                                         
            switch (hitResult)                      
            {                                       
                case HitResult.Missed:                
                    fleetGridControl1.AnimateColor(square.Row, square.Column, Color.White);
                    break;                                                                   
                case HitResult.Hit:
                    CurrentScore();
                    fleetGridControl1.AnimateColor(square.Row, square.Column, Color.Red);
                    break;
                case HitResult.Sunken:
                    --myShipsLeft;
                    CurrentScore();
                    fleetGridControl1.AnimateColor(square.Row, square.Column, Color.Red);
                    if (myShipsLeft == 0) 
                    {
                        MessageBox.Show("Computer dipped you");
                        ResetScore(); 
                        PlayGame.Enabled = true;
                    }
                    break;
                default:
                    break;
            }
        }
        
        void HandleYourShot(int row, int column)
        {
            var hitResult = enemyFleet.Shoot(row, column);

            switch (hitResult)
            {
                case HitResult.Missed:
                    evidenceGridControl1.AnimateColor(row, column, Color.White);
                    break;
                case HitResult.Hit:
                    CurrentScore();
                    evidenceGridControl1.AnimateColor(row, column, Color.Red);
                    break;
                case HitResult.Sunken:
                    --enemyShipsLeft;
                    CurrentScore();
                    evidenceGridControl1.AnimateColor(row, column, Color.Red);
                    MessageBox.Show("Ship sunken!");
                    if (enemyShipsLeft == 0) 
                    {
                        MessageBox.Show("You won!", "Winner");
                        ResetScore();
                        PlayGame.Enabled = true;
                    }
                    break;
                default:
                    break;
            }
            ComputerShots();
        }

        private void PlayGame_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void evidenceGridControl1_ButtonClick(object sender, EventArgs e)
        {
            CurrentScore();
            GridButton button = sender as GridButton;
            if (button != null)
            {
                int row = button.Row;
                int column = button.Column;
                HandleYourShot(row, column);
                ++row;
            }
        }
    }
}
