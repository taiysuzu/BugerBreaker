using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickBreaker
{
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            // Goes to the game screen
            GameScreen gs = new GameScreen();
            Form form = this.FindForm();

            form.Controls.Add(gs);
            form.Controls.Remove(this);

            gs.Location = new Point((form.Width - gs.Width) / 2, (form.Height - gs.Height) / 2);
        }

        private void highscoreButton_Click(object sender, EventArgs e)
        {
            Screens.HighscoreScreen hs = new Screens.HighscoreScreen();
            Form form = this.FindForm();

            form.Controls.Add(hs);
            form.Controls.Remove(this);

            hs.Location = new Point((form.Width - hs.Width) / 2, (form.Height - hs.Height) / 2);
        }

        private void playButton_MouseEnter(object sender, EventArgs e)
        {
            playButton.ForeColor = Color.Lime;     
        }
        private void playButton_MouseLeave(object sender, EventArgs e)
        {
            playButton.ForeColor = Color.White;
        }
        private void instructionsButton_MouseEnter(object sender, EventArgs e)
        {
            instructionsButton.ForeColor = Color.Yellow;
        }
        private void instructionsButton_MouseLeave(object sender, EventArgs e)
        {
            instructionsButton.ForeColor = Color.White;
        }
        private void exitButton_MouseEnter(object sender, EventArgs e)
        {
            exitButton.ForeColor = Color.Red;
        }

        private void exitButton_MouseLeave(object sender, EventArgs e)
        {
            exitButton.ForeColor = Color.White;
        }
    }
}
