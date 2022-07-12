using System.IO;

namespace Explorer
{
    public partial class MainForm : Form
    {
        private Explorer explorer;

        public MainForm()
        {
            InitializeComponent();
            explorer = new Explorer();
        }
        
        private void UpdateElements()
        {
            FileListBox.Items.Clear();
            FileListBox.Items.AddRange(explorer.SetFilesAndFolders());
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
                    explorer.Path = newPath;
                    UpdateElements();
                }
            }
        }

        private void OnBackButtonClick(object sender, EventArgs e)
        {
            if (Directory.Exists(explorer.Path))
            {
                var par = Directory.GetParent(explorer.Path);
                if (par != null)
                    explorer.Path = par.FullName;
                else
                    explorer.Path = Explorer.EMPTYDATA;
                UpdateElements();
            }
        }
    }
}