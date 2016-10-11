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
        public event press button;

        //события press, start, win, loose, boom
        public Game()
        {
            newGame = new Field();
            newGame.PlantBombs();
            newGame.setNums();
            curX = 0;
            curY = 0;
            newGame.Show(curX, curY);
        }
        public void moveArrows()
        {
            ConsoleKeyInfo a = new ConsoleKeyInfo();
            a = Console.ReadKey();
            if(a.Key == ConsoleKey.DownArrow && curY < 9)
            {
                curY++;
            }
            if (a.Key == ConsoleKey.UpArrow && curY > 0)
            {
                curY--;
            }

        }
    }
}
