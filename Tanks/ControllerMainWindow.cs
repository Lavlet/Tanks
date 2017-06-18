using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tanks
{
    public partial class ControllerMainWindow : Form
    {
        GameView gameView;
        GameModel gameModel;
        KolobocModel kolobokModel;
        KolobocController kolobokConroller;

        public ControllerMainWindow() : this(160) { } //Возможность задавать ширину и высоту отдельно?
        public ControllerMainWindow(int fieldSize) : this(fieldSize, 5) { }
        public ControllerMainWindow(int fieldSize, int ammountOfTanks) : this(fieldSize, ammountOfTanks, 5) { }
        public ControllerMainWindow(int fieldSize, int ammountOfTanks, int ammountOfApples) : this(fieldSize, ammountOfTanks, ammountOfApples, 60) { }
        public ControllerMainWindow(int fieldSize, int ammountOfTanks, int ammountOfApples, int gameSpeed)
        {
            InitializeComponent();
            gameModel = new GameModel(fieldSize, ammountOfTanks, ammountOfApples, gameSpeed);
            kolobokModel = new KolobocModel();
            kolobokConroller = new KolobocController(kolobokModel);
            gameView = new GameView(kolobokConroller);
            gameView.Width = fieldSize;
            gameView.Height = fieldSize;
            this.Controls.Add(gameView);
            SetOtherFormObjectPosition(fieldSize);            
        }

        private void SetOtherFormObjectPosition(int fieldSize)
        {
            this.Width = fieldSize + 200;
            this.Height = fieldSize;
            btnExit.Left = fieldSize + (200 - btnExit.Width) / 2;
            btnExit.Top = fieldSize - btnExit.Height - 10;
            btnNewGame.Top = btnExit.Top - btnNewGame.Height - 10;
            btnNewGame.Left = btnExit.Left;
            lblScoreTitle.Left = btnExit.Left;
            lblScoreTitle.Top = btnNewGame.Top - lblScoreTitle.Height - 10;
            lblScoreValue.Left = lblScoreTitle.Left + 45;
            lblScoreValue.Top = lblScoreTitle.Top;
        }

        private void ControllerMainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            gameModel.CloseThreads();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNewGame_Click(object sender, EventArgs e) //???
        {
            gameModel.DestroyAll();
            this.Controls.Remove(gameView);
            gameModel = new GameModel(GameModel.fieldSize, GameModel.ammountOfTanks, GameModel.ammountOfApples, GameModel.gameSpeed);
            kolobokModel = new KolobocModel();
            kolobokConroller = new KolobocController(kolobokModel);
            gameView = new GameView(kolobokConroller);
            gameView.Width = GameModel.fieldSize;
            gameView.Height = GameModel.fieldSize;
            this.Controls.Add(gameView);
            SetOtherFormObjectPosition(GameModel.fieldSize);
        }

        public static void ChangeScore(int score)
        {
            lblScoreValue.Text = score.ToString();
        }
    }
}
