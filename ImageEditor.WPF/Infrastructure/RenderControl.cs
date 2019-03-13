using System.Windows.Forms;

namespace ImageEditor.Infrastructure
{
    public sealed class RenderControl : UserControl
    {
        public RenderControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque | ControlStyles.UserPaint, true);
            UpdateStyles();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }
    }
}
