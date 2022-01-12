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
    // Класс множества Кантора.
    class CantorsSet : Fractal
    {
        // Метод для отрисовки фрактала.
        public override void DrawFractal(PictureBox pictureBox)
        {
            // Подсчет точки для начала отрезка.
            PointF startPoint = new PointF(_mousePt.X - (float)(lengthFactor * (pictureBox.Size.Width + pictureBox.Size.Height)) / 2,
                _mousePt.Y);

            // Подсчет точки для конца отрезка.
            PointF endPoint = new PointF(_mousePt.X + (float)(lengthFactor * (pictureBox.Size.Width + pictureBox.Size.Height)) / 2,
                _mousePt.Y);

            // Отрисовка по итерациям.
            DrawCantorsSet(startPoint, endPoint, depth, depth, (float)(lengthFactor * (pictureBox.Size.Width + pictureBox.Size.Height)));
        }

        // Отрисовка фрактала по переданным координатам.
        private void DrawCantorsSet(PointF startPoint, PointF endPoint, int depth, int maxDepth, float initialLength)
        {
            if (depth > 0)
            {
                // Проверка ограничения (в случае отрисовок вне зоны видимости, она будет прервана).
                if (limit && ((endPoint.X - startPoint.X) / initialLength < 0.000001 || depthLimit == maxDepth - depth))
                {
                    depthLimit = maxDepth - depth;
                    return;
                }

                // Создание ручки для отрисовки.
                Pen pen = new Pen(Color.DarkMagenta);

                // Установка цвета и ширины 
                PenColorAndWidth(depth, maxDepth, ref pen);

                // Отрисовка линии.
                gr.DrawLine(pen, startPoint, endPoint);

                // Пересчет координат.
                PointF startPoint1 = new PointF(startPoint.X, startPoint.Y + layerDistance);
                PointF endPoint1 = new PointF(endPoint.X - 2 * (endPoint.X - startPoint.X) / 3, endPoint.Y + layerDistance);
                PointF startPoint2 = new PointF(endPoint.X - (endPoint.X - startPoint.X) / 3, endPoint.Y + layerDistance);
                PointF endPoint2 = new PointF(endPoint.X, endPoint.Y + layerDistance);

                // Отрисовка по итерациям.
                DrawCantorsSet(startPoint1, endPoint1, depth - 1, maxDepth, initialLength);
                DrawCantorsSet(startPoint2, endPoint2, depth - 1, maxDepth, initialLength);
            }
        }
    }
}
