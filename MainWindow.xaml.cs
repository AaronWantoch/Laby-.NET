using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Forms;
using System.Diagnostics;

namespace Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FileExplorerControler explorer;
        private FilesModel files;
        public MainWindow()
        {
            InitializeComponent();
            files=new FilesModel();
            explorer = new FileExplorerControler(files, this);
        }

        private void OpenClicked(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog() { Description = "Select directory to open", UseDescriptionForTitle = true };
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                explorer.LoadFiles(dialog.SelectedPath);
                FilesGrid.Children.Add(files.FilesView);
            }
        }

        private void ExitClicked(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        public void DeleteFileClicked(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("Delete File: ");
        }
        public void OpenFileClicked(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("Open File: ");
        }
        public void CreateFileClicked(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("Open File: ");
        }
        public void DeleteDirectoryClicked(object sender, RoutedEventArgs e)
        {
            MenuItem menuItem = sender as MenuItem;
            ContextMenu contextMenu = menuItem.Parent as ContextMenu;
            string s = contextMenu.DataContext.ToString();

            Trace.WriteLine("Open File: " + s);
        }
    }
}
