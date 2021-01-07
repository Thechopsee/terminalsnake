using System;
using System.Text;

namespace snakeval
{

   

    class Program
    {
        public struct snake
        {

           public snake(int x, int y)
            {
                this.x = x;
                this.y = y;

            }
            public int x;
            public int y;

        }

        static void Moves( snake[] had, int snake_size,char smer)
        {

            int xb = had[0].x;
            int yb = had[0].y;
            
            int pred_x = had[0].x;
            int pred_y = had[0].y;

            if (smer == 'u')
            {
                had[0].y--;
            }
            else if (smer == 'd')
            {
                had[0].y++;
            }
            else if (smer == 'l')
            {
                had[0].x--;

            }
            else if (smer == 'r')
            {
                had[0].x++;

            }



            for (int i = 1; i < snake_size; i++)
            {
                pred_x = had[i].x;
                pred_y = had[i].y;

                had[i].x = xb;
                had[i].y = yb;

                xb = pred_x;
                yb = pred_y;
            }

        }

        private static void WriteBoard(int size)
        {
            
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    sb.Append('\u2588');
                }
                sb.AppendLine();

            }
            Console.Clear();
            Console.WriteLine(sb.ToString());

        }

        static void printSnake(snake[] had,int size,int board_size)
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < size; i++)
            {
                if (board_size < had[i].x || board_size < had[i].y || had[i].x < 0 || had[i].y < 0 )
                {
                    Console.Clear();
                    Environment.Exit(0);

                }
                else
                {
                    Console.SetCursorPosition(had[i].x, had[i].y);
                    if (i % 2 > 0)
                    { Console.ForegroundColor = ConsoleColor.Red; }
                    else
                    { Console.ForegroundColor = ConsoleColor.Black; }
                    Console.Write('\u2588');
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;

            const int board_size = 50;
            WriteBoard(board_size);



            int snake_size = 3;
            snake one = new snake(10, 10);
            snake two = new snake(10, 11);
            snake three = new snake(10, 12);
            snake[] snake = { one, two, three };

            printSnake(snake, snake_size,board_size);




            while (true)
            {
                if (Console.KeyAvailable)
                {

                    ConsoleKeyInfo info = Console.ReadKey();
                    if (info.Key == ConsoleKey.RightArrow)
                    {
                        Moves(snake, snake_size, 'r');
                        WriteBoard(board_size);
                        printSnake(snake, snake_size, board_size);


                    }
                    if (info.Key == ConsoleKey.UpArrow)
                    {
                        Moves(snake, snake_size, 'u');
                        WriteBoard(board_size);
                        printSnake(snake, snake_size, board_size);

                    }
                    if (info.Key == ConsoleKey.DownArrow)
                    {

                        Moves(snake, snake_size, 'd');
                        WriteBoard(board_size);
                        printSnake(snake, snake_size, board_size);

                    }
                    if (info.Key == ConsoleKey.LeftArrow)
                    {
                        Moves(snake, snake_size, 'l');
                        WriteBoard(board_size);
                        printSnake(snake, snake_size, board_size);
                    }
                }



            }
        }
    }
}
