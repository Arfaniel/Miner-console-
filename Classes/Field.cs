using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ConsoleApplication1.Interfaces;

namespace ConsoleApplication1.Classes
{
    public class Field
    {
        object[,] field;
        object[,] showField;
        int bombs;
        public Field()
        {
            field = new object[10, 10];
            showField = new object[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    showField[i,j] = " ";
                }
            }
            bombs = 20;

        }
        public Field(int a, int b)
        {
            field = new object[a, b];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    field[i, j] = new object();
                    field[i, j] = ' ';
                }
            }
            showField = new object[10, 10];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    showField[i, j] = ' ';
                }
            }
            bombs = 20;
        }
        public void PlantBombs()
        {
            Random rand = new Random();
            int countRegular = 0;
            int counterMega = 0;
            int counterTime = 0;
            do
            {
                int rx = rand.Next(0, 10);
                Thread.Sleep(39);
                int ry = rand.Next(0, 10);
                if (isBomb(rx, ry) == true)
                {
                    field[rx, ry] = new Bomb();
                    countRegular++;
                }
                else
                    continue;
            } while (countRegular != 6);
            do
            {
                int rx = rand.Next(0, 10);
                Thread.Sleep(39);
                int ry = rand.Next(1, 10);
                if (isBomb(rx, ry) == true)
                {
                    field[rx, ry] = new Megabomb();
                    counterMega++;
                }
                else
                    continue;
            } while (counterMega != 6);
            do
            {
                int rx = rand.Next(0, 10);
                Thread.Sleep(39);
                int ry = rand.Next(0, 10);
                if (isBomb(rx, ry) == true)
                {
                    field[rx, ry] = new TimeBomb();
                    counterTime++;
                }
                else
                    continue;
            } while (counterTime != 6);

        }
        bool isBomb(int x, int y)
        {
            if (field[x, y] is IBomb)
                return false;
            return true;
        }
        public void setNums()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if(field[i,j] is IBomb)
                    {
                        continue;
                    }
                    else
                        field[i, j] = bombCounter(i, j);
                }
            }
        }
        private int bombCounter(int x,  int y)
        {
            int countBombs = 0;
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i >= 0 && i < 10 && j < 10 && j >= 0)
                    {
                        if (field[i, j] is IBomb)
                            countBombs++;
                    }
                }
            }
            return countBombs;
        }
        public void ShowHidden()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(field[i,j]);
                    Console.Write('|');
                }
                Console.WriteLine();
            }
        }
        public void Show(int x, int y)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == x && j == y)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write('■');
                        Console.ResetColor();
                    }
                    else
                        Console.Write('■');
                }
                Console.WriteLine();
            }
        }
    }
}
                    
