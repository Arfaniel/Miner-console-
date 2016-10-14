using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Classes
{
    public class Player
    {

        public int lives { get; set; }
        public int time { get; set; }

        public delegate void dead();
        
        public Player()
        {
            lives = 5;
            time = 0;
        }

    }
}
