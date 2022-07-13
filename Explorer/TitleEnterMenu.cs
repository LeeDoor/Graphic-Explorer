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

        public TitleEnterMenu(bool isFolder)
        {
            InitializeComponent();
            this.isFolder = isFolder;

            IconPictureBox.Image = Image.FromFile("\\images\\" + (isFolder?"folder.png":"text.png"));
        }

        private void TitleEnterMenu_Load(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
