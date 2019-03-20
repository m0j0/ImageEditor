using System;
using System.Collections.Generic;
using System.Text;

namespace ImageEditor.Infrastructure.Tools
{
    public interface ITool
    {
        string Name { get; }

        //void PerformMouseEnter();
        //void PerformMouseLeave();
        void ProcessMouseMove();
        void ProcessMouseUp();
        void ProcessMouseDown();

    }
}
