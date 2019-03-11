using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using ImageEditor.ViewModels;
using MugenMvvmToolkit;
using MugenMvvmToolkit.Interfaces.Presenters;
using MugenMvvmToolkit.WPF.Infrastructure;

namespace ImageEditor
{
    public partial class App : Application
    {
        public App()
        {
            new Bootstrapper<MainVm>(this, new MugenContainer());

            DispatcherUnhandledException += OnDispatcherUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskSchedulerOnUnobservedTaskException;
        }

        private void TaskSchedulerOnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs args)
        {
            args.SetObserved();
            HandleException(args.Exception);
        }

        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs args)
        {
            args.Handled = true;
            HandleException(args.Exception);
        }

        private static void HandleException(Exception exception)
        {
            ServiceProvider.IocContainer.Get<IMessagePresenter>().ShowAsync(exception.Flatten(true));
        }
    }
}