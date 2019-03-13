using System;
using System.Collections.Generic;
using System.Text;
using ImageEditor.Infrastructure;
using ImageEditor.Infrastructure.Rendering;
using MugenMvvmToolkit.ViewModels;
using SharpDX;

namespace ImageEditor.ViewModels
{
    public class ImageVm : ViewModelBase
    {
        private readonly RenderingWorker _renderingWorker = new RenderingWorker();
        private Renderer _renderer;

        public ImageVm()
        {
        }

        public Action InitializeDx(IntPtr handle)
        {
            _renderer = new Renderer(handle);
            _renderer.SetDrawableArea(new Size2(100, 100));

            return Render;
        }

        private void Render()
        {
            _renderingWorker.AddSkippableJob(() => _renderer.Render());
        }
    }
}