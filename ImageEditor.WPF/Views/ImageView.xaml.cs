using System;
using System.Windows.Controls;
using ImageEditor.Infrastructure;
using ImageEditor.ViewModels;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.Interfaces.Views;

namespace ImageEditor.Views
{
    public partial class ImageView : UserControl, IInitializableView
    {
        private readonly RenderControl _renderControl;
        private ImageVm _vm;

        public ImageView()
        {
            InitializeComponent();

            _renderControl = new RenderControl();

            Host.PropertyMap.Clear();
            Host.Child = _renderControl;
        }
        
        public void Initialize(IViewModel viewModel, IDataContext context)
        {
            if (_vm != null)
            {
                throw new NotSupportedException();
            }

            _vm = (ImageVm)viewModel;
            var paintHandler = _vm.InitializeDx(_renderControl.Handle);
            _renderControl.Paint += (sender, args) => paintHandler();
        }
    }
}
