using System;
using System.Collections.Generic;
using System.Text;
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