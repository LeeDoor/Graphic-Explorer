using System.IO;

namespace Explorer
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// object of explorer
        /// </summary>
        private Explorer explorer;

        /// <summary>
        /// this list contains the information that our list box will display. 
        /// but unlike the Items property in the Listbox, this array contains 
        /// the full paths to the files, while Items contains only the names 
        /// of files and folders for a more beautiful display
        /// 
        /// этот список содержит ту информацию, которую будет отображать наш list box . 
        /// но в отличие от свойства Items в Listbox этот массив содержит полные пути до 
        /// файлов, в то время как Items содержит только имена файлов и папок для более 
        /// красивого отображения
        /// </summary>
        private string[] elementPaths;

        public MainForm()
        {
            InitializeComponent();
            explorer = new Explorer();
            elementPaths = new string[0];
        }

        /// <summary>
        /// function updates elements in listbox
        /// </summary>
        private void UpdateElements()
        {
            elementPaths = explorer.GetFilesAndFolders();

            FileListBox.Items.Clear();

            foreach (var elem in elementPaths)
            {
                if (elem[^1] == '\\')
                    FileListBox.Items.Add(elem);
                else
                    FileListBox.Items.Add(elem.Substring(elem.LastIndexOf('\\') + 1));
            }

            DirectoryTextBox.Text = explorer.Path;
            Text = explorer.Path;
        }

        private void OnForm1Load(object sender, EventArgs e)
        {
            UpdateElements();
        }

        /// <summary>
        /// when we want to enter current folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFileListBoxDoubleClick(object sender, EventArgs e)
        {
            if(FileListBox.SelectedItems.Count != 0)
            {
                if(FileListBox.SelectedItem is string)
                {
                    explorer.Path = elementPaths[FileListBox.SelectedIndex];
                    UpdateElements();
                }
            }
        }

        /// <summary>
        /// when we want to move back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBackButtonClick(object sender, EventArgs e)
        {
            explorer.SetPathToParent();
            UpdateElements();
        }

        /// <summary>
        /// when we press enter on a pathline box to enter our own path
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDirectoryTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\r') 
                return;
            var newPath = DirectoryTextBox.Text;
            if (Directory.Exists(newPath))
            {
                explorer.Path = newPath;
            }
            UpdateElements();
        }

        #region Context menu buttons
        private void OnElementContextMenuOpening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ElementContextMenu.Items.Clear();
            if (FileListBox.SelectedItems.Count > 0)
            {
                if(FileListBox.SelectedItem is string)
                {
                    if (File.Exists(elementPaths[FileListBox.SelectedIndex]))
                    {
                        AddFileButtonsContext();
                    }
                }
                AddSelectedButtonsContext();
            }
            AddCommonButtonsContext();
        }


        private void AddFileButtonsContext()
        {
            ToolStripMenuItem OpenItem = new ToolStripMenuItem("open");
            ToolStripMenuItem OpenNotepadItem = new ToolStripMenuItem("open with notepad");

            ElementContextMenu.Items.AddRange(new[] { OpenItem, OpenNotepadItem });

            //OpenItem.Click = 
            //OpenNotepadItem.Click = 
        }

        private void AddSelectedButtonsContext()
        {
            ToolStripMenuItem RenameItem = new ToolStripMenuItem("rename");
            ToolStripMenuItem DeleteItem = new ToolStripMenuItem("delete");
            ToolStripMenuItem CopyItem  = new ToolStripMenuItem("copy");
            ToolStripMenuItem InfoItem  = new ToolStripMenuItem("features");

            ElementContextMenu.Items.AddRange(new[] { RenameItem, DeleteItem, CopyItem, InfoItem });

            //RenameItem.Click = 
            //DeleteItem.Click = 
            //CopyItem.Click   = 
            //InfoItem.Click   = 
        }

        private void AddCommonButtonsContext()
        {
            ToolStripMenuItem createFolderItem = new ToolStripMenuItem("create folder");
            ToolStripMenuItem createFileItem = new ToolStripMenuItem("create text file");

            ElementContextMenu.Items.AddRange(new[] { createFolderItem, createFileItem });

            createFolderItem.Click += OnCreateFolderMenuItemClick;
            createFileItem.Click += OnCreateFileMenuItemClick;
        }

        private void OnCreateFolderMenuItemClick(object sender, EventArgs e)
        {
            using (var form = new TitleEnterMenu(true))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string title = form.title;
                    explorer.CreateFolder(title);
                    UpdateElements();
                }
            }
        }

        private void OnCreateFileMenuItemClick(object sender, EventArgs e)
        {
            using (var form = new TitleEnterMenu(false))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string title = form.title;
                    explorer.CreateFile(title);
                    UpdateElements();
                }
            }
        }
        #endregion
    }
}