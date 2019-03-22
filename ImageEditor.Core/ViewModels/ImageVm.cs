using System;
using System.Collections.Generic;
using System.Text;
using ImageEditor.Infrastructure;
using ImageEditor.Infrastructure.Drawing;
using ImageEditor.Infrastructure.Input;
using ImageEditor.Infrastructure.Rendering;
using ImageEditor.Interfaces.ViewModels;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;
using SharpDX;

namespace ImageEditor.ViewModels
{
    public class ImageVm : ViewModelBase, IImageVm
    {
        #region Fields

        private readonly RenderingWorker _renderingWorker = new RenderingWorker();
        private Renderer _renderer;

        #endregion

        #region Constructors

        public ImageVm()
        {
            Image = new ImageModel(new Size(1000, 1000));
        }

        #endregion

        #region Properties

        public ImageModel Image { get; }

        #endregion

        #region Events

        public event EventHandler<IImageVm, MouseArgs> MouseUp;

        public event EventHandler<IImageVm, MouseArgs> MouseDown;

        public event EventHandler<IImageVm, MouseArgs> MouseMove;

        #endregion

        #region Methods

        public Action InitializeDx(IntPtr handle)
        {
            if (_renderer != null)
            {
                throw new InvalidOperationException();
            }

            _renderer = new Renderer(handle);
            _renderer.SetDrawableArea(new Size2(100, 100));

            return Render;
        }

        public void ProcessMouseUp(MouseArgs args)
        {
            MouseUp?.Invoke(this, args);
        }

        public void ProcessMouseDown(MouseArgs args)
        {
            MouseDown?.Invoke(this, args);
        }

        public void ProcessMouseMove(MouseArgs args)
        {
            MouseMove?.Invoke(this, args);
        }

        private void Render()
        {
            _renderingWorker.AddSkippableJob(() => _renderer.Render());
        }

        #endregion
    }
}