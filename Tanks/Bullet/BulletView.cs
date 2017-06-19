using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    public class BulletView : MovingObjectView
    {
        public BulletView(MovingObject.direction currentDirection, Point coordinates): base(currentDirection, coordinates)
        {
        }

        public override void ChangeImage(MovingObject.direction currentDirection)
        {
            switch (currentDirection)
            {
                case MovingObject.direction.Down:
                    CurrentImage = Properties.Resources.BulletDown;
                    break;
                case MovingObject.direction.Up:
                    CurrentImage = Properties.Resources.BulletUp;
                    break;
                case MovingObject.direction.Right:
                    CurrentImage = Properties.Resources.BulletRight;
                    break;
                case MovingObject.direction.Left:
                    CurrentImage = Properties.Resources.BulletLeft;
                    break;
                case MovingObject.direction.None:
                    break;
            }
           // currentImage.MakeTransparent(Color.White);
        }
    }
}
