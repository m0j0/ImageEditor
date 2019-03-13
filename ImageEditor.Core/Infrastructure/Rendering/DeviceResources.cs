using System;
using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using SharpDX.WIC;
using AlphaMode = SharpDX.Direct2D1.AlphaMode;
using Device = SharpDX.Direct3D11.Device;
using Device2D1 = SharpDX.Direct2D1.Device;
using DeviceContext2D1 = SharpDX.Direct2D1.DeviceContext;
using FactoryDW = SharpDX.DirectWrite.Factory;
using Factory1_2D1 = SharpDX.Direct2D1.Factory1;
using PixelFormat = SharpDX.Direct2D1.PixelFormat;

namespace ImageEditor.Infrastructure.Rendering
{
    internal class DeviceResources : IDisposable
    {
        #region Constructors

        public DeviceResources(IntPtr handle)
        {
            Factory2D = new Factory1_2D1();
            ImagingFactory = new ImagingFactory();
            FontFactory = new FactoryDW();
            PixelFormat = new PixelFormat(Format.B8G8R8A8_UNorm, AlphaMode.Premultiplied);

            var modeDescription = new ModeDescription(PixelFormat.Format);

            var swapChainDescription = new SwapChainDescription
            {
                BufferCount = 1,
                Flags = SwapChainFlags.AllowModeSwitch,
                IsWindowed = false,
                ModeDescription = modeDescription,
                OutputHandle = handle,
                SampleDescription = new SampleDescription(1, 0),
                SwapEffect = SwapEffect.Discard,
                Usage = Usage.RenderTargetOutput
            };

            Device.CreateWithSwapChain(
                DriverType.Hardware,
                DeviceCreationFlags.BgraSupport,
                swapChainDescription,
                out Device device3D,
                out SwapChain swapChain
            );
            SwapChain = swapChain;

            using (var dxgiDevice = device3D.QueryInterface<SharpDX.DXGI.Device>())
            {
                Device2D = new Device2D1(Factory2D, dxgiDevice);
            }

            device3D.Dispose();

            CreateDeviceContext();
        }

        #endregion

        #region Properties

        public Factory1_2D1 Factory2D { get; }
        public FactoryDW FontFactory { get; }
        public PixelFormat PixelFormat { get; }
        public Device2D1 Device2D { get; }
        public SwapChain SwapChain { get; }
        public ImagingFactory ImagingFactory { get; }

        public DeviceContext2D1 DeviceContext { get; private set; }

        #endregion

        #region Methods

        public bool TryResize(Size2 size)
        {
            if (DeviceContext.PixelSize == size)
            {
                return false;
            }

            DeviceContext.Dispose();
            SwapChain.ResizeBuffers(1, size.Width, size.Height, Format.B8G8R8A8_UNorm, SwapChainFlags.AllowModeSwitch);
            CreateDeviceContext();
            return true;
        }

        public void Dispose()
        {
            ImagingFactory.Dispose();
            Factory2D.Dispose();
            FontFactory.Dispose();
            SwapChain.Dispose();
            Device2D.Dispose();
            DeviceContext.Dispose();
        }

        private void CreateDeviceContext()
        {
            using (var surface = SwapChain.GetBackBuffer<Surface>(0))
            {
                DeviceContext = new DeviceContext2D1(Device2D, DeviceContextOptions.None);
                using (var bitmap = new Bitmap1(DeviceContext, surface))
                {
                    DeviceContext.Target = bitmap;
                }
            }
        }

        #endregion
    }
}
