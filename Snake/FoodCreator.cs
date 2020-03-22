using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class FoodCreator
    {
        int mapWidth;
        int mapHeight;
        char sym;

        Random rand = new Random();

        public FoodCreator(int mapWidth, int mapHeight, char sym)
        {
            this.mapHeight = mapHeight;
            this.mapWidth = mapWidth;
            this.sym = sym;
        }

        public Point CreatFood(Snake snake)
        {
            int x;
            int y;
            Point food;
            do
            {


                x = rand.Next(2, mapWidth - 20);
                y = rand.Next(2, mapHeight - 10);
                food = new Point(x, y, sym);

            } while (snake.FoodOnSnake(x,y));
            return food;

        }
    }
}
