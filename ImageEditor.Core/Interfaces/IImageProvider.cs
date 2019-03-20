using System;
using System.Collections.Generic;
using System.Text;
using ImageEditor.Infrastructure.Rendering;

namespace ImageEditor.Interfaces
{
    public interface IImageProvider
    {
        ImageModel Image { get; }
    }
}