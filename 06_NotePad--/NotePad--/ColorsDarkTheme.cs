using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security;
using System.Diagnostics;

namespace NotePad__
{
    class ColorsDarkTheme : ProfessionalColorTable
    {
        // Цвет выбранного элемента MenuItemSelected.
        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(133, 133, 133); }
        }

        // Сплошной цвет фона ToolStripDropDownBackground.
        public override Color ToolStripDropDownBackground
        {
            get { return Color.Black; }
        }

        // Получает начальный цвет градиента, используемого в поле изображения ToolStripDropDownMenu.
        public override Color ImageMarginGradientBegin
        {
            get { return Color.Black; }
        }

        // Получает конечный цвет градиента, используемого в поле изображения ToolStripDropDownMenu.
        public override Color ImageMarginGradientEnd
        {
            get { return Color.Black; }
        }

        // Получает цвет в центре градиента, используемого в поле изображения ToolStripDropDownMenu.
        public override Color ImageMarginGradientMiddle
        {
            get { return Color.Black; }
        }

        // Получает начальный цвет градиента, используемого при выборе ToolStripMenuItem.
        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.FromArgb(133, 133, 133); }
        }

        // Получает конечный цвет градиента, используемого при выборе ToolStripMenuItem.
        public override Color MenuItemSelectedGradientEnd
        {
            get { return Color.FromArgb(133, 133, 133); }
        }

        // Получает начальный цвет градиента, используемого при нажатом ToolStripMenuItem верхнего уровня.
        public override Color MenuItemPressedGradientBegin
        {
            get { return Color.FromArgb(133, 133, 133); }
        }

        // Получает цвет в центре градиента, используемого при нажатом ToolStripMenuItem верхнего уровня.
        public override Color MenuItemPressedGradientMiddle
        {
            get { return Color.FromArgb(133, 133, 133); }
        }

        // Получает конечный цвет градиента, используемого при нажатии ToolStripMenuItem верхнего уровня.
        public override Color MenuItemPressedGradientEnd
        {
            get { return Color.FromArgb(133, 133, 133); }
        }

        // Получает цвет границы для использования с ToolStripMenuItem.
        public override Color MenuItemBorder
        {
            get { return Color.FromArgb(133, 133, 133); }
        }
    }
}
