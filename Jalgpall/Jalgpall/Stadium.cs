using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jalgpall
{
    public class Walls
    {
        List<Figure> wallList;
        public int Width { get; }
        public int Height { get; }
        public Walls(int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();
            HorizontalLine upLine = new HorizontalLine(0, mapWidth - 2, 4, '*');
            HorizontalLine downLine = new HorizontalLine(0, mapWidth - 2, mapHeight - 4, '*');
            VertikalLine leftLine = new VertikalLine(4, mapHeight - 4, 0, '*');
            VertikalLine rightLine = new VertikalLine(4, mapHeight - 4, mapWidth - 2, '*');
        

        wallList.Add(upLine);
            wallList.Add(downLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);
        }
        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }
        public bool IsIn(double x, double y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }
    }
}
