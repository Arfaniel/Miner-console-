using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1.Classes
{
    public class Game
    {
        public Field newGame;
        Player me;
        public int curX;
        public int curY;
        //public delegate void press();
        public event Field.press button;

        //события press, start, win, loose, boom
        public Game()
        {
            newGame = new Field();
            newGame.PlantBombs();
            newGame.setNums();
            curX = 0;
            curY = 0;
            newGame.Show();
        }
        public void moveArrows()
        {
            ConsoleKeyInfo a = new ConsoleKeyInfo();
            a = Console.ReadKey();
            if(a.Key == ConsoleKey.DownArrow && newGame.curX < 9)
            {
                newGame.curX++;
                button += newGame.Show;
            }
            if (a.Key == ConsoleKey.UpArrow && newGame.curX > 0)
            {
                newGame.curX--;
                button += newGame.Show;
            }
            if(a.Key == ConsoleKey.LeftArrow && newGame.curY < 0)
            {
                newGame.curY++;
                button += newGame.Show;
            }
            if (a.Key == ConsoleKey.RightArrow && newGame.curY >= 0)
            {
                newGame.curY++;
                button += newGame.Show;
            }
            button();
        }

    }
}
