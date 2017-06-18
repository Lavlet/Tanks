using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Tanks
{
    public abstract class MovingObject : GameObject
    {
        public enum direction { Down, Up, Right, Left, None };

        public direction currentDirection;


        public int orderNumber;

        protected void ChangeCoordinates(ref int x, ref int y, direction currentDirection)
        {
            switch (currentDirection)
            {
                case direction.Down:
                    ++y;
                    break;
                case direction.Right:
                    ++x;
                    break;
                case direction.Up:
                    --y;
                    break;
                case direction.Left:
                    --x;
                    break;
            }
        }

        public abstract void Move();

    }
}

