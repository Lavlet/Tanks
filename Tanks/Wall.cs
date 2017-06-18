using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public class Wall: GameObject
    {
        //public readonly int X; //Нужно ввести огранечения, чтобы нельзя было ставить стены вне поля
        //public readonly int Y;
        public Wall (int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
