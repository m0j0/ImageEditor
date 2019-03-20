using System;
using System.Collections.Generic;
using System.Text;
using ImageEditor.Infrastructure.Drawing;
using ImageEditor.Infrastructure.Input;

namespace ImageEditor.Infrastructure.Tools
{
    public class PaintbrushTool : ToolBase
    {
        #region Fields

        private bool _isTracking;

        #endregion

        #region Constructors

        public PaintbrushTool(ToolContext context) : base(context)
        {
        }

        #endregion

        #region Properties

        public override string Name => "Paintbrush";

        #endregion

        #region Methods

        protected override void OnMouseMove(MouseArgs args)
        {
            base.OnMouseMove(args);

            if (_isTracking)
            {
                Draw(args.Point);
            }
        }

        protected override void OnMouseUp(MouseArgs args)
        {
            base.OnMouseUp(args);

            if (!_isTracking)
            {
                return;
            }

            _isTracking = false;
        }

        protected override void OnMouseDown(MouseArgs args)
        {
            base.OnMouseDown(args);

            if (args.Button != MouseButton.Left)
            {
                return;
            }

            _isTracking = true;
            Draw(args.Point);
        }

        private void Draw(PointD point)
        {
            using (Context.BeginDraw())
            {
            }
        }

        #endregion
    }
}