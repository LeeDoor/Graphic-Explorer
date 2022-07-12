using System.IO;

namespace Explorer
{
    public partial class MainForm : Form
    {
        private Explorer explorer;

        public MainForm()
        {
            InitializeComponent();
        }
        
        private void UpdateElements()
        {
            FileListBox.Items.Clear();
            FileListBox.Items.AddRange(explorer.SetFilesAndFolders());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            explorer = new Explorer();
            UpdateElements();
        }

        private void OnFileListBoxDoubleClick(object sender, EventArgs e)
        {
            if(FileListBox.SelectedItems.Count != 0)
            {
                if(FileListBox.SelectedItem is string newPath)
                {
                    if (Directory.Exists(newPath))
                    {
                        explorer.Path = newPath;
                        UpdateElements();
                    }
                }
            }
        }
    }
}