using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Apple: GameObject
    {
        public Apple()
        {
            ownHeight = 16;//MovingObject.appleImage.Height;
            ownWidth = 16;//MovingObject.appleImage.Width;
        }
        public Apple(int x, int y)
        {
            X = x;
            Y = y;
            ownHeight = 16;// MovingObject.appleImage.Height;
            ownWidth = 16;// MovingObject.appleImage.Width;
        }

        public static void AddNewApple(int prevX, int prevY) //Возможно не стоит просто пользоваться полями, а сделать параметры
        {//Случайность хромает
            //ещё есть наезды
            bool valiableCoordinates = false;


            int x = 0;
            int y = 0;

            Apple newApple = new Apple (x,y);

            int appleWidth = newApple.ownWidth;
            int appleHeight = newApple.ownHeight;

            while (!valiableCoordinates)
            {
                bool checkUpLeftPoint = false;
                bool checkUpRightPoint = false;
                bool checkDownLeftPoint = false;
                bool checkDownRightPoint = false;

                valiableCoordinates = false;

                Random randomizer = new Random();
                Random coinToss = new Random(); //Для определения больше или меньше новые координаты

                int limitX = 0; //Сомнительная часть это
                int limitY = 0;

                limitX = coinToss.Next(0, 2) == 0 ? prevX - 2 * appleWidth : prevX + 2 * appleWidth; //Может лучше отталкиваться от колобка, а не от яблок
                limitX = limitX < 0 ? 0 : GameModel.fieldSize - appleWidth;
                x = randomizer.Next(0, limitX + 1);


                limitY = coinToss.Next(0, 2) == 0 ? prevY - 2 * appleHeight : prevY + 2 * appleHeight;
                limitY = limitY < 0 ? 0 : GameModel.fieldSize - appleHeight;
                y = randomizer.Next(0, limitY + 1);

                if ((newApple.Collision(x,y) == MovingObject.collisionType.None) || (newApple.Collision(x, y) == MovingObject.collisionType.Tank))
                {
                    checkUpLeftPoint = true;
                }
                if (newApple.Collision(x + appleWidth, y) == collisionType.None)
                {
                    checkUpRightPoint = true;
                }
                if (newApple.Collision(x, y + appleHeight) == collisionType.None)
                {
                    checkDownLeftPoint = true;
                }
                if (newApple.Collision(x + appleWidth, y + appleHeight) == collisionType.None)
                {
                    checkDownRightPoint = true;
                }

                valiableCoordinates = checkUpLeftPoint && checkUpRightPoint && checkDownLeftPoint && checkDownRightPoint;
            }
            newApple.X = x;
            newApple.Y = y;
            GameModel.apples.Add(newApple);
        }
    }
}
