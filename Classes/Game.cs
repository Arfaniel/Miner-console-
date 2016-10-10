using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Classes
{
    public class Game
    {
        Field newGame;
        Player me;
        int curX;
        int curY;
        public delegate void press();
        public event press move;

        //события press, start, win, loose, boom
        public Game()
        {

            newGame = new Field();
            newGame.PlantBombs();
            newGame.setNums();
            curX = 1;
            curY = 1;
            newGame.Show();
        }
        public void moveArrows()
        {

        }
    }
}
