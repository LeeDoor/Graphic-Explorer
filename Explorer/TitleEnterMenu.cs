using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Explorer
{
    public partial class TitleEnterMenu : Form
    {
        private bool isFolder;
        public string title;

        public TitleEnterMenu(bool isFolder)
        {
            InitializeComponent();
            this.isFolder = isFolder;
            title = (isFolder ? "new folder" : "new text file.txt");
            IconPictureBox.Image = Image.FromFile(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\images\\" + (isFolder?"folder.png":"text.png"));
        }

        private void TitleEnterMenu_Load(object sender, EventArgs e)
        {

        }

        private void OnTitleTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '\r')
            {
                DialogResult = DialogResult.OK;
                title = TitleTextBox.Text;
                if (!isFolder)
                    title += ".txt";
                Close();
            }
        }
    }
}
