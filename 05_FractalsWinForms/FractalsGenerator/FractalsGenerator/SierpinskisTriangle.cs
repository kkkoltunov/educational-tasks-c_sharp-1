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
    // Класс треугольника Серпинского.
    class SierpinskisTriangle : Fractal
    {
        // Метод для отрисовки фрактала.
        public override void DrawFractal(PictureBox pictureBox)
        {
            // Подсчет длины стороны.
            float sideLength = (float)lengthFactor * (pictureBox.Size.Width + pictureBox.Size.Height);

            // Подсчет радиуса для отрисовки.
            float radius = sideLength / (float)Math.Sqrt(3);

            // Подсчет координат точек для начала отрисовки.
            PointF[] points = CalculateStartingPoints(radius, sideLength);

            // Создание кисти для закрашивания участков.
            SolidBrush brush = new SolidBrush(Color.DarkMagenta);

            // Закрашивание участка по указанным точкам.
            gr.FillPolygon(brush, points);

            // Отрисовка по итерациям.
            DrawSierpinskiTriangle(depth - 1, depth - 1, points, sideLength);
        }

        // Отрисовка фрактала по переданным координатам.
        private void DrawSierpinskiTriangle(int depth, int maxDepth, PointF[] tops, float initialLength)
        {
            if (depth > 0)
            {
                // Создание кисти для закрашивания участков.
                SolidBrush brush = new SolidBrush(Color.White);

                // Создания массива точек (по которым будет происходить закрашивание).
                PointF[] point = new PointF[3];

                // Подсчет координат для каждой точки.
                point[0] = new PointF((tops[0].X + tops[1].X) / 2f, (tops[0].Y + tops[1].Y) / 2f);
                point[1] = new PointF((tops[0].X + tops[2].X) / 2f, (tops[0].Y + tops[2].Y) / 2f);
                point[2] = new PointF((tops[1].X + tops[2].X) / 2f, (tops[1].Y + tops[2].Y) / 2f);

                // Проверка ограничения (в случае отрисовок вне зоны видимости, она будет прервана).
                if (limit && ((point[1].X - point[0].X) / initialLength < 0.01 || depthLimit == maxDepth - depth))
                {
                    depthLimit = maxDepth - depth;
                    return;
                }

                // Закрашивание участка по указанным точкам.
                gr.FillPolygon(brush, point);

                // Отрисовка по итерациям.
                DrawSierpinskiTriangle(depth - 1, maxDepth, new PointF[] { tops[0], point[0], point[1] }, initialLength);
                DrawSierpinskiTriangle(depth - 1, maxDepth, new PointF[] { point[0], tops[1], point[2] }, initialLength);
                DrawSierpinskiTriangle(depth - 1, maxDepth, new PointF[] { point[1], point[2], tops[2] }, initialLength);
            }
        }

        // Подсчет координат для начальных точек.
        PointF[] CalculateStartingPoints(float radius, float side)
        {
            // Создание массива точек.
            PointF[] points = new PointF[3];

            // Координаты по оси X и Y.
            float X, Y;

            // Подсчет координат для каждой из точек.
            X = _mousePt.X;
            Y = _mousePt.Y - radius;
            points[0] = new PointF(X, Y);

            X = _mousePt.X - side / 2;
            Y = _mousePt.Y + (float)Math.Sqrt(3) * side / 6;
            points[1] = new PointF(X, Y);

            X = _mousePt.X + side / 2;
            Y = _mousePt.Y + (float)Math.Sqrt(3) * side / 6;
            points[2] = new PointF(X, Y);

            return points;
        }
    }
}
