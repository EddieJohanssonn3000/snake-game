using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

Console.CursorVisible = false;

while (true) // Restart-loop
{
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

    int score = 0;

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

        Console.WriteLine($"\nScore: {score}");

        // Input
        if (Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.UpArrow && dirY != 1)
            {
                dirX = 0; dirY = -1;
            }
            if (key == ConsoleKey.DownArrow && dirY != -1)
            {
                dirX = 0; dirY = 1;
            }
            if (key == ConsoleKey.LeftArrow && dirX != 1)
            {
                dirX = -1; dirY = 0;
            }
            if (key == ConsoleKey.RightArrow && dirX != -1)
            {
                dirX = 1; dirY = 0;
            }
        }

        // Movement
        var head = snake[0];
        var newHead = (x: head.x + dirX, y: head.y + dirY);

        // Wall-Collision
        if (newHead.x < 0 || newHead.x >= width || newHead.y < 0 || newHead.y >= height)
        {
            break;
        }

        // Self-Collision
        if (snake.Any(s => s == newHead))
        {
            break;
        }

        snake.Insert(0, newHead);

        // Food
        if (newHead == food)
        {
            score++;
            food = (random.Next(width), random.Next(height));
        }
        else
        {
            snake.RemoveAt(snake.Count - 1);
        }

        Thread.Sleep(200);
    }

    // Game Over + Restart
    Console.Clear();
    Console.WriteLine("=== GAME OVER ===");
    Console.WriteLine($"Final Score: {score}");
    Console.WriteLine("\nPress R to restart or any other key to exit");

    var keyRestart = Console.ReadKey(true).Key;

    if (keyRestart != ConsoleKey.R)
        break; 
}