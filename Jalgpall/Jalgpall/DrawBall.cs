using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jalgpall
{
    internal class DrawBall
    {
        int mapWidht;
        int mapHeight;
        char sym;

        public DrawBall(int mapWidht, int mapHeight, char sym)
        {
            this.mapWidht = mapWidht;
            this.mapHeight = mapHeight;
            this.sym = sym;
        }
        public Point BallDraw()
        {
            int x = 40;
            int y = 12;
            return new Point(x, y, sym);
        }
    }
}
