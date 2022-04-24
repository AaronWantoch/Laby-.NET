using System;
using System.Windows;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Diagnostics;

namespace Lab2
{
    class FileExplorerControler
    {
        FilesModel files;
        MainWindow mainWindow;
        public FileExplorerControler(FilesModel files, MainWindow mainWindow)
        {
            this.files = files;
            this.mainWindow = mainWindow;
        }
        public void LoadFiles(string path)
        {
            files.FilesView.Items.Add(ExploreDirectory(new DirectoryInfo(path)));
        }

        private TreeViewItem? ExploreDirectory(DirectoryInfo root)
        {
            FileInfo[]? files = null;
            System.IO.DirectoryInfo[]? subDirs = null;

            try
            {
                files = root.GetFiles();
                subDirs = root.GetDirectories();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            TreeViewItem rootView = new TreeViewItem
            {
                Header = root.Name,
                Tag = root.FullName
            };

            ContextMenu dirContextMenu = CreateDirectoryContextMenu();
            rootView.Resources.Add(rootView, dirContextMenu);

            foreach (FileInfo file in files)
            {
                TreeViewItem item = new TreeViewItem
                {
                    Header = file.Name,
                    Tag = file.FullName
                };
                ContextMenu fileContextMenu = CreateFileContextMenu();
                item.Resources.Add(item, fileContextMenu);

                rootView.Items.Add(item);
            }
            foreach (DirectoryInfo subDir in subDirs)
            {
                TreeViewItem? item = ExploreDirectory(subDir);
                if (item != null)
                    rootView.Items.Add(item);
            }

            return rootView;
        }


        private ContextMenu CreateFileContextMenu()
        {
            /*
            <ContextMenu x:Key="fileCM">
                <MenuItem Header="Open" Click="OpenFileClicked"/>
                <MenuItem Header="Delete" Click="DeleteFileClicked"/>
            </ContextMenu>
            */
            ContextMenu menu = new ContextMenu();

            MenuItem openItem = new MenuItem()
            {
                Header = "Open"
            };
            openItem.Click += mainWindow.OpenFileClicked;
            MenuItem deleteItem = new MenuItem()
            {
                Header = "Delete"
            };
            deleteItem.Click += mainWindow.DeleteFileClicked;

            menu.Items.Add(openItem);
            menu.Items.Add(deleteItem);

            return menu;
        }

        private ContextMenu CreateDirectoryContextMenu()
        {
            /*
            <ContextMenu x:Key="directoryCM">
                <MenuItem Header="Create" Click="CreateFileClicked"/>
                <MenuItem Header="Delete" Click="DeleteDirectoryClicked"/>
            </ContextMenu>
            */
            ContextMenu menu = new ContextMenu();

            MenuItem createItem = new MenuItem()
            {
                Header = "Create"
            };
            createItem.Click += mainWindow.CreateFileClicked;
            MenuItem deleteItem = new MenuItem()
            {
                Header = "Delete"
            };
            deleteItem.Click += mainWindow.DeleteDirectoryClicked;

            menu.Items.Add(createItem);
            menu.Items.Add(deleteItem);

            return menu;
        }
    }
}
