using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    public abstract class GameObject
    {
        public int X;
        public int Y;

        public int ownHeight;
        public int ownWidth;

        protected List<TankModel> tanks = GameModel.tanks;
        public enum collisionType { Wall, Apple, Tank, None };

        public collisionType Collision(int x, int y)
        {
            if (x > GameModel.fieldSize - ownWidth || y >= GameModel.fieldSize - ownHeight || x < 0 || y < 0) //Если вышел за поле
            {
                return collisionType.Wall;
            }

            if (FindItemIn(GameModel.walls, x, y, 1) != null) //Если столкнулся со стеной
            {
                return collisionType.Wall;
            }

            if (FindItemIn(GameModel.apples, x, y, 1) != null)//Если столкнулся с яблоком. Меньший хитбокс?
            {
                return collisionType.Apple;
            }

            if (FindItemIn(tanks, x, y, 1) != null) //Если столкнулся с танком
            {
                return collisionType.Tank;
            }

            return collisionType.None;
        }

        public T FindItemIn<T>(List<T> structureToLook, int x, int y, double intersectionRate) where T : GameObject
        {
            int intersectedObjectHeight = 0;
            int intersectedObjectWeight = 0;

            if (structureToLook == null)
            {
                throw new NullReferenceException();
            }
            else if (structureToLook.Count != 0)
            {
                intersectedObjectHeight = structureToLook[0].ownHeight;
                intersectedObjectWeight = structureToLook[0].ownWidth;
            }

            double inverseIntersectionRate = 1 - intersectionRate;
            return (structureToLook.Find(q => ((x >= q.X + intersectedObjectWeight * inverseIntersectionRate && x <= q.X + intersectedObjectWeight * intersectionRate) ||
            (x + ownWidth >= q.X + intersectedObjectWeight * inverseIntersectionRate && x + ownWidth <= q.X + intersectedObjectWeight * intersectionRate))
            && ((y >= q.Y + intersectedObjectHeight * inverseIntersectionRate && y <= q.Y + intersectedObjectHeight * intersectionRate) ||
            (y + ownHeight >= q.Y + intersectedObjectHeight * inverseIntersectionRate && y + ownHeight <= q.Y + intersectedObjectHeight * intersectionRate))));
        } //Ставится ограничение, что размеры всех объектов должны быть одинаковы. Добавить средние точки?
    }
}
