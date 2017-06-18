using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace Tanks
{
    public class GameModel
    {
        public static List<Wall> walls = new List<Wall>();
        public static List<Apple> apples = new List<Apple>();

        public static List<Thread> tankThreads = new List<Thread>();
        public static List<TankModel> tanks = new List<TankModel>();

        public static List<Thread> bulletThreads = new List<Thread>();
        public static List<BulletModel> bullets = new List<BulletModel>();

        public static int fieldSize;
        public static int ammountOfApples;
        public static int ammountOfTanks;
        public static int gameSpeed;

        public static Image appleImage = Properties.Resources.Apple;
        public static Image wallImage = Properties.Resources.Wall;
        public static Image tankImage = Properties.Resources.TankUp;
        public static Image bulletImage = Properties.Resources.Bullet; 


        public GameModel(int fieldSize, int ammountOfTanks, int ammountOfApples, int gameSpeed)
        {
            GameModel.fieldSize = fieldSize;
            GameModel.ammountOfApples = ammountOfApples;
            GameModel.ammountOfTanks = ammountOfTanks;
            GameModel.gameSpeed = gameSpeed;

            StartingInitialization();
        }

        private void StartingInitialization()
        {
            //SetWalls();
            SetApples();

            for (int i = 0; i < ammountOfTanks; i++) //Создаём объекты танков и потоки для них
            {
                tanks.Add(new TankModel(i * 32, 0, i));
                tankThreads.Add(new Thread(tanks[i].Move));

            }

            for (int i = 0; i < ammountOfTanks; i++) //Даём каждому танку информацию о других танках
            {
                List<TankModel> tempTanks = new List<TankModel>(tanks);
                tempTanks.Remove(tanks[i]);
                tanks[i].LoadTankInformation(tempTanks);
            }

            for (int i = 0; i < ammountOfTanks; i++) //Запускаем потоки танков
            {
                tankThreads[i].Start();
            }
        }

        private void SetWalls()
        {//Первичный вариант игрового поля
            for (int i = 0; i < 10; i++) //Верхние стены
            {
                walls.Add(new Wall(i * 16, 0)); // 1 level
                if (i % 2 == 0)
                {
                    walls.Add(new Wall(i * 16, 16)); //2 level
                    walls.Add(new Wall(i * 16, 32)); //3 level
                }
            }
            walls.Add(new Wall(96, 48)); //4 level
            walls.Add(new Wall(32, 64)); //5 level
            walls.Add(new Wall(64, 64));
            walls.Add(new Wall(16, 80));//6 level
            walls.Add(new Wall(32, 80));
            walls.Add(new Wall(64, 80));
            walls.Add(new Wall(128, 80));
            walls.Add(new Wall(0, 112)); // 8 level
            walls.Add(new Wall(48, 112));
            walls.Add(new Wall(80, 112));
            walls.Add(new Wall(96, 112));
            walls.Add(new Wall(112, 112));
            walls.Add(new Wall(0, 144)); // 10 level
            walls.Add(new Wall(16, 144));
            walls.Add(new Wall(32, 144));
            walls.Add(new Wall(112, 144));
            walls.Add(new Wall(128, 144));
            walls.Add(new Wall(144, 144));
        }

        private void SetApples() //Константно 5 штук создается
        {
            apples.Add(new Apple(16, 64));
            apples.Add(new Apple(16, 112));
            apples.Add(new Apple(128, 112));
            apples.Add(new Apple(80, 80));
            apples.Add(new Apple(128, 64));
        }

        public void CloseThreads() //Закрываем все потоки (пули и танки)
        {
            foreach (Thread tankThread in tankThreads)
            {
                tankThread.Abort();
            }

            foreach (Thread bulletThread in bulletThreads)
            {
                bulletThread.Abort();
            }
        }

        public static void CreateBullet(MovingObject shooter) //Каждая пуля знает обо всех танках? Это странно.
        {
            bullets.Add(new BulletModel(shooter, bullets.Count));
            bullets[bullets.Count - 1].LoadTankInformation(tanks);
            bulletThreads.Add(new Thread(bullets.Last().Move));
            bulletThreads.Last().Start();
        }

        public static void DestroyBullet(int orderNumber)
        {
            Thread tempThread = bulletThreads[orderNumber];

            CorrectTheNumbers(bullets, orderNumber);

            bulletThreads.Remove(bulletThreads[orderNumber]);
            bullets.Remove(bullets[orderNumber]); //Сдвиг номеров
            tempThread.Abort();
        }

        private static void CorrectTheNumbers<T>(List<T> whereToCorrect, int orderNumber) where T : MovingObject //Изменяем индексацию после удаления объекта
        {
            for (int i = orderNumber + 1; i < whereToCorrect.Count; i++)
            {
                whereToCorrect[i].orderNumber = whereToCorrect[i].orderNumber - 1;
            }
        }

        public static void EndTheGame() //Нужен ли статик?
        {
            Application.Exit();
        }

        public static void DestroyTank(int x, int y, int bulletNumber)
        {
            int shotedTankNumber = bullets[bulletNumber].FindItemIn(tanks, x, y, 1).orderNumber; //Индекс танка, с которым столкнулась пуля

            Thread tempThread = tankThreads[shotedTankNumber]; //Поток подбитого танка

            CorrectTheNumbers(tanks, shotedTankNumber); //Сдвиг номеров

            tankThreads.Remove(tankThreads[shotedTankNumber]);
            tanks.Remove(tanks[shotedTankNumber]); 
            tempThread.Abort();

            DestroyBullet(bulletNumber);
        }

        public void DestroyAll()
        {
            foreach (Thread tankThread in tankThreads)
            {
                tankThread.Abort();
            }

            tankThreads.RemoveRange(0, tankThreads.Count);
            tanks.RemoveRange(0, tanks.Count);

            foreach (Thread bulletThread in bulletThreads)
            {
                bulletThread.Abort();
            }

            bulletThreads.RemoveRange(0, bulletThreads.Count);
            bullets.RemoveRange(0, bullets.Count);
            apples.RemoveRange(0, apples.Count);
            tanks.RemoveRange(0, tanks.Count);

            
        }
    }
}
