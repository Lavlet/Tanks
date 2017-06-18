using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tanks
{
    public class AppleView: GameObjectView
    {
        public AppleView(Point coordinates, Bitmap appleImage): base(coordinates, appleImage)
        {
        }
    }
}
