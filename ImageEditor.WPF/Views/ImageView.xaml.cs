using System;
using System.Windows.Forms;
using ImageEditor.Infrastructure;
using ImageEditor.Infrastructure.Drawing;
using ImageEditor.Infrastructure.Input;
using ImageEditor.ViewModels;
using MugenMvvmToolkit.Interfaces.Models;
using MugenMvvmToolkit.Interfaces.ViewModels;
using MugenMvvmToolkit.Interfaces.Views;
using UserControl = System.Windows.Controls.UserControl;

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
            _renderControl.MouseDown += OnImageMouseDown;
            _renderControl.MouseMove += OnImageMouseMove;
            _renderControl.MouseUp += OnImageMouseUp;

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

        private void OnImageMouseUp(object sender, MouseEventArgs e)
        {
            if (_vm == null || !TryConvertMouseEventArgs(e, out var args))
            {
                return;
            }

            _vm.ProcessMouseUp(args);
        }

        private void OnImageMouseMove(object sender, MouseEventArgs e)
        {
            if (_vm == null || !TryConvertMouseEventArgs(e, out var args))
            {
                return;
            }

            _vm.ProcessMouseMove(args);

        }

        private void OnImageMouseDown(object sender, MouseEventArgs e)
        {
            if (_vm == null || !TryConvertMouseEventArgs(e, out var args))
            {
                return;
            }

            _vm.ProcessMouseDown(args);
        }

        private static bool TryConvertMouseEventArgs(MouseEventArgs original, out MouseArgs converted)
        {
            var point = new PointD(original.X, original.Y);

            if (original.Button == MouseButtons.Left)
            {
                converted = new MouseArgs(point, MouseButton.Left);
                return true;
            }

            if (original.Button == MouseButtons.Right)
            {
                converted = new MouseArgs(point, MouseButton.Right);
                return true;
            }

            converted = null;
            return false;
        }
    }
}
