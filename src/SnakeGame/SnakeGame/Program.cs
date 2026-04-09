using System;

int width = 20;
int height = 10;

Console.CursorVisible = false;

for (int y = 0; y < height; y++)
{
    for (int x = 0; x < width; x++)
    {
        Console.Write("#");
    }
    Console.WriteLine();
}