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

        //public void SpawnPowerUp(Block b)
        //{

        //    int randomPowerUp = randGen.Next(1, 5);

        //    if (randomPowerUp  == 1)
        //    {               
        //       powerUpPicture = "BrickBreaker.Properties.Resources.Fire_flower";
        //        x = b.x;
        //        y = b.y;
        //    }
        //    else if (randomPowerUp == 2)
        //    {
        //        powerUpPicture = "BrickBreaker.Properties.Resources.Super_Star";
        //        x = b.x;
        //        y = b.y;
        //    }
        //    else if (randomPowerUp == 3)
        //    {
        //        powerUpPicture = "BrickBreaker.Properties.Resources.Double_Cherry";
        //        x = b.x;
        //        y = b.y;
        //    }
        //    else if (randomPowerUp == 4)
        //    {
        //        powerUpPicture = "BrickBreaker.Properties.Resources.Super_Mushroom";
        //        x = b.x;
        //        y = b.y;
        //    }
        //    else if (randomPowerUp == 5)
        //    {
        //        powerUpPicture = "BrickBreaker.Properties.Resources.Mini_Mushroom";
        //        x = b.x;
        //        y = b.y;
        //    }       
        //}
        //public void FireFlowerPowerUp()
        //{

        //}
    }
}
  

