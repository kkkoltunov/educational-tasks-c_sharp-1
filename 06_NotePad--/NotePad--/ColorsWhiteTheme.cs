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
    class ColorsWhiteTheme : ProfessionalColorTable
    {
        // Цвет выбранного элемента MenuItemSelected.
        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(51, 153, 255); }
        }

        // Сплошной цвет фона ToolStripDropDownBackground.
        public override Color ToolStripDropDownBackground
        {
            get { return Color.White; }
        }

        // Получает начальный цвет градиента, используемого в поле изображения ToolStripDropDownMenu.
        public override Color ImageMarginGradientBegin
        {
            get { return Color.White; }
        }

        // Получает конечный цвет градиента, используемого в поле изображения ToolStripDropDownMenu.
        public override Color ImageMarginGradientEnd
        {
            get { return Color.White; }
        }

        // Получает цвет в центре градиента, используемого в поле изображения ToolStripDropDownMenu.
        public override Color ImageMarginGradientMiddle
        {
            get { return Color.White; }
        }

        // Получает начальный цвет градиента, используемого при выборе ToolStripMenuItem.
        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.FromArgb(51, 153, 255); }
        }

        // Получает конечный цвет градиента, используемого при выборе ToolStripMenuItem.
        public override Color MenuItemSelectedGradientEnd
        {
            get { return Color.FromArgb(51, 153, 255); }
        }

        // Получает начальный цвет градиента, используемого при нажатом ToolStripMenuItem верхнего уровня.
        public override Color MenuItemPressedGradientBegin
        {
            get { return Color.FromArgb(51, 153, 255); }
        }

        // Получает цвет в центре градиента, используемого при нажатом ToolStripMenuItem верхнего уровня.
        public override Color MenuItemPressedGradientMiddle
        {
            get { return Color.FromArgb(51, 153, 255); }
        }

        // Получает конечный цвет градиента, используемого при нажатии ToolStripMenuItem верхнего уровня.
        public override Color MenuItemPressedGradientEnd
        {
            get { return Color.FromArgb(51, 153, 255); }
        }

        // Получает цвет границы для использования с ToolStripMenuItem.
        public override Color MenuItemBorder
        {
            get { return Color.FromArgb(51, 153, 255); }
        }
    }
}
