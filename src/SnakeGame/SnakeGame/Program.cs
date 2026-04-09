using System;
using System.Threading;

int width = 20;
int height = 10;

int snakeX = 5;
int snakeY = 5;

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
            if (x == snakeX && y == snakeY)
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
    
    snakeX += dirX;
    snakeY += dirY;
    
    if (snakeX < 0 || snakeX >= width || snakeY < 0 || snakeY >= height)
    {
        Console.Clear();
        Console.WriteLine("Game Over!");
        break;
    }
    
    Thread.Sleep(200);
}