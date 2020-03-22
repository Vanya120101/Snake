using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Walls
    {
        List<Figure> wallList;

        public Walls(int largestWidth, int largetstHeight)
        {
            wallList = new List<Figure>();
            HorizontalLine upLine = new HorizontalLine(0, largestWidth - 2, 0, '+');
            HorizontalLine downLine = new HorizontalLine(0, largestWidth - 2, largetstHeight - 2, '+');
            VerticalLine leftLine = new VerticalLine(0, largetstHeight - 2, 0, '+');
            VerticalLine rightLine = new VerticalLine(0, largetstHeight - 2, largestWidth - 2, '+');

            wallList.Add(upLine);
            wallList.Add(downLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);

            Draw();
        }

        internal bool IsHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }

        void Draw()
        {
            foreach (var item in wallList)
            {
                item.Draw();
            }
        }
    }
}
