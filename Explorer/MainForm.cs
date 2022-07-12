using System.IO;

namespace Explorer
{
    public partial class MainForm : Form
    {
        private Explorer explorer;
        private string[] elementPaths;

        public MainForm()
        {
            InitializeComponent();
            explorer = new Explorer();
        }
        
        private void UpdateElements()
        {
            elementPaths = explorer.SetFilesAndFolders();

            FileListBox.Items.Clear();

            foreach (var elem in elementPaths)
            {
                if (elem[^1] == '\\')
                    FileListBox.Items.Add(elem);
                else
                    FileListBox.Items.Add(elem.Substring(elem.LastIndexOf('\\') + 1));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateElements();
        }

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

        private void OnBackButtonClick(object sender, EventArgs e)
        {
            explorer.SetPathToParent();
            UpdateElements();
        }
    }
}