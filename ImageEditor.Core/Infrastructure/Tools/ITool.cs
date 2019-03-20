using System;
using System.Collections.Generic;
using System.Text;
using ImageEditor.Infrastructure.Input;

namespace ImageEditor.Infrastructure.Tools
{
    public interface ITool
    {
        string Name { get; }

        //void PerformMouseEnter();
        //void PerformMouseLeave();
        void ProcessMouseMove(MouseArgs args);
        void ProcessMouseUp(MouseArgs args);
        void ProcessMouseDown(MouseArgs args);
        //void ProcessMouseWheel();
    }
}
