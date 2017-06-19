using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Tanks
{
    public class KolobocModel : MovingObject
    {
        private Kolobok.KolobokView kolobokView;

        public void Shot()
        {
            GameModel.CreateBullet(this);
        }

        public KolobocModel()
        {
            X = GameModel.fieldSize/2 - 16; //Initial coordinates
            Y = GameModel.fieldSize-17;
            currentDirection = direction.Up;
            kolobokView = new Kolobok.KolobokView(currentDirection, new Point(X, Y));
            ownHeight = kolobokView.GetCurrentImage().Height;
            ownWidth = kolobokView.GetCurrentImage().Width;
        }

        public override void Move()
        {
            int x = X;
            int y = Y;
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

            switch (Collision(x, y))
            {
                case collisionType.Apple:
                    X = x;
                    Y = y;
                    GameModel.Score++;
                    Apple tempApple = FindItemIn(GameModel.apples, X, Y, 1);
                    GameModel.apples.Remove(tempApple);
                    Apple.AddNewApple(tempApple.X, tempApple.Y);
                    break;
                case collisionType.Wall:
                    break;
                case collisionType.Tank:
                    GameModel.EndTheGame();
                    break;
                case collisionType.None:
                    X = x;
                    Y = y;
                    break;
            }

            kolobokView.ChangeImage(currentDirection);

        }

        public Point GetCoordinates()
        {
            return new Point(X, Y);
        }

        public override Image GetCurrentImage()
        {
            return kolobokView.GetCurrentImage();
        }
    }
}
