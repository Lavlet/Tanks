using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    public abstract class MovingObjectView
    {
        public Bitmap currentImage;

        public Point currentCoordinates;

        public MovingObjectView(MovingObject.direction currentDirection, Point coordinates)
        {
            currentCoordinates = coordinates;
            ChangeImage(currentDirection);
        }

        public abstract void ChangeImage(MovingObject.direction currentDirection);

        public Image GetCurrentImage()
        {
            return currentImage;
        }
    }
}
