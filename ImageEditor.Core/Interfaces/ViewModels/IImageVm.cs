using System;
using System.Collections.Generic;
using System.Text;
using ImageEditor.Infrastructure.Input;
using ImageEditor.Infrastructure.Rendering;
using MugenMvvmToolkit.Models;

namespace ImageEditor.Interfaces.ViewModels
{
    public interface IImageVm
    {
        ImageModel Image { get; }

        event EventHandler<IImageVm, MouseArgs> MouseUp;

        event EventHandler<IImageVm, MouseArgs> MouseDown;

        event EventHandler<IImageVm, MouseArgs> MouseMove;
    }
}
