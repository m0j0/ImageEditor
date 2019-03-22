using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using ImageEditor.Infrastructure.Tools;
using ImageEditor.Interfaces;
using ImageEditor.Interfaces.ViewModels;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Models;
using MugenMvvmToolkit.ViewModels;

namespace ImageEditor.ViewModels
{
    public class ToolbarVm : ViewModelBase
    {
        #region Fields

        private ITool _selectedTool;

        #endregion

        #region Constructors

        public ToolbarVm(IImageVm imageVm)
        {
            Should.NotBeNull(imageVm, nameof(imageVm));

            SelectToolCommand = new RelayCommand<ITool>(SelectTool);

            var toolContext = new ToolContext(imageVm);

            PanTool = new PaintbrushTool(toolContext);
            ZoomTool = new PaintbrushTool(toolContext);
            PaintbrushTool = new PaintbrushTool(toolContext);

            Tools = new[]
            {
                PanTool,
                ZoomTool,
                PaintbrushTool
            };
            SelectedTool = Tools[0];

            imageVm.MouseUp += (sender, args) =>
            {
                foreach (var tool in Tools)
                {
                    tool.ProcessMouseUp(args);
                }
            };
            imageVm.MouseDown += (sender, args) =>
            {
                foreach (var tool in Tools)
                {
                    tool.ProcessMouseDown(args);
                }
            };
            imageVm.MouseMove += (sender, args) =>
            {
                foreach (var tool in Tools)
                {
                    tool.ProcessMouseMove(args);
                }
            };
        }

        #endregion

        #region Commands

        public ICommand SelectToolCommand { get; }

        private void SelectTool(ITool tool)
        {
            SelectedTool = tool;
        }

        #endregion

        #region Properties

        public IReadOnlyList<ITool> Tools { get; }

        public PaintbrushTool PanTool { get; }
        public PaintbrushTool ZoomTool { get; }
        public PaintbrushTool PaintbrushTool { get; }

        public ITool SelectedTool
        {
            get => _selectedTool;
            private set
            {
                if (_selectedTool == value)
                {
                    OnPropertyChanged();
                    return;
                }

                _selectedTool = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}