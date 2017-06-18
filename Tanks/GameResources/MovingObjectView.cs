using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    public abstract class MovingObjectView: GameObjectView
    {
        public MovingObjectView(MovingObject.direction currentDirection, Point coordinates):base(coordinates, null)
        {
            ChangeImage(currentDirection);
        }

        public abstract void ChangeImage(MovingObject.direction currentDirection);
    }
}
