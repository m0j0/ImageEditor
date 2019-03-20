using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using ImageEditor.Infrastructure.Tools;
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

        public ToolbarVm()
        {
            SelectToolCommand = new RelayCommand<ITool>(SelectTool);

            PanTool = new PaintbrushTool(null);
            ZoomTool = new PaintbrushTool(null);
            PaintbrushTool = new PaintbrushTool(null);

            SelectedTool = PaintbrushTool;
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