
namespace BrickBreaker
{
    partial class GameOverScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.highscoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // menuButton
            // 
            this.menuButton.BackColor = System.Drawing.Color.White;
            this.menuButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.menuButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.menuButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.menuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuButton.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuButton.Location = new System.Drawing.Point(223, 432);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(194, 77);
            this.menuButton.TabIndex = 1;
            this.menuButton.Text = "Menu";
            this.menuButton.UseVisualStyleBackColor = false;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.White;
            this.exitButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(443, 432);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(194, 77);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // highscoreLabel
            // 
            this.highscoreLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.highscoreLabel.Location = new System.Drawing.Point(243, 108);
            this.highscoreLabel.Name = "highscoreLabel";
            this.highscoreLabel.Size = new System.Drawing.Size(379, 207);
            this.highscoreLabel.TabIndex = 3;
            this.highscoreLabel.Text = "label1";
            // 
            // GameOverScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.highscoreLabel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.menuButton);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "GameOverScreen";
            this.Size = new System.Drawing.Size(854, 542);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button menuButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label highscoreLabel;
    }
}
