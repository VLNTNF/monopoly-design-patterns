using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ESILV_DesignProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Game monop = new Game(2, 15);
            monop.run();
        }
    }
}
