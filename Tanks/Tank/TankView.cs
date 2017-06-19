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
                    CurrentImage = Properties.Resources.TankDown;
                    break;
                case MovingObject.direction.Up:
                    CurrentImage = Properties.Resources.TankUp;
                    break;
                case MovingObject.direction.Right:
                    CurrentImage = Properties.Resources.TankRight;
                    break;
                case MovingObject.direction.Left:
                    CurrentImage = Properties.Resources.TankLeft;
                    break;
                case MovingObject.direction.None:
                    break;
            }
        }
    }
}
