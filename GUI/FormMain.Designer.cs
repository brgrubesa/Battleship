
namespace GUI
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fleetGridControl1 = new GUI.FleetGridControl();
            this.evidenceGridControl1 = new GUI.EvidenceGridControl();
            this.myShips = new System.Windows.Forms.Label();
            this.enemyShips = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PlayGame = new System.Windows.Forms.Button();
            this.GenerateFleet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fleetGridControl1
            // 
            this.fleetGridControl1.Location = new System.Drawing.Point(30, 54);
            this.fleetGridControl1.Name = "fleetGridControl1";
            this.fleetGridControl1.Size = new System.Drawing.Size(290, 296);
            this.fleetGridControl1.TabIndex = 0;
            // 
            // evidenceGridControl1
            // 
            this.evidenceGridControl1.Location = new System.Drawing.Point(457, 54);
            this.evidenceGridControl1.Name = "evidenceGridControl1";
            this.evidenceGridControl1.Size = new System.Drawing.Size(290, 296);
            this.evidenceGridControl1.TabIndex = 1;
            this.evidenceGridControl1.ButtonClick += new System.EventHandler(this.evidenceGridControl1_ButtonClick);
            // 
            // myShips
            // 
            this.myShips.AutoSize = true;
            this.myShips.Location = new System.Drawing.Point(174, 35);
            this.myShips.Name = "myShips";
            this.myShips.Size = new System.Drawing.Size(35, 13);
            this.myShips.TabIndex = 2;
            this.myShips.Text = "label1";
            // 
            // enemyShips
            // 
            this.enemyShips.AutoSize = true;
            this.enemyShips.Location = new System.Drawing.Point(624, 35);
            this.enemyShips.Name = "enemyShips";
            this.enemyShips.Size = new System.Drawing.Size(35, 13);
            this.enemyShips.TabIndex = 3;
            this.enemyShips.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ships left in your fleet:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(493, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Ships Left in enemy fleet:";
            // 
            // PlayGame
            // 
            this.PlayGame.Location = new System.Drawing.Point(201, 393);
            this.PlayGame.Name = "PlayGame";
            this.PlayGame.Size = new System.Drawing.Size(75, 23);
            this.PlayGame.TabIndex = 6;
            this.PlayGame.Text = "Shot Away";
            this.PlayGame.UseVisualStyleBackColor = true;
            this.PlayGame.Click += new System.EventHandler(this.PlayGame_Click);
            // 
            // GenerateFleet
            // 
            this.GenerateFleet.Location = new System.Drawing.Point(61, 393);
            this.GenerateFleet.Name = "GenerateFleet";
            this.GenerateFleet.Size = new System.Drawing.Size(107, 23);
            this.GenerateFleet.TabIndex = 7;
            this.GenerateFleet.Text = "Generate Fleet";
            this.GenerateFleet.UseVisualStyleBackColor = true;
            this.GenerateFleet.Click += new System.EventHandler(this.GenerateFleet_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GenerateFleet);
            this.Controls.Add(this.PlayGame);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.enemyShips);
            this.Controls.Add(this.myShips);
            this.Controls.Add(this.evidenceGridControl1);
            this.Controls.Add(this.fleetGridControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FleetGridControl fleetGridControl1;
        private EvidenceGridControl evidenceGridControl1;
        private System.Windows.Forms.Label myShips;
        private System.Windows.Forms.Label enemyShips;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button PlayGame;
        private System.Windows.Forms.Button GenerateFleet;
    }
}

