using System;
using System.Collections.Generic;
using System.Threading;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int largestWidth = Console.LargestWindowWidth - 20;
            int largetstHeight = Console.LargestWindowHeight - 10;

            Console.SetBufferSize(largestWidth, largetstHeight);
            Console.SetWindowSize(largestWidth, largetstHeight);

            Walls walls = new Walls(largestWidth, largetstHeight);

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 2, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(largestWidth, largetstHeight, '$');
            Point food = foodCreator.CreatFood(snake);
            food.Draw();

            ConsoleKeyInfo key = Console.ReadKey();
            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    Console.WriteLine("ВЫ ПРОИГРАЛИ");
                    Console.ReadKey();
                    break;
                }

                if (snake.Eat(food))
                {
                    food = foodCreator.CreatFood(snake);
                    food.Draw();
                }
                if (Console.KeyAvailable)
                {
                    while (Console.KeyAvailable) key = Console.ReadKey();
                    snake.HandleKey(key.Key);

                }
                Thread.Sleep(100);
                snake.Move();

            }




        }


    }
}
