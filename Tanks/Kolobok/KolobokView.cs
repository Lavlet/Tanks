using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks.Kolobok
{
    public class KolobokView:MovingObjectView
    {
        public KolobokView(MovingObject.direction currentDirection, Point coordinates): base(currentDirection, coordinates)
        {
        }

        public override void ChangeImage(MovingObject.direction currentDirection)
        {
            switch (currentDirection)
            {
                case MovingObject.direction.Down:
                    CurrentImage = Properties.Resources.KolobokDown;
                    break;
                case MovingObject.direction.Up:
                    CurrentImage = Properties.Resources.KolobokUp;
                    break;
                case MovingObject.direction.Right:
                    CurrentImage = Properties.Resources.KolobokRight;
                    break;
                case MovingObject.direction.Left:
                    CurrentImage = Properties.Resources.KolobokLeft;
                    break;
                case MovingObject.direction.None:
                    break;
            }
          //  currentImage.MakeTransparent(Color.White);
        }        
    }
}
