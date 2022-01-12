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
    // Класс фрактального дерева.
    class FractalTree : Fractal
    {
        // Метод для отрисовки фрактала.
        public override void DrawFractal(PictureBox pictureBox)
        {
            DrawBranch(depth, depth, _mousePt.X, _mousePt.Y,
                (float)lengthFactor * (pictureBox.Size.Width + pictureBox.Size.Height),
                (float)lengthFactor * (pictureBox.Size.Width + pictureBox.Size.Height),
                -(float)(Math.PI / 2), (float)branchLengthScale, (float)(fractalTreeAngle1),
                (float)(fractalTreeAngle2));
        }

        // Отрисовка фрактала по переданным координатам.
        private void DrawBranch(int depth, int maxDepth, float x, float y, float length,
            float initialLength, float angle, float lengthScale, float angle1, float angle2)
        {
            // Подсчет координат точек.
            float x1 = (float)(x + length * Math.Cos(angle));
            float y1 = (float)(y + length * Math.Sin(angle));

            // Создание ручки и установка для нее сопутсвующих параметров.
            Pen pen = new Pen(Color.White);
            PenColorAndWidth(depth, maxDepth, ref pen);

            // Отрисовка линий.
            gr.DrawLine(pen, x, y, x1, y1);

            if (depth > 1)
            {
                DrawBranch(depth - 1, maxDepth, x1, y1, length * lengthScale,
                    initialLength, angle + angle1, lengthScale, angle1, angle2);
                DrawBranch(depth - 1, maxDepth, x1, y1, length * lengthScale,
                    initialLength, angle - angle2, lengthScale, angle1, angle2);
            }
        }
    }
}
