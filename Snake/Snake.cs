using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    class Snake : Figure
    {
        public Direction direction;
        public Snake(Point tail, int length, Direction direction)
        {
            this.direction = direction;
            pList = new List<Point>();
            for (int i = 0; i < length; i++)
            {
                Point p = new Point(tail);
                p.Move(i, this.direction);
                pList.Add(p);
            }
        }

        internal void Move()
        {
            Point tail = pList.First();
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add(head);

            tail.Clear();
            head.Draw();
        }

        internal bool FoodOnSnake(int x, int y)
        {
            foreach (var item in pList)
            {
                if (item.x==x && item.y==y)
                {
                    return true;
                }
            }
            return false;
        }

        internal bool IsHitTail()
        {
            var head = pList.Last();
            for (int i = 0; i < pList.Count-2; i++)
            {
                if (head.IsHit(pList[i]))
                {
                    return true;
                }
            }
            return false;
        }

   

        public Point GetNextPoint()
        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);

            return nextPoint;
        }

        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow && direction != Direction.RIGHT)
                direction = Direction.LEFT;
            else if (key == ConsoleKey.RightArrow && direction != Direction.LEFT)
                direction = Direction.RIGHT;
            else if (key == ConsoleKey.UpArrow && direction != Direction.DOWN)
                direction = Direction.UP;
            else if (key == ConsoleKey.DownArrow && direction != Direction.UP)
                direction = Direction.DOWN;

        }

        public bool Eat(Point food )
        {
            Point head = GetNextPoint();
            
            if (head.IsHit(food))
            {
                food.sym = head.sym;
                pList.Add(food);
                head.Draw();
                return true;
            }
            return false;
        }
    }
}
