using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.Infrastructure.Tools
{
    public abstract class ToolBase : ITool
    {
        #region Constructors

        protected ToolBase(ToolContext toolContext)
        {
            ToolContext = toolContext;
        }

        #endregion

        #region Properties

        protected ToolContext ToolContext { get; }

        #endregion

        #region Methods

        public abstract string Name { get; }

        public void ProcessMouseMove()
        {
        }

        public void ProcessMouseUp()
        {
        }

        public void ProcessMouseDown()
        {
        }

        #endregion
    }
}