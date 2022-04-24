using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Lab2
{
    class FilesModel
    {
        public TreeView FilesView { get; set; }

        public FilesModel()
        {
            FilesView = new TreeView();
        }
    }
}
