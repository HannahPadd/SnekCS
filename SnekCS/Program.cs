using System;
using System.Globalization;
using System.Security;

namespace SnekCS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.Gray;
            bool isRunning = true;
            int snekX = 1;
            int snekY = 1;
            int snekXrel = 0;
            int snekYrel = 0;
            int playingFieldX = 60;
            int playingFieldY = 30;
            string playingField = "";
            char wall = '#';
            char tile = '-';

            for (int i = 0; i < playingFieldY; i++)
            {
                if (i == 0 || i == playingFieldY - 1)
                {
                    playingField += $"{(new string(wall, playingFieldX))}{"\n"}";
                }
                else
                {
                    playingField += $"{wall}{new string(tile, playingFieldX - 2)}{wall}{"\n"}";
                }
            }
            //Game Loop
            while (isRunning)
            {

                //checks to see if the snek's position is inside the window.

                //Creates the frame
                Console.Clear();               
                Console.WriteLine(playingField);

                Console.SetCursorPosition(snekX, snekY);

                Console.WriteLine("*");

                //Read the key that has been pressed
                string pressedKey = returnKey();

                //Moves snek boyo
                snekX += MoveSnekX(pressedKey) + snekXrel;
                snekY += MoveSnekY(pressedKey) + snekYrel;

                //Checks the position of the snek so he doesn't go out of bounds
                if (snekX < 1 || snekY < 1)
                {
                    if (snekX < 1)
                    {
                        snekX = playingFieldX - 2;
                    }
                    if (snekY < 1)
                    {
                        snekY =  playingFieldY - 2;
                    }
                    Console.SetCursorPosition(snekX, snekY);
                }

                if (snekX >= playingFieldX - 1 || snekY >= playingFieldY - 1)
                {
                    if (snekX >= playingFieldX - 1)
                    {
                        snekX = 1;
                    }
                    if (snekY >= playingFieldY - 1)
                    {
                        snekY = 1;
                    }
                    Console.SetCursorPosition(snekX, snekY);
                }
            }
        }
        
        static string returnKey()
        {
            string pressedKey = "";
            ConsoleKeyInfo pressed = Console.ReadKey();
            switch (pressed.Key)
            {
                case ConsoleKey.UpArrow:
                    pressedKey = "up";
                    break;

                case ConsoleKey.DownArrow:
                    pressedKey = "down";
                    break;

                case ConsoleKey.LeftArrow:
                    pressedKey = "left";
                    break;

                case ConsoleKey.RightArrow:
                    pressedKey = "right";
                    break;
            }

            return pressedKey;
        }

        static int MoveSnekY(string pressedKey)
        {
            int positionChange = 0;
            switch (pressedKey)
            {
                case "up":
                    positionChange = -1;
                    break;

                case "down":
                    positionChange = 1;
                    break;
            }

            return positionChange;
        }

        static int MoveSnekX(string pressedKey)
        {
            int positionChange = 0;
            switch (pressedKey)
            {
                case "left":
                    positionChange = -1;
                    break;

                case "right":
                    positionChange = 1;
                    break;
            }

            return positionChange;
        }
    }
}
