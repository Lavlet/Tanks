using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    public abstract class GameObjectView
    {

        public Bitmap currentImage;

        public Point currentCoordinates;

        public GameObjectView(Point coordinates, Bitmap objectImage)
        {
            currentCoordinates = coordinates;
            currentImage = objectImage;
        }
        public Image GetCurrentImage()
        {
            currentImage.MakeTransparent(Color.White);
            return currentImage;
        }
    }
}
