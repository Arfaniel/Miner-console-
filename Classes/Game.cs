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
        //события press, start, win, loose, boom
        public Game()
        {
            newGame = new Field();
            newGame.PlantBombs();
            newGame.setNums();
            newGame.ShowHidden();
        }
    }
}
