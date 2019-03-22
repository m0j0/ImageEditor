using System;
using System.Collections.Generic;
using System.Text;
using ImageEditor.Infrastructure.Rendering;
using ImageEditor.Interfaces;
using ImageEditor.Interfaces.ViewModels;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.ViewModels;

namespace ImageEditor.ViewModels
{
    public class MainVm : ViewModelBase
    {
        #region Constructors

        public MainVm()
        {
            ImageVm = GetViewModel<ImageVm>();
            IocContainer.BindToConstant(typeof(IImageVm), ImageVm);

            ToolbarVm = GetViewModel<ToolbarVm>();
        }

        #endregion

        #region Properties

        public string DisplayName => "Image editor";

        public ImageVm ImageVm { get; }

        public ToolbarVm ToolbarVm { get; }

        #endregion
    }
}