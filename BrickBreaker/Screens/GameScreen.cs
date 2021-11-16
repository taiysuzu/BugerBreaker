/*  Created by: Team 3 - Taiyo, Charlie, Manny, Miguel, Matthew, Isaac
 *  Project: Brick Breaker
 *  Date: 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Xml;

namespace BrickBreaker
{
    public partial class GameScreen : UserControl
    {
        #region global values

        //player1 button control keys - DO NOT CHANGE
        Boolean leftArrowDown, rightArrowDown;

        // Game values
        int lives;
        int score;

        // Paddle and Ball objects
        Paddle paddle;
        Ball ball;

        // list of all blocks for current level
        List<Block> blocks = new List<Block>();
        string[] powerUps = new string[5];

        // Brushes
        SolidBrush paddleBrush = new SolidBrush(Color.White);
        SolidBrush ballBrush = new SolidBrush(Color.White);
        SolidBrush textBrush = new SolidBrush(Color.White);
        SolidBrush blockBrush = new SolidBrush(Color.Red);
        SolidBrush blockBrush2 = new SolidBrush(Color.Yellow);
        SolidBrush blockBrush3 = new SolidBrush(Color.Green);
        SolidBrush blockBrush4 = new SolidBrush(Color.Blue);

        //font for text
        Font textFont = new Font("Arial", 16);

        public static Random randGen = new Random();
        public static string powerImage;
        #endregion

        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }


        public void OnStart()
        {
            string[] powerUps = { "BrickBreaker.Properties.Resources.Fire_flower", "BrickBreaker.Properties.Resources.Super_Star", "BrickBreaker.Properties.Resources.Double_Cherry", "BrickBreaker.Properties.Resources.Super_Mushroom", "BrickBreaker.Properties.Resources.Mini_Mushroom" };
            //set life counter
            lives = 3;

            //set all button presses to false.
            leftArrowDown = rightArrowDown = false;

            // setup starting paddle values and create paddle object
            int paddleWidth = 80;
            int paddleHeight = 20;
            int paddleX = ((this.Width / 2) - (paddleWidth / 2));
            int paddleY = (this.Height - paddleHeight) - 60;
            int paddleSpeed = 8;
            paddle = new Paddle(paddleX, paddleY, paddleWidth, paddleHeight, paddleSpeed, Color.White);

            // setup starting ball values
            int ballX = this.Width / 2 - 10;
            int ballY = this.Height - paddle.height - 80;

            // Creates a new ball
            int xSpeed = 6;
            int ySpeed = 6;
            int ballSize = 20;
            ball = new Ball(ballX, ballY, xSpeed, ySpeed, ballSize);

            #region Creates blocks for generic level. Need to replace with code that loads levels.

            //clears screen and loads level 1

            blocks.Clear();

            
            int newX, newY, newHp, newColour, newType;

            XmlReader reader = XmlReader.Create("Resources/level2.xml");

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    //reader.ReadToFollowing("x");
                    newX = Convert.ToInt32(reader.ReadString());

                    reader.ReadToNextSibling("y");
                    newY = Convert.ToInt32(reader.ReadString());

                    reader.ReadToNextSibling("hp");
                    newHp = Convert.ToInt32(reader.ReadString());

                    reader.ReadToNextSibling("colour");
                    newColour = Convert.ToInt32(reader.ReadString());

                    reader.ReadToNextSibling("type");
                    newType = Convert.ToInt32(reader.ReadString());

                    Block s = new Block(newX, newY, newHp, newColour, newType);
                    blocks.Add(s);
                }
            }
            
            #endregion

            // start the game engine loop
            gameTimer.Enabled = true;
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //player 1 button presses
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                default:
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //player 1 button releases
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // Move the paddle
            if (leftArrowDown && paddle.x > 0)
            {
                paddle.Move("left");
            }
            if (rightArrowDown && paddle.x < (this.Width - paddle.width))
            {
                paddle.Move("right");
            }

            // Move ball
            ball.Move();

            // Check for collision with top and side walls
            ball.WallCollision(this);

            // Check for ball hitting bottom of screen
            if (ball.BottomCollision(this))
            {
                lives--;

                // Moves the ball back to origin
                ball.x = ((paddle.x - (ball.size / 2)) + (paddle.width / 2));
                ball.y = (this.Height - paddle.height) - 85;

                if (lives == 0)
                {
                    gameTimer.Enabled = false;
                    OnEnd();
                }
            }

            // Check for collision of ball with paddle, (incl. paddle movement)
            ball.PaddleCollision(paddle);

            // Check if ball has collided with any blocks
            foreach (Block b in blocks)
            {
                if (ball.BlockCollision(b))
                {
                    b.hp--;

                    b.colour = b.hp;

                    if (b.hp == 0)
                    {
                        blocks.Remove(b);
                    }

                    if (blocks.Count == 0)
                    {
                        gameTimer.Enabled = false;
                        OnEnd();
                    }

                    break;
                }
            }

            //redraw the screen
            Refresh();
        }

        public void OnEnd()
        {
            // Goes to the game over screen
            Form form = this.FindForm();
            
            GameOverScreen gos = new GameOverScreen();
            gos.Location = new Point((form.Width - gos.Width) / 2, (form.Height - gos.Height) / 2);

            form.Controls.Add(gos);
            form.Controls.Remove(this);
        }

        public void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            // Draws paddle
            paddleBrush.Color = paddle.colour;
            e.Graphics.FillRectangle(paddleBrush, paddle.x, paddle.y, paddle.width, paddle.height);

            // Draws blocks
            foreach (Block b in blocks)
            {
                //e.Graphics.DrawImage(powerImage[0], 20, 20);
                //e.Graphics.DrawImage(BrickBreaker.Properties.Resources.Fire_flower, 20, 20);
                //e.Graphics.DrawImage(BrickBreaker.Properties.Resources.Super_Star, 20, 20);
                //e.Graphics.DrawImage(BrickBreaker.Properties.Resources.Double_Cherry, 20, 20);
                //e.Graphics.DrawImage(BrickBreaker.Properties.Resources.Super_Mushroom, 20, 20);
                //e.Graphics.DrawImage(BrickBreaker.Properties.Resources.Mini_Mushroom, 20, 20);
                
                if (b.colour == 1)
                {
                    e.Graphics.FillRectangle(blockBrush, b.x, b.y, b.width, b.height);
                }
                if (b.colour == 2)
                {
                    e.Graphics.FillRectangle(blockBrush2, b.x, b.y, b.width, b.height);
                }
                if (b.colour == 3)
                {
                    e.Graphics.FillRectangle(blockBrush3, b.x, b.y, b.width, b.height);
                }
                if (b.colour == 4)
                {
                    e.Graphics.FillRectangle(blockBrush4, b.x, b.y, b.width, b.height);
                }
                
            }

            // Draws ball
            e.Graphics.FillRectangle(ballBrush, ball.x, ball.y, ball.size, ball.size);

            e.Graphics.DrawString($"Lives left: {lives}", textFont, textBrush, 370, 500);
        }
       

    }
}
