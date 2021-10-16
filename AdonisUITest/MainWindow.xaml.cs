using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

using AdonisUI;

namespace AdonisUITest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const bool UseItemSource = false;

        private ObservableCollection<DiagnosticsItem> m_ItemCollection = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private bool m_Loaded;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (m_Loaded) { return; }
            m_Loaded = true;

            if (UseItemSource)
            {
                TestDataGrid.ItemsSource = m_ItemCollection;
            }
        }

        private void AddDataGridItemButton_Click(object sender, RoutedEventArgs e)
        {

            DiagnosticsItem item = new() { Timestamp = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fff"), Data = "Test record" };

            if (UseItemSource)
            {
                m_ItemCollection.Add(item);
                while (m_ItemCollection.Count > 100)
                {
                    m_ItemCollection.RemoveAt(0);
                }
            }
            else
            {
                TestDataGrid.Items.Add(item);
                while (TestDataGrid.Items.Count > 100)
                {
                    TestDataGrid.Items.RemoveAt(0);
                }
            }

            TestDataGrid.ScrollIntoView(item);
        }

        private void Window_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ToggleTheme();
        }

        private bool _darkMode;

        private void ToggleTheme()
        {
            ResourceLocator.SetColorScheme(Application.Current.Resources, _darkMode ? ResourceLocator.LightColorScheme : ResourceLocator.DarkColorScheme);

            _darkMode = !_darkMode;
        }
    }

    class DiagnosticsItem
    {
        public string Timestamp { get; set; }
        public string Data { get; set; }
    }
}
