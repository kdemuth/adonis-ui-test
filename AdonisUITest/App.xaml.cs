using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace AdonisUITest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            DispatcherUnhandledException += App_DispatcherUnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            base.OnStartup(e);
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            // Process unhandled exception
            Debug.WriteLine($"{nameof(CurrentDomain_UnhandledException)}: {e.ExceptionObject}");
            MessageBox.Show($"{nameof(CurrentDomain_UnhandledException)}: {(e.ExceptionObject as Exception)?.Message}");
        }

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            // Process unhandled exception
            Debug.WriteLine($"{nameof(App_DispatcherUnhandledException)}: {e.Exception}");
            MessageBox.Show($"{nameof(App_DispatcherUnhandledException)}: {e.Exception.Message}");

            // Prevent default unhandled exception processing
            e.Handled = true;
        }

        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            // Process unhandled exception
            Debug.WriteLine($"{nameof(TaskScheduler_UnobservedTaskException)}: {e.Exception}");
            MessageBox.Show($"{nameof(TaskScheduler_UnobservedTaskException)}: {e.Exception.Message}");

            // Prevent default unhandled exception processing
            e.SetObserved();
        }
    }
}
