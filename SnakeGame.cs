using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text;

public class SnakeGame
{
    private static int selection = 0;
    private static int[] your_date = new int[8];

    // other variable 
    public static void Main(string[] args)
    {
        Setup();
        // Display_3D();
    }

    private static void Setup()
    {
        Console.ResetColor();
        Console.Clear();

        SnakeGame game = new SnakeGame();
        cursorPosition();
    }
    private SnakeGame()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("  -- Snake Game --  ");
        Console.ResetColor();
        
        Console.WriteLine("\n-< Enter your Date >-");
        Console.WriteLine("    .. / .. / ....");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n    | PLAY GAME! |\n");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("    | SOMEONE-NAME |\n");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("    | EXIT |\n");
        Console.ResetColor();
    }

    private static void cursorPosition(){
        
        // Set up value selection
        location_Date();
        Console.SetCursorPosition(1,11);
        Console.Write("Selection: {0}",selection);
        

        while(true)
        {
            var key = Console.ReadKey().Key; 

            if(key == ConsoleKey.Enter)
            {
                if(selection == 0)
                {
                    Console.SetCursorPosition(4, 3);
                    Console.Write("..");
                    Console.SetCursorPosition(9, 3);
                    Console.Write("..");
                    Console.SetCursorPosition(14, 3);
                    Console.Write("....");

                    Console.SetCursorPosition(4, 3);
                    ConsoleKeyInfo D1 = Console.ReadKey();
                    Console.SetCursorPosition(5, 3);
                    ConsoleKeyInfo D2 = Console.ReadKey();
                    /* True numbers for Date*/
                    char text_D1 = convert_ASCII_to_Text(D1.Key);
                    char text_D2 = convert_ASCII_to_Text(D2.Key);
                    /* Date */ if(Convert.ToInt32(String.Concat(text_D1, text_D2)) >= 31)
                                {
                                    Console.SetCursorPosition(4,3);
                                    Console.Write("31");

                                    text_D1 = '3'; text_D2 = '1';
                                }

                    Console.SetCursorPosition(9, 3);
                    ConsoleKeyInfo M1 = Console.ReadKey();
                    Console.SetCursorPosition(10, 3);
                    ConsoleKeyInfo M2 = Console.ReadKey();
                    /* True numberese for Month*/
                    char text_M1 = convert_ASCII_to_Text(M1.Key);
                    char text_M2 = convert_ASCII_to_Text(M2.Key);
                    /* Month */ if(Convert.ToInt32(String.Concat(text_M1, text_M2)) >= 12)
                                {
                                    Console.SetCursorPosition(9,3);
                                    Console.Write("12");

                                    text_M1 = '1'; text_M2 = '2';
                                }

                    Console.SetCursorPosition(14, 3);
                    ConsoleKeyInfo Y1 = Console.ReadKey();
                    Console.SetCursorPosition(15, 3);
                    ConsoleKeyInfo Y2 = Console.ReadKey();
                    Console.SetCursorPosition(16, 3);
                    ConsoleKeyInfo Y3 = Console.ReadKey();
                    Console.SetCursorPosition(17, 3);
                    ConsoleKeyInfo Y4 = Console.ReadKey();
                    // True value of Year
                    char text_Y1 = convert_ASCII_to_Text(Y1.Key);
                    char text_Y2 = convert_ASCII_to_Text(Y2.Key);
                    char text_Y3 = convert_ASCII_to_Text(Y3.Key);
                    char text_Y4 = convert_ASCII_to_Text(Y4.Key);

                    Console.SetCursorPosition(1,12);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("-- Your Date: {0}{1} / {2}{3} / {4}{5}{6}{7}               ", text_D1,text_D2 , text_M1,text_M2 , text_Y1,text_Y2,text_Y3,text_Y4);
                    Console.ResetColor();

                    DateTime date = DateTime.Now;
                    Console.SetCursorPosition(1,13);

                    int Date = Math.Abs(date.Day - Convert.ToInt32(String.Concat(text_D1, text_D2)));
                    int Month = Math.Abs(date.Month - Convert.ToInt32(String.Concat(text_M1, text_M2)));
                    int Year = Math.Abs(date.Year - Convert.ToInt32(String.Concat(text_Y1, text_Y2, text_Y3, text_Y4)));

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("-- Your Ages: {0} years {1} months {2} days                   ",Year-1,Month,Date);
                    Console.ResetColor();
                }

                else if(selection == 1)
                {
                    game_Play();
                    Setup();
                }

                else if(selection == 2)
                {
                    Display_3D();
                    Setup();
                }

                else if(selection == 3)
                {
                    Console.SetCursorPosition(1,12);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(new string(' ',Console.WindowWidth));
                    Console.Write("Exiting");
                    Console.WriteLine(new string(' ',Console.WindowWidth));
                    Console.ResetColor();

                    Thread.Sleep(1000);

                    Console.SetCursorPosition(1,12);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(new string(' ',Console.WindowWidth));
                    Console.Write("Exiting.");
                    Console.WriteLine(new string(' ',Console.WindowWidth));
                    Console.ResetColor();
                    
                    Thread.Sleep(1000);

                    Console.SetCursorPosition(1,12);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(new string(' ',Console.WindowWidth));
                    Console.Write("Exiting..");
                    Console.WriteLine(new string(' ',Console.WindowWidth));
                    Console.ResetColor();
                    
                    Thread.Sleep(1000);

                    Console.SetCursorPosition(1,12);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(new string(' ',Console.WindowWidth));
                    Console.Write("Exiting...");
                    Console.WriteLine(new string(' ',Console.WindowWidth));
                    Console.ResetColor();

                    Thread.Sleep(1000);

                    Console.Clear();
                    Environment.Exit(0);
                }
            }
            else if(key == ConsoleKey.UpArrow)
            {
                selection--;
                clear_Location();
            }
            else if(key == ConsoleKey.DownArrow)
            {
                selection++;
                clear_Location();
            }

            // Checking selection value
            if(selection < 0) 
            { 
                selection = 3;
            }
            else if(selection > 3)
            {
                selection = 0;
            }

            // Selection option in menu of Snake_game
            Console.SetCursorPosition(1,11);
            Console.Write("Selection: {0}",selection);

            // Choice in menu game
            switch(selection)
            {
                case 0:
                    location_Date();
                    break;
                case 1:
                    location_Play();
                    break;
                case 2:
                    location_Option();
                    break;
                case 3:
                    location_Exit();
                    break;
            }
        }
    }


    // Location of selection menu
    private static void location_Date()
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(0,3);
        Console.Write(">> ");
    }
    private static void location_Play()
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(0,5);
        Console.Write(">> ");
    }
    private static void location_Option()
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(0,7);
        Console.Write(">> ");
    }
    private static void location_Exit()
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(0,9);
        Console.Write(">> ");
    }

    private static void clear_Location()
    {
        Console.SetCursorPosition(0,3);
        Console.Write("   ");
        Console.SetCursorPosition(0,5);
        Console.Write("   ");
        Console.SetCursorPosition(0,7);
        Console.Write("   ");
        Console.SetCursorPosition(0,9);
        Console.Write("   ");
        
    }

    private static char convert_ASCII_to_Text(ConsoleKey key)
    {
        int ASCII = Convert.ToInt32(key);
        char Text = Convert.ToChar(ASCII);
        return Text;
    }

    // main of snake gameplay 
    private static void game_Play()
    {
        int i = 0;
        Console.Clear();

        for(int x=15; x>=0; x--)
        {
            Console.Write('*');

            for(int y=150; y>=0; y--)
            {
                if(i==0)
                {
                    Console.Write('*');
                }
                else if(i==15)
                {
                    Console.Write('*');
                }
                else
                {
                    Console.Write(" ");
                }
            }
            i++;
            Console.WriteLine('*');
        }
        while(true){}
        // SnakeGame.Main(new string[] {});
    }

    private static void Display_3D()
    {
        int line = 12;
        Console.Clear();
        Console.WriteLine();
        Console.CursorVisible = false;

        for(int x=14; x>0; x--)
        {
            for(int y=150; y>=0; y--)
            {
                Console.Write('*');
            }
            Console.WriteLine('*');
        }

        // Letter M
        for(int i=2; i<=13; i++)
        {
            Console.SetCursorPosition(18+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }
        for(int i=2; i<=13; i++)
        {
            Console.SetCursorPosition(19+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }
        for(int i=2; i<=13; i++)
        {
            Console.SetCursorPosition(20+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }

        for(int i=2; i<=9; i++)
        {
            Console.SetCursorPosition(19+i+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }
        for(int i=2; i<=9; i++)
        {
            Console.SetCursorPosition(20+i+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }
        for(int i=2; i<=9; i++)
        {
            Console.SetCursorPosition(21+i+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }

        for(int i=2; i<=9; i++)
        {
            Console.SetCursorPosition(37-i+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }
        for(int i=2; i<=9; i++)
        {
            Console.SetCursorPosition(38-i+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }
        for(int i=2; i<=9; i++)
        {
            Console.SetCursorPosition(39-i+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }

        for(int i=2; i<=13; i++)
        {
            Console.SetCursorPosition(38+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }
        for(int i=2; i<=13; i++)
        {
            Console.SetCursorPosition(39+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }
        for(int i=2; i<=13; i++)
        {
            Console.SetCursorPosition(40+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }

        //Letter I
        for(int i=2; i<=13; i++)
        {
            Console.SetCursorPosition(49+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }
        for(int i=2; i<=13; i++)
        {
            Console.SetCursorPosition(50+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }
        for(int i=2; i<=13; i++)
        {
            Console.SetCursorPosition(51+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }

        for(int i=2; i<=2; i++)
        {
            Console.SetCursorPosition(45+line,i);
            Console.Write(' ');
            Thread.Sleep(20);

            for(int j=0; j<=10; j++)
            {
                Console.SetCursorPosition(45+j+line,i);
                Console.Write(' ');
                Thread.Sleep(20);
            }
        }
        for(int i=13; i<=13; i++)
        {
            Console.SetCursorPosition(45+line,i);
            Console.Write(' ');
            Thread.Sleep(20);

            for(int j=0; j<=10; j++)
            {
                Console.SetCursorPosition(45+j+line,i);
                Console.Write(' ');
                Thread.Sleep(20);
            }
        }

        //Letter N
        for(int i=2; i<=13; i++)
        {
            Console.SetCursorPosition(60+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }
        for(int i=2; i<=13; i++)
        {
            Console.SetCursorPosition(61+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }
        for(int i=2; i<=13; i++)
        {
            Console.SetCursorPosition(62+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }

        for(int i=2; i<=13; i++)
        {
            Console.SetCursorPosition(61+i+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }
        for(int i=2; i<=13; i++)
        {
            Console.SetCursorPosition(62+i+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }
        for(int i=2; i<=13; i++)
        {
            Console.SetCursorPosition(63+i+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }

        for(int i=2; i<=13; i++)
        {
            Console.SetCursorPosition(76+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }
        for(int i=2; i<=13; i++)
        {
            Console.SetCursorPosition(77+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }
        for(int i=2; i<=13; i++)
        {
            Console.SetCursorPosition(78+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }

        //Letter A
        for(int i=13; i>=2; i--)
        {
            Console.SetCursorPosition(96-i+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }
        for(int i=13; i>=2; i--)
        {
            Console.SetCursorPosition(97-i+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }
        for(int i=13; i>=2; i--)
        {
            Console.SetCursorPosition(98-i+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }
        
        for(int i=13; i>=2; i--)
        {
            Console.SetCursorPosition(94+i+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }
        for(int i=13; i>=2; i--)
        {
            Console.SetCursorPosition(95+i+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }
        for(int i=13; i>=2; i--)
        {
            Console.SetCursorPosition(96+i+line,i);
            Console.Write(' ');
            Thread.Sleep(20);
        }

        for(int i=90; i<=104; i++)
        {
            Console.SetCursorPosition(i+line,9);
            Console.Write(' ');
            Thread.Sleep(20);
        }

        //---------------------------------------

        // Exit program
        Console.SetCursorPosition(60,15);
        Console.Write("Click ESC to exit[]");

        while (true){
            var key = Console.ReadKey().Key;
            if(key == ConsoleKey.Escape)
            {
               break; 
            }
        }
    }
}