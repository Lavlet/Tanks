using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    public class Wall: GameObject
    {
        public WallView wallView;
        
        public Wall (int x, int y)
        {
            X = x;
            Y = y;

            ownHeight = GameModel.wallImage.Height;
            ownWidth = GameModel.wallImage.Width;

            wallView = new WallView(new Point(X, Y), Properties.Resources.Wall);
        }

        public override Image GetCurrentImage()
        {
            return wallView.GetCurrentImage();
        }
    }
}
