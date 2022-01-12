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
    // Класс фракталов.
    class Fractal
    {
        // Глубина рекурсии.
        public int depth;

        // Размер факторила.
        public double lengthFactor;

        // Длина ветви (для фрактального дерева).
        public double branchLengthScale;

        // Расстояние между отрезками (для множества Кантора).
        public float layerDistance = 10;

        // 1 Угол наклона ветвей (для фрактального дерева).
        public double fractalTreeAngle1;

        // 2 Угол наклона ветвей (для фрактального дерева).
        public double fractalTreeAngle2;

        // Объект для рисования фрактала.
        public Graphics gr;

        // Объект класса точки.
        public Point _mousePt;

        // Предел максимальной глубины отрисовки фрактала.
        public int depthLimit = 20;

        // Ограничение глубины рекурсии (включено/выключено).
        public bool limit = true;

        // Метод для построения фракталов.
        public virtual void DrawFractal(PictureBox pictureBox) { }

        // Метод для установки ширины и цвета ручки.
        public void PenColorAndWidth(int depth, int maxDepth, ref Pen pen)
        {
            pen.Color = Color.DarkMagenta;

            int thickness = 10 * depth / maxDepth;
            
            if (thickness < 0)
            {
                thickness = 0;
            }

            pen.Width = thickness;
        }
    }
}
