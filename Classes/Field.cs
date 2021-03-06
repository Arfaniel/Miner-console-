﻿using System;
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
        public Player me;
        object[,] field;
        object[,] showField;
        public int curX;
        public int curY;
        int bombs;
        public delegate void press();
        public delegate IBomb isBlast();
       
        public Field()
        {
            me = new Player();
            field = new object[10, 10];
            showField = new object[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    showField[i,j] = '■';
                }
            }
            bombs = 20;
            curX = 0;
            curY = 0;
        }
        public void PlantBombs() //расставляем бомбы
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
        bool isBomb(int x, int y) //проверка на наличие бомбы по координате (для расстановки бомб)
        {
            if (field[x, y] is IBomb)
                return false;
            return true;
        }
        public void openCell()//вскрытие ячейки
        {
            showField[curX, curY] = field[curX, curY];
            if(field[curX, curY] is IBomb)
            {
                IBomb temp = (IBomb)field[curX, curY];
                temp.Explode(me);
            }
        }

        public void setFlag()//поместить флаг по ячейке
        {
            showField[curX, curY] = 'f';
        }
        public void setNums()//расстановка цифр в ячейки без бомб (для инициацлизации поля)
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
        private int bombCounter(int x,  int y) //просчитывает кол-во бомб в соседних ячейках (для проставления номера в ячейку)
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
        public void ShowHidden() // показывает поле с бомбами и цифрами (для проверки)
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
        public void Show() //показывает игровое поле
        {
            Console.Clear();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == curX && j == curY)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(showField[i,j]);
                        Console.ResetColor();
                    }
                    else
                        Console.Write(showField[i, j]);
                }
                Console.WriteLine();
            }
        }
        public void moveOnGrid(ConsoleKeyInfo a) //двигаемся курсором по полю
        {
            if (a.Key == ConsoleKey.DownArrow && curX < 9)
                curX++;
            if (a.Key == ConsoleKey.UpArrow && curX > 0 && curX <= 9)
                curX--;
            if (a.Key == ConsoleKey.LeftArrow && curY <= 9 && curY > 0)
                curY--;
            if (a.Key == ConsoleKey.RightArrow && curY >= 0 && curY < 9)
                curY++;
            if (a.Key == ConsoleKey.Enter)
                openCell();
            if (a.Key == ConsoleKey.Spacebar)
                setFlag();
        }

        public void isLoose()
        {
                Console.WriteLine("You loose");
        }
        public void isWin()
        {
                Console.WriteLine("You win");
        }
        public bool isWinner()
        {
            int countbombs = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (field[i, j] is IBomb)
                        if (showField[i, j] == "f" || showField[i, j] == "M" || showField[i, j] == "b" || showField[i, j] == "T")
                            countbombs++;
                }
            }
            if (countbombs == 20)
                return true;
            return false;
        }
    }
}
                    
