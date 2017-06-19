using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    public class Apple : GameObject
    {
        public AppleView appleView;

        public Apple()
        {
            appleView = new AppleView(new Point(X, Y), Properties.Resources.Apple);
            ownHeight = GameModel.appleImage.Height;
            ownWidth = GameModel.appleImage.Width;
        }
        public Apple(int x, int y): this()
        {
            X = x;
            Y = y;
        }

        public static void AddNewApple(int prevX, int prevY)
        {
            Apple newApple = new Apple(GameModel.fieldSize/2, GameModel.fieldSize/2);
            newApple.FindFreeCoordinates();
            GameModel.apples.Add(newApple);
        }

        public override Image GetCurrentImage()
        {
            return appleView.GetCurrentImage();
        }
    }
}
