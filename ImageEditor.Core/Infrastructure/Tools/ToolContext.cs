using System;
using System.Collections.Generic;
using System.Text;
using ImageEditor.Infrastructure.Rendering;
using ImageEditor.Interfaces;

namespace ImageEditor.Infrastructure.Tools
{
    public sealed class ToolContext
    {
        public ToolContext(IImageProvider imageProvider)
        {
            ImageProvider = imageProvider;
        }

        public IImageProvider ImageProvider { get; }

        public IDisposable BeginDraw()
        {
            return ImageProvider.Image.BeginDraw();
        }
    }
}