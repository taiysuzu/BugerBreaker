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
        //todo - create ball list and change the way the ball works, add balls for powerup
        //todo - create spawnBall method
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
        public static List<Block> blocks = new List<Block>();
        public static List<PowerUp> powerUps = new List<PowerUp>();

        //image arrays
        public static Image[] powerUpImages = { BrickBreaker.Properties.Resources.Fire_Flower, BrickBreaker.Properties.Resources.Super_Star, BrickBreaker.Properties.Resources.Double_Cherry, BrickBreaker.Properties.Resources.Super_Mushroom, BrickBreaker.Properties.Resources.Mini_Mushroom };
        public static Image[] brickImages = {BrickBreaker.Properties.Resources.Brick_1hp, BrickBreaker.Properties.Resources.Brick_2hp, BrickBreaker.Properties.Resources.Brick_3hp, BrickBreaker.Properties.Resources.Brick_4hp, BrickBreaker.Properties.Resources.Brick_5hp };

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

        //random generator
        public static Random randGen = new Random();

        //global paddle and ball values
        int paddleWidth, paddleHeight, paddleX, paddleY, paddleSpeed;

        int ballX, ballY, xSpeed, ySpeed, ballSize;

        //powerup counters
        int fireCounter, starCounter, cherryCounter, superMushCounter, miniMushCounter = 0;

        //powerup activated or not
        bool powerActive, fireActive, starActive, cherryActive, superMushActive, miniMushActive = false;
        #endregion

        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }

        public void OnStart()
        {
            //set life counter
            lives = 3;

            //set all button presses to false.
            leftArrowDown = rightArrowDown = false;

            // setup starting paddle values and create paddle object
            paddleWidth = 80;
            paddleHeight = 20;
            paddleX = ((this.Width / 2) - (paddleWidth / 2));
            paddleY = (this.Height - paddleHeight) - 60;
            paddleSpeed = 8;
            paddle = new Paddle(paddleX, paddleY, paddleWidth, paddleHeight, paddleSpeed, Color.White);
            
            // setup starting ball values
            ballX = this.Width / 2 - 10;
            ballY = this.Height - paddle.height - 80;

            // Creates a new ball
            xSpeed = 5;
            ySpeed = 5;
            ballSize = 20;
            ball = new Ball(ballX, ballY, xSpeed, ySpeed, ballSize);

            #region Temporary code that loads levels.

            //TODO: load level screen
            //clears screen and loads level 1

            blocks.Clear();

            int newX, newY, newHp, newColour, newType;

            XmlReader reader = XmlReader.Create("Resources/level1.xml");

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Text)
                {
                    
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
            //check if any powerups are active
            if (powerActive == true)
            {//check which powerups are active
                if (fireActive == true)
                {

                }
                else if (starActive == true)
                {

                }
                else if (cherryActive == true)
                {

                }
                else if (superMushActive == true)
                {
                    superMushCounter++;
                    if (superMushCounter == 20)
                    {
                        paddle.width = 80;
                        superMushActive = false;
                    }
                }
                else if (miniMushActive == true)
                {

                }
                else if (fireActive && starActive && cherryActive && superMushActive && miniMushActive == false)
                {
                    powerActive = false;
                }
            }
            // Move the paddle
            if (leftArrowDown && paddle.x > 0)
            {
                paddle.Move("left");
            }
            if (rightArrowDown && paddle.x < (this.Width - paddle.width))
            {
                paddle.Move("right");
            }

            //move powerups
            foreach (PowerUp p in powerUps)
            {
                p.Move();
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
                    score++;

                    b.colour = b.hp;

                    if (b.type == 0)
                    {
                        SpawnPowerUp(b.x, b.y);
                    }

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

            //check powerup collision with bottom
            foreach (PowerUp p in powerUps)
            {
                if (p.BottomCollision(this))
                {
                    powerUps.Remove(p);
                    break;
                }
            }

            //check powerup collision with paddle
            foreach (PowerUp p in powerUps)
            {
                if (p.PaddleCollision(paddle))
                {
                    ActivatePowerUp(p);
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
                if (b.colour == 1)
                {
                    e.Graphics.DrawImage(brickImages[0], b.x, b.y, b.width, b.height);
                }
                else if (b.colour == 2)
                {
                    e.Graphics.DrawImage(brickImages[1], b.x, b.y, b.width, b.height);
                }
                else if (b.colour == 3)
                {
                    e.Graphics.DrawImage(brickImages[2], b.x, b.y, b.width, b.height);
                }
                else if (b.colour == 4)
                {
                    e.Graphics.DrawImage(brickImages[3], b.x, b.y, b.width, b.height);
                }
                else if (b.colour == 5)
                {
                    e.Graphics.DrawImage(brickImages[4], b.x, b.y, b.width, b.height);
                }
            }

            //draws powerups
            foreach (PowerUp p in powerUps)
            {
                if (p.type == 1)
                {
                    e.Graphics.DrawImage(powerUpImages[p.type - 1], p.x, p.y, p.size, p.size);
                }
                else if (p.type == 2)
                {
                    e.Graphics.DrawImage(powerUpImages[p.type - 1], p.x, p.y, p.size, p.size);
                }
                else if (p.type == 3)
                {
                    e.Graphics.DrawImage(powerUpImages[p.type - 1], p.x, p.y, p.size, p.size);
                }
                else if (p.type == 4)
                {
                    e.Graphics.DrawImage(powerUpImages[p.type - 1], p.x, p.y, p.size, p.size);
                }
                else if (p.type == 5)
                {
                    e.Graphics.DrawImage(powerUpImages[p.type - 1], p.x, p.y, p.size, p.size);
                }
            }

            // Draws ball
            e.Graphics.FillRectangle(ballBrush, ball.x, ball.y, ball.size, ball.size);

            //draws life counter
            e.Graphics.DrawString($"Lives left: {lives}", textFont, textBrush, 370, 490);

            //draws score counter
            e.Graphics.DrawString($"Score: {score}", textFont, textBrush, 370, 510);
        }

        public void SpawnPowerUp(int x, int y)
        {
            int size = 40;
            int speed = 4;
            int type = randGen.Next(1, 5);

            //create powerup object and spawn it on powerup block's x and y
            PowerUp p = new PowerUp(x, y, size, speed, type);

            powerUps.Add(p);
        }

        public void FireFlower()
        {

        }

        public void SuperStar()
        {

        }

        public void DoubleCherry()
        {

        }

        public void SuperMushroom()
        {
            superMushCounter = 0;
            superMushActive = true;
            powerActive = true;

            paddle.width = 250;
        }

        public void MiniMushroom()
        {

        }

        public void ActivatePowerUp(PowerUp p)
        {
            if (p.type == 1)
            {
                FireFlower();
            }
            else if (p.type == 2)
            {
                SuperStar();
            }
            else if (p.type == 3)
            {
                DoubleCherry();
            }
            else if (p.type == 4)
            {
                SuperMushroom();
            }
            else if (p.type == 5)
            {
                MiniMushroom();
            }

            powerUps.Remove(p);
        }
    }
}
