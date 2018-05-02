/*
Создать  класс  четырехугольник,  члены  класса  –  координаты  4-х  точек.  
Предусмотреть  в  классе методы проверки существования четырехугольника 
вычисления и вывода сведений о фигуре – длины сторон,  диагоналей,  
периметр,  площадь.  Создать  производный  класс  –  параллелограмм, 
предусмотреть  в  классе  проверку,  является  ли  фигура  параллелограммом. 
Написать  программу, демонстрирующую  работу  с  классом:  
дано  N  четырехугольников  и  M  параллелограммов,  найти среднюю площадь 
N четырехугольников и параллелограммы наименьшей и наибольшей площади.  
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace testApp
{
    public struct Point
    {
        public double x;
        public double y;
    }

    public class Quadrilateral
    {
        private Point _A, _B, _C, _D;//TODO вернуть private после тестирования

        public Quadrilateral(Point A, Point B, Point C, Point D)
        {
            _A = A; _B = B; _C = C; _D = D;
        }

        public Quadrilateral(double a_x, double a_y,
                             double b_x, double b_y,
                             double c_x, double c_y,
                             double d_x, double d_y)
        {
            _A.x = a_x; _A.y = a_y;
            _B.x = b_x; _B.y = b_y;
            _C.x = c_x; _C.y = c_y;
            _D.x = d_x; _D.y = d_y;
        }

        private double _GetPointsDistance(Point A, Point B)
        {
            double distance = Math.Sqrt(Math.Pow((B.x - A.x), 2) +
                              Math.Pow((B.y - A.y), 2));
            return distance;
        }

        public double GetPerimeter()
        {
            double perimeter = _GetPointsDistance(_A, _B) +
                               _GetPointsDistance(_B, _C) +
                               _GetPointsDistance(_C, _D);
            return perimeter;
        }

        public bool IsQuadrilateral()
        {
            bool isQuadrilateral = true;
            ///TODO Заменить на заготовочку
            if (IsOneLinePoints(_A, _B, _C) ||
                 IsOneLinePoints(_A, _B, _D) ||
                 IsOneLinePoints(_A, _C, _B) ||
                 IsOneLinePoints(_A, _C, _D) ||
                 IsOneLinePoints(_A, _D, _B) ||
                 IsOneLinePoints(_B, _A, _C) ||
                 IsOneLinePoints(_B, _A, _D) ||
                 IsOneLinePoints(_B, _C, _D) ||
                 IsOneLinePoints(_B, _A, _D) ||
                 IsOneLinePoints(_B, _C, _D) ||
                 IsOneLinePoints(_B, _D, _C) ||
                 IsOneLinePoints(_C, _A, _D) ||
                 IsOneLinePoints(_D, _B, _C)
               )
            {
                isQuadrilateral = false;
            }
            return isQuadrilateral;
        }

        public double GetArea()
        {
            //Используем формулу площади Гаусса
            double area = Math.Abs(
                _A.x * _B.y +
                _B.x * _C.y +
                _C.x * _D.y +
                _D.x * _A.y -
                _B.x * _A.y -
                _C.x * _B.y -
                _D.x * _C.y -
                _A.x * _D.y) / 2.00;

            return area;
        }

        private bool IsOneLinePoints(Point A, Point B, Point C)
        {
            bool isOnLine = false;
            if (
                ((A.x - C.x) / (B.x - C.x)) ==
                ((A.y - C.y) / (B.y - C.y))
                )
            {
                isOnLine = true;
            }

            return isOnLine;
        }

        public double GetACDiag()
        {
            return _GetPointsDistance(_A, _C);
        }

        public double GetBDDiag()
        {
            return _GetPointsDistance(_B, _D);
        }

        public double [] GetSides()
        {
            double[] sides = new double[4];
            sides[0] = _GetPointsDistance(_A, _B);
            sides[1] = _GetPointsDistance(_B, _C);
            sides[2] = _GetPointsDistance(_C, _D);
            sides[3] = _GetPointsDistance(_A, _D);
     
            return sides;
        }
        
    }

    public class Parallelogram : Quadrilateral
    {
        //Передаем аргументы из конструктора дочернего класса в базовый класс
        public Parallelogram(Point A, Point B, Point C, Point D):base(A,B,C,D){}
        public Parallelogram(double a_x, double a_y,
                             double b_x, double b_y,
                             double c_x, double c_y,
                             double d_x, double d_y) : base(a_x, a_y,
                                                             b_x,b_y,
                                                             c_x, c_y,
                                                             d_x, d_y) { }

        public bool IsParallelogram()
        {
            bool isParallelogram = false;
            double[] sides = GetSides();
            if ((sides[0] == sides[2])&&(sides[1] == sides[3])) {
                isParallelogram = true;
            }
            return isParallelogram;
        }

    }


    class Program
    {
        static void Main(string[] args)
        {
            //Trial code BEGIN
            Console.CursorSize = 100;
            Console.Title = "Radov Stanislav";
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Author: Radov Stanislav!");
            Console.ResetColor();
            //Trial code END
            const int N = 1000;
            const int M = 1000;
            //Инициализация массива фигур
            Quadrilateral[] quadArray = new Quadrilateral[N];
            Parallelogram[] parArray = new Parallelogram[M];

            Random rand = new Random();//Потоко небезопасно
            //Массив случайных координат точек Четырехугольников
            int[,] qArr = new int[N,8];
            //Генерим массив координат для Четыр-ка
            for (int i = 0; i < N; i++) {
                for(int j =0; j < 8; j++) {
                    qArr[i,j] = rand.Next(-50, 50);
                }
            }
            //Массив случайных координат точек Параллелограмов
            int[,] pArr = new int[M, 8];
            //Генерим точки для Парал-ов
            for (int i = 0; i < M; i++) {
                for (int j = 0; j < 8; j++) {
                    pArr[i, j] = rand.Next(-50, 50);
                }
            }
            Console.WriteLine("Random coordinates generation completed successfull");

            //Определение массива Четырехугольников
            for (int i = 0; i < N; i++) {
                quadArray[i] = new Quadrilateral(qArr[i, 0], qArr[i, 1], qArr[i, 2], qArr[i, 3], qArr[i, 4], qArr[i, 5], qArr[i, 6], qArr[i, 7]);
            }
            Console.WriteLine(Convert.ToString(N) + " quadrilaterals was generated");

            //Определение массива Параллелограмов
            for (int i = 0; i < M; i++) {
                parArray[i] = new Parallelogram(pArr[i, 0], pArr[i, 1], pArr[i, 2], pArr[i, 3], pArr[i, 4], pArr[i, 5], pArr[i, 6], pArr[i, 7]);
            }
            Console.WriteLine(Convert.ToString(M) + " parallelograms was generated");

            //Подсчитаем среднюю площадь четырехугольников
            double sumQuadArray = 0;
            for(int i = 0; i < N; i++) {
                sumQuadArray += quadArray[i].GetArea();//получаем площадь каждой фигуры массива
                //Console.WriteLine("Figure #" + Convert.ToString(i) + (quadArray[i].IsQuadrilateral()?" is quad":" not quad"));
            }
            double quadAverageArea = sumQuadArray / N;//Средняя площадь четырехугольников
            Console.WriteLine("Average area of " + Convert.ToString(N) + " quads is: " + Convert.ToString(quadAverageArea));

            //Найдем найменьший и наименьший параллелограм
            double minParalArea = parArray[0].GetArea();
            double maxParalArea = minParalArea;
            for (int i = 0; i < M; i++) {
                double curFigureArea = parArray[i].GetArea();
                if (curFigureArea > maxParalArea) {
                    maxParalArea = curFigureArea;
                }
                if (curFigureArea < minParalArea) {
                    minParalArea = curFigureArea;
                }
            }
            Console.WriteLine("Min paral area is: " + Convert.ToString(minParalArea) + "\nMax paral area is: " + Convert.ToString(maxParalArea) );

            Console.ReadLine();//Для паузы//Костыль
        }
    }
}
