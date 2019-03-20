using ImageEditor.Infrastructure.Drawing;

namespace ImageEditor.Infrastructure.Input
{
    public sealed class MouseArgs
    {
        public MouseArgs(PointD point, MouseButton button)
        {
            Point = point;
            Button = button;
        }

        public PointD Point { get; }

        public MouseButton Button { get; }
    }
}