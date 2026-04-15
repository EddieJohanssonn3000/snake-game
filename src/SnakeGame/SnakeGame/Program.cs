using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

int width = 20;
int height = 10;

var snake = new List<(int x, int y)>
{
    (5, 5),
    (4, 5),
    (3, 5)
};

int dirX = 1;
int dirY = 0;

var random = new Random();
(int x, int y) food = (10, 3);

Console.CursorVisible = false;

while (true)
{
    Console.Clear();

    // Gameboard
    for (int y = 0; y < height; y++)
    {
        for (int x = 0; x < width; x++)
        {
            if (x == food.x && y == food.y)
                Console.Write("X");
            else if (snake.Any(s => s.x == x && s.y == y))
                Console.Write("O");
            else
                Console.Write(".");
        }
        Console.WriteLine();
    }

    // Input
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

    // Movement
    var head = snake[0];
    var newHead = (head.x + dirX, head.y + dirY);

    // 💀 Vägg-kollision
    if (newHead.x < 0 || newHead.x >= width || newHead.y < 0 || newHead.y >= height)
    {
        Console.Clear();
        Console.WriteLine("Game Over!");
        break;
    }

    snake.Insert(0, newHead);

    // Food
    if (newHead == food)
    {
        food = (random.Next(width), random.Next(height));
    }
    else
    {
        snake.RemoveAt(snake.Count - 1);
    }

    Thread.Sleep(200);
}