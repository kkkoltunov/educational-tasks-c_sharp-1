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
    // Класс ковра Серпинского.
    class SierpinskisCarpet : Fractal
    {
        // Метод для отрисовки фрактала.
        public override void DrawFractal(PictureBox pictureBox)
        {
            DrawSierpinskiCarpet(depth, depth,
                new RectangleF(_mousePt.X - 5 * (float)(lengthFactor * (pictureBox.Size.Width + pictureBox.Size.Height)) / 2,
                    _mousePt.Y - 5 * (float)(lengthFactor * (pictureBox.Size.Width + pictureBox.Size.Height)) / 2,
                    5 * (float)lengthFactor * (pictureBox.Size.Width + pictureBox.Size.Height),
                    5 * (float)lengthFactor * (pictureBox.Size.Width + pictureBox.Size.Height)),
                5 * (float)(lengthFactor * (pictureBox.Size.Width + pictureBox.Size.Height)));
        }

        // Отрисовка фрактала по переданным координатам.
        private void DrawSierpinskiCarpet(int depth, int maxDepth, RectangleF carpet, float length)
        {
            // Создание кисти для зарисовки фрагментов.
            SolidBrush brush = new SolidBrush(Color.White);

            if (depth == 0)
            {
                brush.Color = Color.DarkMagenta;
            }
            else
            {
                brush.Color = Color.White;
            }

            gr.FillRectangle(brush, carpet);

            // Проверка ограничения (в случае отрисовок вне зоны видимости, она будет прервана).
            if (limit && (carpet.Height / length < 0.004 || depthLimit == maxDepth - depth))
            {
                depthLimit = maxDepth - depth;
                return;
            }

            // Подсчет ширины и высоты.
            float width = carpet.Width / 3f;
            float height = carpet.Height / 3f;

            // Формирование координат для закрашивания.
            float x1 = carpet.Left;
            float x2 = x1 + width;
            float x3 = x1 + 2f * width;

            float y1 = carpet.Top;
            float y2 = y1 + height;
            float y3 = y1 + 2f * height;

            if (depth > 0)
            {
                DrawSierpinskiCarpet(depth - 1, maxDepth, new RectangleF(x1, y1, width, height), length);
                DrawSierpinskiCarpet(depth - 1, maxDepth, new RectangleF(x2, y1, width, height), length);
                DrawSierpinskiCarpet(depth - 1, maxDepth, new RectangleF(x3, y1, width, height), length);
                DrawSierpinskiCarpet(depth - 1, maxDepth, new RectangleF(x1, y2, width, height), length);
                DrawSierpinskiCarpet(depth - 1, maxDepth, new RectangleF(x3, y2, width, height), length);
                DrawSierpinskiCarpet(depth - 1, maxDepth, new RectangleF(x1, y3, width, height), length);
                DrawSierpinskiCarpet(depth - 1, maxDepth, new RectangleF(x2, y3, width, height), length);
                DrawSierpinskiCarpet(depth - 1, maxDepth, new RectangleF(x3, y3, width, height), length);
            }
        }
    }
}
