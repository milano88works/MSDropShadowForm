using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace milano88.UI.Controls
{
    public class MSDropShadowForm : Component
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        [DllImport("dwmapi.dll")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        private Form _baseForm;
        [Category("Misc")]
        [DefaultValue(typeof(Form), null)]
        public Form BaseForm
        {
            get => _baseForm;
            set
            {
                if (value == null) return;
                _baseForm = value;
                var v = 2;
                DwmSetWindowAttribute(_baseForm.Handle, 2, ref v, 4);
                MARGINS margins = new MARGINS()
                {
                    bottomHeight = 1,
                    leftWidth = 1,
                    rightWidth = 1,
                    topHeight = 1
                };
                DwmExtendFrameIntoClientArea(_baseForm.Handle, ref margins);
            }
        }
    }
}