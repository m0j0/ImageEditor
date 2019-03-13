using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using SharpDX;
using SharpDX.DXGI;
using SharpDX.Mathematics.Interop;

namespace ImageEditor.Infrastructure.Rendering
{
    internal class Renderer
    {
        private readonly DeviceResources _resources;

        public Renderer(IntPtr handle)
        {
            _resources = new DeviceResources(handle);
        }

        public void SetDrawableArea(Size2 size)
        {
            if (_resources.TryResize(size))
            {
                Render();
            }
        }

        public void Render()
        {
            _resources.DeviceContext.BeginDraw();
            _resources.DeviceContext.Clear(new RawColor4(1f, 0, 0, 1f));
            _resources.DeviceContext.EndDraw();
            _resources.SwapChain.Present(1, PresentFlags.None);
        }
    }
}
