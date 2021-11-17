using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BrickBreaker
{
    class PowerUp
    {
        public int x, y, size, speed, type;
        public Color color;
        public static Random randGen = new Random();
        public static string powerUpPicture;

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
            y = y - speed;
        }
    }
}
  

