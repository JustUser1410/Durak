using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new Client();
            client.startGame();

            for (;;);
        }
    }
}
