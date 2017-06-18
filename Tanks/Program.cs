using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] arg)
        {
            ControllerMainWindow controllerMainWindow;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            switch (arg.Length)
            {
                case 0:
                    controllerMainWindow = new ControllerMainWindow();
                    break;
                case 1:
                    controllerMainWindow = new ControllerMainWindow(int.Parse(arg[0]));
                    break;
                case 2:
                    controllerMainWindow = new ControllerMainWindow(int.Parse(arg[0]), int.Parse(arg[1]));
                    break;
                case 3:
                    controllerMainWindow = new ControllerMainWindow(int.Parse(arg[0]), int.Parse(arg[1]), int.Parse(arg[2]));
                    break;
                case 4:
                    controllerMainWindow = new ControllerMainWindow(int.Parse(arg[0]), int.Parse(arg[1]), int.Parse(arg[2]), int.Parse(arg[3]));
                    break;
                default:
                    controllerMainWindow = new ControllerMainWindow();
                    break;
            }

            Application.Run(controllerMainWindow);
        }
    }
}
