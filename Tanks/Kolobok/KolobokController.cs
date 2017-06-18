using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Tanks
{
    public class KolobocController //Контроллер, который будет отвечать за всё. Переделать в него
    {
        private KolobocModel kolobokModel;

        public KolobocController (KolobocModel kolobokModel)
        {
            this.kolobokModel = kolobokModel;
        }

        Keys[] movementKeys = { Keys.Down, Keys.Up, Keys.Right, Keys.Left };

        public void Action(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                kolobokModel.Shot();
                kolobokModel.Move();
                return;
            }

            if (Array.Exists(movementKeys, q=> q==e.KeyCode))
            {
                ColobocMovement(e);
                return;
            }
        
        }              

        private void ColobocMovement (KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                    kolobokModel.currentDirection = KolobocModel.direction.Down;
                    break;
                case Keys.Right:
                    kolobokModel.currentDirection = KolobocModel.direction.Right;
                    break;
                case Keys.Up:
                    kolobokModel.currentDirection = KolobocModel.direction.Up;
                    break;
                case Keys.Left:
                    kolobokModel.currentDirection = KolobocModel.direction.Left;
                    break;
                //default:
                  //  currentDirection = ColobocModel.direction.None;
                    //break;
            }

            kolobokModel.Move();
        }

        public Point GetCoordinates()
        {
            return kolobokModel.GetCoordinates();
        }

        public Image GetCurrentImage()
        {
            return kolobokModel.GetCurrentImage();
        }
    }
}
