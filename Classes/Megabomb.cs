using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Interfaces;

namespace ConsoleApplication1.Classes
{
    public class Megabomb : IBomb
    {
        public void Explode(Player x)
        {
            if (x.lives > 0)
            {
                x.lives--;
            }
            else
                x.lives = -1;
        }
        public override string ToString()
        {
            return "M";
        }
    }
}
