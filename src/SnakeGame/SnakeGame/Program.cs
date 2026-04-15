using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

var snake = new List<(int x, int y)>
{
    (5, 5),
    (4, 5),
    (3, 5)
};

int width = 20;
int height = 10;

int dirX = 1;
int dirY = 0;

Console.CursorVisible = false;

while (true)
{
    Console.Clear();

    for (int y = 0; y < height; y++)
    {
        for (int x = 0; x < width; x++)
        {
            bool isSnake = snake.Any(s => s.x == x && s.y == y);

            if (isSnake)
                Console.Write("O");
            else
                Console.Write(".");
        }
        Console.WriteLine();
    }

    if (Console.KeyAvailable)
    { 
        var key = Console.ReadKey(true).Key;

        if (key == ConsoleKey.UpArrow)
        {
            dirX = 0;
            dirY = -1;
        }
        if (key == ConsoleKey.DownArrow)
        {
            dirX = 0;
            dirY = 1;
        }
        if (key == ConsoleKey.LeftArrow)
        {
            dirX = -1;
            dirY = 0;
        }
        if (key == ConsoleKey.RightArrow)
        {
            dirX = 1;
            dirY = 0;
        }
    }
    
    var head = snake[0];
    var newHead = (head.x + dirX, head.y + dirY);

    snake.Insert(0, newHead);
    snake.RemoveAt(snake.Count - 1);
    
    if (newHead.x < 0 || newHead.x >= width || newHead.y < 0 || newHead.y >= height)
    {
        Console.Clear();
        Console.WriteLine("Game Over!");
        break;
    }
    
    Thread.Sleep(200);
}