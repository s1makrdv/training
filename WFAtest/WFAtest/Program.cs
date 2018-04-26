using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WFAtest
{
    public struct Dot
    {
        public double x;
        public double y;
    }

    public class Quadrilateral
    {
        private Dot _A, _B, _C, _D;//TODO вернуть private после тестирования

        public Quadrilateral(Point[] points) {
            _A.x = points[0].X; _A.y = points[0].Y;
            _B.x = points[1].X; _B.y = points[1].Y;
            _C.x = points[2].X; _C.y = points[2].Y;
            _D.x = points[3].X; _D.y = points[3].Y;
        }

        public Quadrilateral(Dot A, Dot B, Dot C, Dot D)
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

        private double _GetPointsDistance(Dot A, Dot B)
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

        private bool IsOneLinePoints(Dot A, Dot B, Dot C)
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

        public double[] GetSides()
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
        public Parallelogram(Dot A, Dot B, Dot C, Dot D) : base(A, B, C, D) { }
        public Parallelogram(double a_x, double a_y,
                             double b_x, double b_y,
                             double c_x, double c_y,
                             double d_x, double d_y) : base(a_x, a_y,
                                                             b_x, b_y,
                                                             c_x, c_y,
                                                             d_x, d_y){ }
        public Parallelogram(Point[] points) : base(points) { }

        public bool IsParallelogram()
        {
            bool isParallelogram = false;
            double[] sides = GetSides();
            if ((sides[0] == sides[2]) && (sides[1] == sides[3]))
            {
                isParallelogram = true;
            }
            return isParallelogram;
        }

    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
