using System.Diagnostics;
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
        /// ???? ?????? ???????? ?? ??????????, ??????? ????? ?????????? ??? list box . 
        /// ?? ? ??????? ?? ???????? Items ? Listbox ???? ?????? ???????? ?????? ???? ?? 
        /// ??????, ? ?? ????? ??? Items ???????? ?????? ????? ?????? ? ????? ??? ????? 
        /// ????????? ???????????
        /// </summary>
        private string[] elementPaths;

        private string copyBuff;

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
                if(FileListBox.SelectedItem is string str)
                {
                    if (Directory.Exists(elementPaths[FileListBox.SelectedIndex]))
                    {
                        explorer.Path = elementPaths[FileListBox.SelectedIndex];
                        UpdateElements();
                    }
                    else if (File.Exists(elementPaths[FileListBox.SelectedIndex]))
                    {
                        OnOpenItemClick(null, null);
                    }
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
        /// <summary>
        /// when context menu opens, sets all buttons according to selected item if it is
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        
        /// <summary>
        /// adds buttons to context menu even if we dont have any selected element
        /// </summary>
        private void AddCommonButtonsContext()
        {
            ToolStripMenuItem createFolderItem = new ToolStripMenuItem("create folder");
            ToolStripMenuItem createFileItem = new ToolStripMenuItem("create text file");
            ToolStripMenuItem PasteItem = new ToolStripMenuItem("paste");

            ElementContextMenu.Items.AddRange(new[] { createFolderItem, createFileItem, PasteItem });

            createFolderItem.Click += OnCreateFolderItemClick;
            createFileItem.Click += OnCreateFileItemClick;
            PasteItem.Click += OnPasteItemClick;
        }

        /// <summary>
        /// adds buttons to context menu if we have anything selected 
        /// </summary>
        private void AddSelectedButtonsContext()
        {
            ToolStripMenuItem RenameItem = new ToolStripMenuItem("rename");
            ToolStripMenuItem DeleteItem = new ToolStripMenuItem("delete");
            ToolStripMenuItem CopyItem = new ToolStripMenuItem("copy");
            ToolStripMenuItem InfoItem = new ToolStripMenuItem("features");

            ElementContextMenu.Items.AddRange(new[] { RenameItem, DeleteItem, CopyItem, InfoItem });

            RenameItem.Click += OnRenameItemClick;
            DeleteItem.Click += OnDeleteItemClick;
            CopyItem.Click += OnCopyItemClick;
            InfoItem.Click += OnInfoItemClick;
        }

        /// <summary>
        /// adds buttons to context menu if we have file as selected item
        /// </summary>
        private void AddFileButtonsContext()
        {
            ToolStripMenuItem OpenItem = new ToolStripMenuItem("open");
            ToolStripMenuItem OpenNotepadItem = new ToolStripMenuItem("open with notepad");

            ElementContextMenu.Items.AddRange(new[] { OpenItem, OpenNotepadItem });

            OpenItem.Click += OnOpenItemClick;
            OpenNotepadItem.Click += OnOpenNotepadItemClick;
        }

        /// <summary>
        /// PASTE click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPasteItemClick(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(copyBuff))
                return;

            explorer.Paste(copyBuff);
            UpdateElements();
        }

        /// <summary>
        /// COPY clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCopyItemClick(object sender, EventArgs e)
        {
            copyBuff = elementPaths[FileListBox.SelectedIndex];
        }

        /// <summary>
        /// OPEN clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOpenItemClick(object sender, EventArgs e)
        {
            if (elementPaths[FileListBox.SelectedIndex] is string path)
            {
                using (var form = new TextEditorForm(path))
                {
                    form.ShowDialog();
                }
            }
        }

        /// <summary>
        /// OPEN WITH NOTEPAD clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnOpenNotepadItemClick(object sender, EventArgs e)
        {
            if (elementPaths[FileListBox.SelectedIndex] is String path)
            {
                if (File.Exists(path))
                {
                    Process.Start("C:\\Windows\\System32\\notepad.exe", path);
                }
            }
        }

        /// <summary>
        /// RENAME clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnRenameItemClick(object sender, EventArgs e)
        {
            bool isFolder;
            string path = elementPaths[FileListBox.SelectedIndex];
            if (Directory.Exists(path))
            {
                isFolder = true;
            }
            else if (File.Exists(path))
            {
                isFolder = false;
            }
            else return;
            using (var form = new TitleEnterMenu(isFolder))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string title = form.title;
                    if (isFolder)
                    {
                        Directory.Move(path, explorer.Path + '\\' + title);
                    }
                    else
                    {
                        File.Move(path, explorer.Path + '\\' + title);
                    }
                    UpdateElements();
                }
            }
        }

        /// <summary>
        /// DELETE clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDeleteItemClick(object sender, EventArgs e)
        {
            if(FileListBox.SelectedItem is string name)
            {
                explorer.Delete(name);
                UpdateElements();
            }
        }

        /// <summary>
        /// CREATE FOLDER clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCreateFolderItemClick(object sender, EventArgs e)
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

        /// <summary>
        /// CREATE FILE clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCreateFileItemClick(object sender, EventArgs e)
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

        /// <summary>
        /// FEATURES clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnInfoItemClick(object sender, EventArgs e)
        {
            if(elementPaths[FileListBox.SelectedIndex] is string path)
            {
                using (var form = new Features(path))
                {
                    var result = form.ShowDialog();
                }
            }
        }
        #endregion
    }
}