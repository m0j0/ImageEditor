using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.Infrastructure.Tools
{
    public class PaintbrushTool : ToolBase
    {
        public PaintbrushTool(ToolContext toolContext) : base(toolContext)
        {
        }

        #region Overrides of ToolBase

        public override string Name => "Paintbrush";

        #endregion
    }
}
