using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Compression;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FractalsGenerator
{
    // Класс кривой Коха.
    class KochsCurve : Fractal
    {
        // Метод для отрисовки фрактала.
        public override void DrawFractal(PictureBox pictureBox)
        {
            // Подсчет длины стороны по координатам окна для рисования.
            float sideLength = (float)lengthFactor * (pictureBox.Size.Width + pictureBox.Size.Height);

            // Подсчет радиуса для отрисовки.
            float radius = sideLength / (float)Math.Sqrt(3);

            // Подсчет начальных точек для отрисовки.
            PointF[] points = CalculateStartingPoints(radius, sideLength);

            // Отрисовка фрактала по переданным координатам.
            DrawKochsCurve(points[0], points[1], points[2], depth, depth, sideLength);
        }

        // Отрисовка фрактала по переданным координатам.
        private void DrawKochsCurve(PointF p1, PointF p2, PointF p3, int depthMax, int max, float initialLength)
        {
            // Создание ручек (1 для рисования, 2 для закрашивания).
            Pen pen1 = new Pen(Color.DarkMagenta, 3);
            Pen pen2 = new Pen(Color.White, 3);

            // Отрисовка первых координат.
            if (depthMax == max)
            {
                gr.DrawLine(pen1, p2, p3);

                DrawKochsCurve(p2, p3, p1, depthMax - 1, max, initialLength);
            }

            // Отрисовка до указанной глубины.
            else if (depthMax > 0)
            {
                // Подсчет координат для точек.
                PointF p4 = new PointF((p2.X + 2 * p1.X) / 3, (p2.Y + 2 * p1.Y) / 3);
                PointF p5 = new PointF((2 * p2.X + p1.X) / 3, (p1.Y + 2 * p2.Y) / 3);
                PointF ps = new PointF((p2.X + p1.X) / 2, (p2.Y + p1.Y) / 2);
                PointF pn = new PointF((4 * ps.X - p3.X) / 3, (4 * ps.Y - p3.Y) / 3);

                // Проверка ограничения (в случае отрисовок вне зоны видимости, она будет прервана).
                if (limit && (GetDistance(p4, p5) / initialLength < 0.0001 || depthLimit == max - depthMax))
                {
                    depthLimit = max - depthMax;
                    return;
                }

                // Отрисовка линий по точкам.
                gr.DrawLine(pen1, p4, pn);
                gr.DrawLine(pen1, p5, pn);
                gr.DrawLine(pen2, p4, p5);

                // Отрисовка по итерациям.
                DrawKochsCurve(p4, pn, p5, depthMax - 1, max, initialLength);
                DrawKochsCurve(pn, p5, p4, depthMax - 1, max, initialLength);
                DrawKochsCurve(p1, p4, new PointF((2 * p1.X + p3.X) / 3, (2 * p1.Y + p3.Y) / 3), depthMax - 1, max, initialLength);
                DrawKochsCurve(p5, p2, new PointF((2 * p2.X + p3.X) / 3, (2 * p2.Y + p3.Y) / 3), depthMax - 1, max, initialLength);
            }
        }

        // Получение расстояния между точками (для корректной отрисовки).
        private float GetDistance(PointF point1, PointF point2)
        {
            return ((point1.X - point2.X) * (point1.X - point2.X) + (point1.Y - point2.Y) * (point1.Y - point2.Y));
        }


        // Подсчет начальных точек для отрисовки.
        PointF[] CalculateStartingPoints(float radius, float side)
        {
            // Создание массива точек.
            PointF[] points = new PointF[3];

            // Координаты для оси X и Y.
            float X, Y;

            // 1 точка.
            X = _mousePt.X;
            Y = _mousePt.Y + 2 * radius;
            points[0] = new PointF(X, Y);

            // 2 точка.
            X = _mousePt.X - side / 2;
            Y = _mousePt.Y + (float)Math.Sqrt(3) * side / 6;
            points[1] = new PointF(X, Y);

            // 3 точка.
            X = _mousePt.X + side / 2;
            Y = _mousePt.Y + (float)Math.Sqrt(3) * side / 6;
            points[2] = new PointF(X, Y);

            return points;
        }
    }
}
