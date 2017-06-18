using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks.Tank
{
    public class TankView: MovingObjectView
    {
        public TankView(MovingObject.direction currentDirection, Point coordinates): base(currentDirection, coordinates)
        {
        }

        public override void ChangeImage(MovingObject.direction currentDirection)
        {
            switch (currentDirection)
            {
                case MovingObject.direction.Down:
                    currentImage = Properties.Resources.TankDown;
                    break;
                case MovingObject.direction.Up:
                    currentImage = Properties.Resources.TankUp;
                    break;
                case MovingObject.direction.Right:
                    currentImage = Properties.Resources.TankRight;
                    break;
                case MovingObject.direction.Left:
                    currentImage = Properties.Resources.TankLeft;
                    break;
                case MovingObject.direction.None:
                    break;
            }
        }
    }
}
