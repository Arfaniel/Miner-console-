using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1.Interfaces;

namespace ConsoleApplication1.Classes
{
    public class TimeBomb : IBomb
    {
        public void Explode(Player x)
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            return "T";
        }
    }
}
