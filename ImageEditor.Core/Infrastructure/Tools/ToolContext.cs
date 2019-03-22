using System;
using System.Collections.Generic;
using System.Text;
using ImageEditor.Infrastructure.Rendering;
using ImageEditor.Interfaces;
using ImageEditor.Interfaces.ViewModels;

namespace ImageEditor.Infrastructure.Tools
{
    public sealed class ToolContext
    {
        public ToolContext(IImageVm imageVm)
        {
            ImageVm = imageVm;
        }

        public IImageVm ImageVm { get; }

        public IDisposable BeginDraw()
        {
            return ImageVm.Image.BeginDraw();
        }
    }
}