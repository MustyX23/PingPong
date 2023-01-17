using System;
using System.Linq;

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
            }

        }
    }
}
