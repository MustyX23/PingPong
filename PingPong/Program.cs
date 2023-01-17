using System;
using System.Linq;
using System.Threading;

namespace PingPong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Setting the Field UP...

            const int fieldLength = 50;
            const int fieldWidth = 15;
            const char fieldTile = '#';

            string line = string.Concat(Enumerable.Repeat(fieldTile, fieldLength));

            const int racketLength = fieldWidth / 4;
            const char racketTile = '|';

            int rightRacketHeight = 0;
            int leftRacketHeight = 0;

            //Adding the Ball
            int ballX = fieldLength / 2;
            int ballY = fieldWidth / 2;
            const char ballTile = 'O';

            //Adding Ball Directions
            bool isBallGoingDown = true;
            bool isBallGoingRight = true;

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(line);

                Console.SetCursorPosition(0, fieldWidth);
                Console.WriteLine(line);

                for (int i = 0; i < racketLength; i++)
                {
                    Console.SetCursorPosition(0, i + 1 + leftRacketHeight);
                    Console.WriteLine(racketTile);
                    Console.SetCursorPosition(fieldLength - 1, i + 1 + rightRacketHeight);
                    Console.WriteLine(racketTile);
                }

                

                while (!Console.KeyAvailable)
                {
                    Console.SetCursorPosition(ballX, ballY);
                    Console.WriteLine(ballTile);
                    Thread.Sleep(100);

                    if (isBallGoingDown)
                    {
                        ballY++;
                    }
                    else
                    {
                        ballY--;
                    }
                    if (isBallGoingRight)
                    {
                        ballX++;
                    }
                    else
                    {
                        ballX--;
                    }
                }

                //Here we are implementing players movement
                switch (Console.ReadKey().Key)
                {
                    //'UpArrow' == 'W'
                    case ConsoleKey.UpArrow:
                        if (rightRacketHeight > 0)
                        {
                            rightRacketHeight--;
                        }
                        break;

                    //'DownArrow' == 'S'
                    case ConsoleKey.DownArrow:
                        if (rightRacketHeight < fieldWidth - racketLength - 1)
                        {
                            rightRacketHeight++;
                        }
                        break;

                    //'UpArrow' == 'W'
                    case ConsoleKey.W:
                        if (rightRacketHeight > 0)
                        {
                            leftRacketHeight--;
                        }
                        break;

                    //'DownArrow' == 'S'
                    case ConsoleKey.S:
                        if (rightRacketHeight < fieldWidth - racketLength - 1)
                        {
                            leftRacketHeight++;
                        }
                        break;
                }

                //Fix - now the old lines are being removed!
                for (int i = 1; i < fieldWidth; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.WriteLine(' ');
                    Console.SetCursorPosition(fieldLength - 1, i);
                    Console.WriteLine(' ');
                }
            }

        }
    }
}
