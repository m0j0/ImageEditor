using System;
using System.Collections.Generic;
using System.Text;
using ImageEditor.Infrastructure.Input;
using MugenMvvmToolkit;

namespace ImageEditor.Infrastructure.Tools
{
    public abstract class ToolBase : ITool
    {
        #region Constructors

        protected ToolBase(ToolContext context)
        {
            Should.NotBeNull(context, nameof(context));
            Context = context;
        }

        #endregion

        #region Properties

        public abstract string Name { get; }

        protected ToolContext Context { get; }

        #endregion

        #region Methods

        public void ProcessMouseMove(MouseArgs args)
        {
            OnMouseMove(args);
        }

        public void ProcessMouseUp(MouseArgs args)
        {
            OnMouseUp(args);
        }

        public void ProcessMouseDown(MouseArgs args)
        {
            OnMouseDown(args);
        }


        protected virtual void OnMouseMove(MouseArgs args)
        {
        }


        protected virtual void OnMouseUp(MouseArgs args)
        {
        }

        protected virtual void OnMouseDown(MouseArgs args)
        {
        }

        #endregion
    }
}