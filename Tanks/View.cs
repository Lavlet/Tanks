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
    public partial class View : UserControl
    {
        public int gameSpeed;

        KolobocController colobocController;

        KeyEventArgs currentDirectionKey = new KeyEventArgs(new Keys());

        Keys[] movementKeys = { Keys.Down, Keys.Up, Keys.Right, Keys.Left };

        public View(KolobocController colobocController)
        {
            gameSpeed = GameModel.gameSpeed;
            this.colobocController = colobocController;

            InitializeComponent();
        }

        private void View_Paint(object sender, PaintEventArgs e)
        { 
            foreach (Wall wall in GameModel.walls) //Перерисовываем стены
            {
                e.Graphics.DrawImage(GameModel.wallImage, new Point(wall.X, wall.Y));
            }

            foreach (Apple apple in GameModel.apples) //Перерисовываем яблоки
            {
                e.Graphics.DrawImage(GameModel.appleImage, new Point(apple.X, apple.Y));
            }

            e.Graphics.DrawImage(colobocController.GetCurrentImage(), colobocController.GetCoordinates()); //Перерисовываем колобка

            foreach (TankModel tank in GameModel.tanks) //Перерисовываем танки
            {
                e.Graphics.DrawImage(tank.GetCurrentImage(), new Point(tank.X, tank.Y));
            }

            foreach (BulletModel bullet in GameModel.bullets) //Вылетает если выстрелить во время отрисовки
            {
                e.Graphics.DrawImage(GameModel.bulletImage, new Point(bullet.X, bullet.Y));
            }
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
            if (e.KeyCode == Keys.Space)
            {
                colobocController.Action(e);
            }
            this.Invalidate();
        }

    }
}
