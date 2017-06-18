using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Tanks
{
    public class TankModel: MovingObject
    {
        Tank.TankView tankView;
        public TankModel(int x, int y, int orderNumber)
        {
            X = x;
            Y = y;
            this.orderNumber = orderNumber;
            ownHeight = 16;//MovingObject.tankImage.Height;
            ownWidth = 16;//MovingObject.tankImage.Width;
            tankView = new Tank.TankView(currentDirection, new Point(X, Y));
        }

        public override void Move()
        {
            int counter = 1;
            Random randomizer = new Random();

            while (true)
            {
                Thread.Sleep(GameModel.gameSpeed);
                int x = X;
                int y = Y;

                ChangeCoordinates(ref x, ref y, currentDirection); //out?

                switch (Collision(x, y))
                {
                    case collisionType.Wall:
                        currentDirection = ChooseNewDirection(currentDirection);
                        break;
                    case collisionType.Tank:
                        currentDirection = ChooseOppositeDirection(currentDirection);
                        ChangeOtherTankDirection(x, y);
                        ChangeCoordinates(ref x, ref y, currentDirection);
                        if (counter % (2*ownHeight) == 0) //Сделать возможность не только для квадратов?
                        {
                            counter = 1;
                        }
                        break;
                    default: //Если столкнулся с яблоком или ни с чем
                        X = x;
                        Y = y;
                        break;
                }


                if (counter % (2 * ownHeight) == 0)
                {
                    currentDirection = ChooseNewDirection(currentDirection);
                }

                counter++;

                tankView.ChangeImage(currentDirection);


            }

        }

        private void ChangeOtherTankDirection(int x, int y)
        {
            TankModel otherTank;
            otherTank = FindItemIn(tanks, x, y, 1);
            if (otherTank == null)
                return;
            otherTank.currentDirection = ChooseOppositeDirection(otherTank.currentDirection);
        }

        private direction ChooseOppositeDirection(direction currentDirection)
        {
            switch (currentDirection)
            {
                case direction.Down:
                    currentDirection = direction.Up;
                    break;
                case direction.Up:
                    currentDirection = direction.Down;
                    break;
                case direction.Right:
                    currentDirection = direction.Left;
                    break;
                case direction.Left:
                    currentDirection = direction.Right;
                    break;
            }
            return currentDirection;
        }

        private direction ChooseNewDirection(direction previousDirection)
        {
            Random randomizer = new Random();
            direction newDirection = previousDirection;

            while (newDirection == previousDirection)
            {
                int directionCode = (randomizer.Next(0, 101) + randomizer.Next(0, 101)) % 4;

                switch (directionCode)
                {
                    case 0:
                        newDirection = direction.Left;
                        break;
                    case 1:
                        newDirection = direction.Up;
                        break;
                    case 2:
                        newDirection = direction.Right;
                        break;
                    case 3:
                        newDirection = direction.Down;
                        break;
                }
            }

            return newDirection;

        }

        public void LoadTankInformation(List<TankModel> otherTanks)
        {
            this.tanks = otherTanks;
        }

        public Image GetCurrentImage()
        {
            return tankView.GetCurrentImage();
        }

    }
}
