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
    public partial class TextEditorForm : Form
    {
        private string path; 

        public TextEditorForm(string path)
        {
            InitializeComponent();
            this.path = path;

            using (var reader = new StreamReader(path))
            {
                string line = reader.ReadToEnd();
                textBox.Text = line;
            }
        }

        private void TextEditorForm_Load(object sender, EventArgs e)
        {

        }

        private void OnsaveButtonClick(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine(textBox.Text);
            }
        }
    }
}
