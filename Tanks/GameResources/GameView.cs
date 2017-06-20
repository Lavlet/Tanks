using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Tanks
{
    public partial class GameView : UserControl
    {
        public int gameSpeed;

        KolobocController colobocController;

        KeyEventArgs currentDirectionKey = new KeyEventArgs(new Keys());

        Keys[] movementKeys = { Keys.Down, Keys.Up, Keys.Right, Keys.Left };

        System.Threading.Timer shootDelay;

        static bool canShoot = true;

        public GameView(KolobocController colobocController)
        {
            gameSpeed = GameModel.gameSpeed;
            shootDelay = new System.Threading.Timer(AllowShooting, null, 0, gameSpeed*15);
            this.colobocController = colobocController;
            InitializeComponent();
        }

        private void DrawGameObjects<T>(PaintEventArgs e, List<T> gameObjects) where T: GameObject
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                T currentGameObject = gameObjects[i];
                if (currentGameObject != null)
                {
                    e.Graphics.DrawImage(currentGameObject.GetCurrentImage(), new Point(currentGameObject.X, currentGameObject.Y));
                }
            }
        }
       
                

        private void View_Paint(object sender, PaintEventArgs e)
        {
            DrawGameObjects(e, GameModel.walls);
            DrawGameObjects(e, GameModel.apples);            

            e.Graphics.DrawImage(colobocController.GetCurrentImage(), colobocController.GetCoordinates()); //Перерисовываем колобка

            DrawGameObjects(e, GameModel.tanks);
            DrawGameObjects(e, GameModel.bullets);

            colobocController.Action(currentDirectionKey);
            Thread.Sleep(gameSpeed);
            Invalidate();
        }

        protected override bool IsInputKey(Keys keyData)//Переопределение, чтобы KeyDown реагировал на стрелки
        {
            switch (keyData)
            {
                case Keys.Right:
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                    return true;
            }
            return base.IsInputKey(keyData);
        }

        private void View_KeyUp(object sender, KeyEventArgs e)
        {
            if (Array.Exists(movementKeys, q => q == e.KeyCode))
            {
                currentDirectionKey = e;
            }
            if ((canShoot) && (e.KeyCode == Keys.Space))
            {
                colobocController.Action(e);
                canShoot = false;
            }

            this.Invalidate();
        }

        private static void AllowShooting(object sender) //static?
        {
            canShoot = true;
        }
    }
}
