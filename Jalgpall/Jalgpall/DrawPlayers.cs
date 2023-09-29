using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jalgpall
{
    internal class DrawPlayers
    {
        int mapWidht;
        int mapHeight;
        char sym;

        Random random = new Random();

        public DrawPlayers(int mapWidht, int mapHeight, char sym)
        {
            this.mapWidht = mapWidht;
            this.mapHeight = mapHeight;
            this.sym = sym;
        }

        public Point PlayersDraw()
        {
            int x = random.Next(2, mapWidht - 2);
            int y = random.Next(6, mapHeight - 6);
            return new Point(x, y, sym);
        }
    }
}
