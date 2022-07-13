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
        /// ���� ������ �������� �� ����������, ������� ����� ���������� ��� list box . 
        /// �� � ������� �� �������� Items � Listbox ���� ������ �������� ������ ���� �� 
        /// ������, � �� ����� ��� Items �������� ������ ����� ������ � ����� ��� ����� 
        /// ��������� �����������
        /// </summary>
        private string[] elementPaths;

        public MainForm()
        {
            InitializeComponent();
            explorer = new Explorer();
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
                if(FileListBox.SelectedItem is string newPath)
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
        private void OnCreateFolderMenuItemClick(object sender, EventArgs e)
        {
            
            explorer.CreateFolder("new folder");
            UpdateElements();
        }

        private void OnCreateFileMenuItemClick(object sender, EventArgs e)
        {
            explorer.CreateFile("new text file");
            UpdateElements();
        }
        #endregion
    }
}