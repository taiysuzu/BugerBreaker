using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace BrickBreaker
{
    public class PowerUp
    {
        public int x, y, size, speed, type;

        //powerup types as follows: 1 - fire flower, 2 - super star, 3 - cherry, 4 - super mushroom, 5 - mini mushrooms

        public PowerUp(int _x, int _y, int _size, int _speed, int _type)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            type = _type;
        }

        public void Move()
        {
            y = y + speed;
        }

        public bool BottomCollision(UserControl UC)
        {
            Boolean didCollide = false;

            if (y >= UC.Height)
            {
                didCollide = true;
            }
            return didCollide;
        }

        public bool PaddleCollision(Paddle p)
        {
            Boolean didCollide = false;
            Rectangle powerUpRec = new Rectangle(x, y, size, size);
            Rectangle paddleRec = new Rectangle(p.x, p.y, p.width, p.height);

            if (powerUpRec.IntersectsWith(paddleRec))
            {
                didCollide = true;
            }
            return didCollide;
        }
    }
}


