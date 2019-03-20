using System;
using System.Collections.Generic;
using System.Text;
using ImageEditor.Infrastructure.Rendering;
using ImageEditor.Interfaces;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.ViewModels;

namespace ImageEditor.ViewModels
{
    public class MainVm : ViewModelBase, IImageProvider
    {
        #region Constructors

        public MainVm()
        {
            IocContainer.BindToConstant(typeof(IImageProvider), this);

            ImageVm = GetViewModel<ImageVm>();
            ToolbarVm = GetViewModel<ToolbarVm>();
        }

        #endregion

        #region Properties

        public string DisplayName => "Image editor";

        public ImageVm ImageVm { get; }

        public ToolbarVm ToolbarVm { get; }

        #endregion

        #region Implementation of IImageProvider

        ImageModel IImageProvider.Image => ImageVm.Image;

        #endregion
    }
}