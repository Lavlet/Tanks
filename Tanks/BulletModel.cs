using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Tanks
{
    public class BulletModel:MovingObject
    {
        public BulletModel(MovingObject shooter, int orderNumber)
        {
            currentDirection = shooter.currentDirection;
            ownHeight = 4;//MovingObject.bulletImage.Height;
            ownWidth = 4;//MovingObject.bulletImage.Width;
            SetCoordiantes(shooter);
            this.orderNumber = orderNumber;
        }

        private void SetCoordiantes(MovingObject shooter)
        {
            switch (shooter.currentDirection)
            {
                case direction.Down:
                    X = shooter.X + shooter.ownWidth / 2 - ownWidth / 2;
                    Y = shooter.Y + shooter.ownHeight;
                    break;
                case direction.Up:
                    X = shooter.X + shooter.ownWidth / 2 - ownWidth / 2;
                    Y = shooter.Y;
                    break;
                case direction.Right:
                    X = shooter.X + shooter.ownWidth;
                    Y = shooter.Y + shooter.ownWidth / 2 - ownHeight / 2;
                    break;
                case direction.Left:
                    X = shooter.X;
                    Y = shooter.Y + shooter.ownWidth / 2 - ownHeight / 2;
                    break;
            }
        }

        public void LoadTankInformation(List<TankModel> tanks)
        {
            this.tanks = tanks;
        }

        public override void Move()
        {
            while (true)
            {
                Thread.Sleep(GameModel.gameSpeed/3);
                int x = X;
                int y = Y;

                ChangeCoordinates(ref x, ref y, currentDirection);

                switch (Collision(x, y)) //В колижене размер картинок не тот
                {
                    case collisionType.Apple:
                        X = x;
                        Y = y;
                        break;
                    case collisionType.Wall:
                        GameModel.DestroyBullet(orderNumber);
                        break;
                    case collisionType.Tank:
                        GameModel.DestroyTank(x, y, orderNumber);
                        break;
                    case collisionType.None:
                        X = x;
                        Y = y;
                        break;
                }
            }

        }
    }
}
