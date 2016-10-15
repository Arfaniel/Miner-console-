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

        public delegate void press(ConsoleKeyInfo a);
        public event press buttonPress;
        public delegate void gameStatus();
        public event gameStatus Win;
        public event gameStatus Loose;
        public Game()
        {
            newGame = new Field();
            buttonPress += newGame.moveOnGrid;
            Loose += newGame.isLoose;
            Win += newGame.isWin;
            newGame.PlantBombs();
            newGame.setNums();
            newGame.Show();
        }
        public void readPress()
        {
            ConsoleKeyInfo a = new ConsoleKeyInfo();
            a = Console.ReadKey();
            do
            {
                newGame.Show();
                buttonPress(Console.ReadKey());
                if(newGame.me.lives <=0 || newGame.me.time >= 1000)
                {
                    Loose();
                    break;
                }
                if(newGame.me.lives > 0 && newGame.isWinner() == true)
                {
                    Win();
                    break;
                }
            } while (a.Key != ConsoleKey.Escape);
        }

        
    }
}
