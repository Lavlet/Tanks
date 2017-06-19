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

        private Bitmap currentImage;

        public Bitmap CurrentImage
        {
            get
            {
                return currentImage;
            }
            set
            {
                currentImage = value;
                //currentImage.MakeTransparent(Color.White);
            }
        }

        public Point currentCoordinates;

        public GameObjectView(Point coordinates, Bitmap objectImage)
        {
            currentCoordinates = coordinates;
            currentImage = objectImage;
        }
        public Image GetCurrentImage()
        {
            currentImage.MakeTransparent(Color.White); //Почему то работает только так
            return CurrentImage;
        }
    }
}
