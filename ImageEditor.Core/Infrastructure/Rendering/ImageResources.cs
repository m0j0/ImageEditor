using System;
using System.Collections.Generic;
using System.Text;
using ImageEditor.Infrastructure.Drawing;
using SharpDX;

namespace ImageEditor.Infrastructure.Rendering
{
    public class ImageModel
    {
        private class MyClass : IDisposable
        {
            public void Dispose()
            {
                
            }
        }

        public ImageModel(Size size)
        {
            
        }

        public IDisposable BeginDraw()
        {
            return new MyClass();
        }
    }
}